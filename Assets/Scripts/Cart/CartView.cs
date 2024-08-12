using UnityEngine;

[RequireComponent(typeof(CartColorController))]
public class CartView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _colorChanginParticles;

    private CartColorController _cartColorController;

    private void Awake()
    {
        _cartColorController = GetComponent<CartColorController>();

        if (_cartColorController is null)
        {
            Debug.LogError($"The game object {gameObject} doesnt contains CartColorController component");
        }
    }

    private void OnEnable()
    {
        if (_cartColorController is not null)
        {
            _cartColorController.OnColorChanged += HandleColorChangings;
        }
    }

    private void OnDisable()
    {
        if (_cartColorController is not null)
        {
            _cartColorController.OnColorChanged -= HandleColorChangings;
        }
    }

    private void HandleColorChangings(Color newColor)
    {
        var particleMainModule = _colorChanginParticles.main;

        particleMainModule.startColor = newColor;

        GameObject colorChangingsEffec = Instantiate(_colorChanginParticles.gameObject, transform.position, Quaternion.identity);
    }
}
