using UnityEngine;

public class FigureView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;

    private Figure _figure;

    private void Awake()
    {
        _figure = GetComponent<Figure>();

        if (_figure is null)
        {
            Debug.LogError($"The game object {gameObject} doesnt contains Figure component");
        }
    }

    private void OnEnable()
    {
        if (_figure is not null)
        {
            _figure.OnPickedUp += HandleDestruction;
        }
    }

    private void OnDisable()
    {
        if (_figure is not null)
        {
            _figure.OnPickedUp -= HandleDestruction;
        }
    }

    private void HandleDestruction()
    {
        GameObject effectInstance = Instantiate(_destroyEffect.gameObject, transform.position, Quaternion.identity);

        var mainLayer = effectInstance.GetComponent<ParticleSystem>().main;
        mainLayer.startColor = _figure.CurrentCollor;
    }
}
