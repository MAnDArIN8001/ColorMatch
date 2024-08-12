using System;
using UnityEngine;
using Zenject;

public class CartColorController : MonoBehaviour
{
    public event Action<Color> OnColorChanged;

    [SerializeField] private float _minChangeTime;
    [SerializeField] private float _maxChangeTime;
    private float _randomChangeTime;
    private float _currentChangeTime;

    private Color _currentCollor;

    private ColorConfig _colorConfig;

    [SerializeField] private MeshRenderer _modelRenderer;

    public Color CurrentColor => _currentCollor;

    [Inject]
    private void Initialize(ColorConfig colorConfig)
    {
        _colorConfig = colorConfig;
    }

    private void Start()
    {
        ChangeColor();

        _randomChangeTime = UnityEngine.Random.Range(_minChangeTime, _maxChangeTime);
        _currentChangeTime = _randomChangeTime;
    }

    private void FixedUpdate()
    {
        if (_currentChangeTime <= 0)
        {
            ChangeColor();

            _randomChangeTime = UnityEngine.Random.Range(_minChangeTime, _maxChangeTime);
            _currentChangeTime = _randomChangeTime;
        }

        _currentChangeTime -= Time.fixedDeltaTime;
    }

    private void ChangeColor()
    {
        Color newColor = GetRandomColor();

        OnColorChanged?.Invoke(newColor);

        _modelRenderer.material.color = newColor;
        _currentCollor = newColor;
    }

    private Color GetRandomColor()
    {
        int randomIndex = UnityEngine.Random.Range(0, _colorConfig.Colors.Length);

        return _colorConfig.Colors[randomIndex];
    }
}
