using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier, IEnemySpawnNotifier
    {
        public event Action<Enemy> OnDeathNotified;
        public event Action<Enemy> OnSpawnNotified;

        [SerializeField] private float _spawnCooldown;
        //[SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private PositionGenerator _positionGenerator;

        private List<Enemy> _spawnedEnemies  = new List<Enemy>();

        private Coroutine _spawn;

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if(_spawnedEnemies.Count < 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Die();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                
                var spawnPosition = _positionGenerator.GetPosition();
                enemy.MoveTo(spawnPosition);

                enemy.Died += OnEnemyDied;

                _spawnedEnemies.Add(enemy);
                OnSpawnNotified?.Invoke(enemy);

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            OnDeathNotified.Invoke(enemy);
            _spawnedEnemies.Remove(enemy);
        }
    }
}
