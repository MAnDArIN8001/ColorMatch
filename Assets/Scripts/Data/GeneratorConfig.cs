using UnityEngine;

[CreateAssetMenu(fileName = "GeneratorConfig", menuName = "Gameplay/new GeneratorConfig")]
public class GeneratorConfig : ScriptableObject
{
    [SerializeField] private float _generationCooldown;

    public float GenerationCooldown => _generationCooldown;
}
