using System.Collections;
using UnityEngine;
using Zenject;

public class Generator : MonoBehaviour
{
    [SerializeField] private Transform _leftBorderPoint;
    [SerializeField] private Transform _rightBorderPoint;

    [SerializeField] private GeneratorConfig _generatorConfig;

    [SerializeField] private Figure[] _figures;

    private ColorConfig _colorConfig;

    [Inject]
    private void Initialize(ColorConfig colorConfig)
    {
        _colorConfig = colorConfig;
    }

    private void Start()
    {
        GenerateRandomFigure();
    }

    private void GenerateRandomFigure()
    {
        Vector3 randomSpawnPosition = GetRandomPositionBetwenPoints();

        Figure randomFigure = GetRandomFigure();

        GameObject figure = Instantiate(randomFigure.gameObject, randomSpawnPosition, Quaternion.identity);
        figure.GetComponent<Figure>()?.Initialize(_colorConfig);

        StartCoroutine(RegenerateFigure());
    }

    private Vector3 GetRandomPositionBetwenPoints()
    {
        Vector3 randomPosition = new Vector3()
        {
            x = Random.Range(_leftBorderPoint.position.x, _rightBorderPoint.position.x), 
            y = Random.Range(_leftBorderPoint.position.y, _rightBorderPoint.position.y), 
            z = Random.Range(_leftBorderPoint.position.z, _rightBorderPoint.position.z), 
        };

        return randomPosition;
    }

    private Figure GetRandomFigure()
    {
        int randomIndex = Random.Range(0, _figures.Length);

        return _figures[randomIndex];
    }

    private IEnumerator RegenerateFigure()
    {
        yield return new WaitForSeconds(_generatorConfig.GenerationCooldown);

        GenerateRandomFigure();
    }
}
