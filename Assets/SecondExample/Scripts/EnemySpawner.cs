using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Action<Enemy> OnEnemySpawned;
    
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private EnemyFactory _enemyFactory;

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

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            OnEnemySpawned?.Invoke(enemy);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}


//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Random = UnityEngine.Random;

//public class EnemySpawner : MonoBehaviour
//{

//    [SerializeField] private float _spawnCooldown;
//    [SerializeField] private List<Transform> _spawnPoints;

//    [SerializeField] private EnemyFactory _enemyFactory;

//    [SerializeField] private float _maxTotalWeight;

//    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

//    private float _totalWeight;

//    private Coroutine _spawn;

//    private void Awake()
//    {
//        _totalWeight = 0f;
//    }

//    public void StartWork()
//    {
//        StopWork();

//        _spawn = StartCoroutine(Spawn());
//    }

//    public void StopWork()
//    {
//        if (_spawn != null)
//            StopCoroutine(_spawn);
//    }

//    private IEnumerator Spawn()
//    {
//        while (true)
//        {
//            if (_totalWeight < _maxTotalWeight) 
//            {
//                Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));

//                if (_totalWeight + enemy.Weight > _maxTotalWeight)
//                {
//                    _enemies.Add(enemy);
//                    _totalWeight += enemy.Weight;

//                    enemy.MoveTo(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
//                }
//            }
//            else
//            {
//                Debug.LogWarning($"Total weight enemies can't exceed the permitted total weight!");
//            }

//            yield return new WaitForSeconds(_spawnCooldown);             
//        }
//    }
//}


