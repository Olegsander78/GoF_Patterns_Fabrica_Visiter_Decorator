using System;
using UnityEngine;

namespace Assets.Visitor
{
    public class TotalWeightEnemies
    {
        public event Action<int> OnTotalWeightEnemiesChanged;
        public int Value => _enemyVisiter.TotalWeight;

        private IEnemySpawnNotifier _enemySpawnNotifier;

        private TotalWeightEnemiesVisiter _enemyVisiter;

        public TotalWeightEnemies(IEnemySpawnNotifier enemySpawnNotifier)
        {
            _enemySpawnNotifier = enemySpawnNotifier;
            _enemySpawnNotifier.OnSpawnNotified += OnEnemySpawned;

            _enemyVisiter = new TotalWeightEnemiesVisiter();
        }

        ~TotalWeightEnemies() => _enemySpawnNotifier.OnSpawnNotified-= OnEnemySpawned;

        public void OnEnemySpawned(Enemy enemy)
        {
            _enemyVisiter.Visit(enemy);
            Debug.Log($"Total weight enemies: {Value}");

            OnTotalWeightEnemiesChanged?.Invoke(Value);
        }

        private class TotalWeightEnemiesVisiter : IEnemyVisitor
        {
            public int TotalWeight { get; private set; }

            public void Visit(Ork ork) => TotalWeight += 20;

            public void Visit(Human human) => TotalWeight += 15;

            public void Visit(Elf elf) => TotalWeight += 10;

            public void Visit(Vampire vampire) => TotalWeight += 25;

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }
    }
}