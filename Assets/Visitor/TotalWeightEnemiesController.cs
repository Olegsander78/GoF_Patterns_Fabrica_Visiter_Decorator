using UnityEngine;

namespace Assets.Visitor
{
    public class TotalWeightEnemiesController : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private float _totalEnemiesWeight;

        private TotalWeightEnemies _totalWeightEnemy;

        private void Awake()
        {
            _totalWeightEnemy = new TotalWeightEnemies(_spawner);

            _totalWeightEnemy.OnTotalWeightEnemiesChanged += CalculateTotalEnemiesWeight;            

            _spawner.StartWork();
        }

        private void OnDisable()
        {
            _totalWeightEnemy.OnTotalWeightEnemiesChanged -= CalculateTotalEnemiesWeight;
        }

        private void CalculateTotalEnemiesWeight(int totalWeight)
        {
            if (_totalWeightEnemy.Value >= _totalEnemiesWeight)
            {
                _spawner.StopWork();
                Debug.LogWarning($"<color=red>The total weight of the enemies has reached the maximum: {_totalWeightEnemy.Value}, Max:{_totalEnemiesWeight}</color>");
            }                    
        }
    }
}