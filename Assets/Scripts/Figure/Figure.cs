using System;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public event Action OnPickedUp;

    [SerializeField] private int _collectScore;

    [SerializeField] private MeshRenderer _modelRenderer;

    public int CollectScore => _collectScore;

    public Color CurrentCollor => _modelRenderer.material.color;

    public void Initialize(ColorConfig colorConfig)
    {
        int randomColorIndex = UnityEngine.Random.Range(0, colorConfig.Colors.Length);

        Color randomColor = colorConfig.Colors[randomColorIndex];

        _modelRenderer.material.color = randomColor;
    }

    public void PickUp()
    {
        OnPickedUp?.Invoke();

        Destroy(gameObject);
    }
}
