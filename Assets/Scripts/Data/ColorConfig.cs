using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "Gameplay/new ColorConfig")]
public class ColorConfig : ScriptableObject
{
    [SerializeField] private Color[] _colors;

    public Color[] Colors => _colors;
}
