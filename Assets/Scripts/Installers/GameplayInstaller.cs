using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private ScoreController _scoreController;

    [SerializeField] private SceneManager _scenManager;

    [SerializeField] private LevelManager _levelManager;

    public override void InstallBindings()
    {
        Container.Bind<MainInput>().FromNew().AsSingle();
        Container.Bind<ScoreController>().FromInstance(_scoreController);
        Container.Bind<SceneManager>().FromInstance(_scenManager);
        Container.Bind<LevelManager>().FromInstance(_levelManager);
    }
}
