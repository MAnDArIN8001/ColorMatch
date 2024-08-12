using System;
using UnityEngine;

public class CartColorController : MonoBehaviour
{
    public event Action<Color> OnColorChanged;

    [SerializeField] private float _minChangeTime;
    [SerializeField] private float _maxChangeTime;
    private float _randomChangeTime;
    private float _currentChangeTime;

    [SerializeField] private Color[] _colors;

    private Color _currentCollor;

    [SerializeField] private MeshRenderer _modelRenderer;

    private void Start()
    {
        ChangeColor();
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
    }

    private Color GetRandomColor()
    {
        int randomIndex = UnityEngine.Random.Range(0, _colors.Length);

        return _colors[randomIndex];
    }
}
