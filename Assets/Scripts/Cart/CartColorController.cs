using UnityEngine;

public class CartColorController : MonoBehaviour
{
    [SerializeField] private float _minChangeTime;
    [SerializeField] private float _maxChangeTime;

    [SerializeField] private Color[] _colors;

    private Color _currentCollor;

    [SerializeField] private MeshRenderer _modelRenderer;

    private void Awake()
    {
        
    }
}
