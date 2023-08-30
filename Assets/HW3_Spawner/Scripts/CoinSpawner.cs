using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private PositionGenerator _positionGenerator;
    [SerializeField, Range(5,50)] private int _numberOfCoins = 10;
    [SerializeField, Range(0,10)] private float _spawnTimePerCoin = 0.1f;

    private Queue<Coin> _coinQueue = new Queue<Coin>();

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    public void CollectCoin()
    {
        if (_coinQueue.Count > 0)
        {
            var coin = _coinQueue.Dequeue();
            Destroy(coin);
        }
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _numberOfCoins; i++) 
        {
            yield return new WaitForSeconds(_spawnTimePerCoin);

            var spawnPosition = _positionGenerator.GetPosition();

            var coin = Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
            _coinQueue.Enqueue(coin);
        }
    }
}
