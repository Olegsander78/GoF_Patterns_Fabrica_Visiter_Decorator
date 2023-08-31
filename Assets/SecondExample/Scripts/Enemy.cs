using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Weight => _weight;

    private int _health;
    private float _speed;
    private float _weight;

    public virtual void Initialize(int health, float speed, float weight)
    {
        _health = health;
        _speed = speed;
        _weight = weight;

        Debug.Log($"��: {_health}, ��������: {_speed}, ���: {_weight}");
    }  
    
    public void MoveTo(Vector3 position) => transform.position = position;
}
