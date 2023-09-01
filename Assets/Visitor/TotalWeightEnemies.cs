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

            public void Visit(Ork ork) => TotalWeight += ork.Weight;

            public void Visit(Human human) => TotalWeight += human.Weight;

            public void Visit(Elf elf) => TotalWeight += elf.Weight;

            public void Visit(Vampire vampire) => TotalWeight += vampire.Weight;

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }
    }
}