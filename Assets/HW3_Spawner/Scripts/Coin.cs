using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _movementRange = 1f;
    [SerializeField] private float _movementSpeed = 1f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);

        var newPosition = initialPosition + new Vector3(Mathf.Sin(Time.time * _movementSpeed), 0f, 0f) * _movementRange;
        transform.position = newPosition;
    }
}
