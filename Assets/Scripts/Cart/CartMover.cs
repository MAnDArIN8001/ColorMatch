using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class CartMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody _rigidbody;

    private MainInput _mainInput;

    [Inject]
    private void Initialize(MainInput mainInput)
    {
        _mainInput = mainInput;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody is null)
        {
            Debug.LogError($"The game object {gameObject} doesnt contains Regidbody component");
        }

        transform.position = new Vector2(0, transform.position.y);
    }

    private void OnEnable()
    {
        if (_mainInput is not null)
        {
            _mainInput.Enable();
        }
    }

    private void OnDisable()
    {
        if (_mainInput is not null)
        {
            _mainInput.Disable();
        }
    }

    private void Update()
    {
        Vector2 mousePosDeltaValue = ReadMouseDeltaValues();
        Vector2 direction = new Vector2(mousePosDeltaValue.x, 0);

        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _rigidbody.velocity = direction * _movementSpeed;
    }

    private Vector2 ReadMouseDeltaValues() => _mainInput.Movement.Delta.ReadValue<Vector2>();
}
