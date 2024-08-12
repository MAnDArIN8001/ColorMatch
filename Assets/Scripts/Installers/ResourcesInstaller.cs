using UnityEngine;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{
    [SerializeField] private string _colorConfigPath;

    public override void InstallBindings()
    {
        Container.Bind<ColorConfig>().FromResources(_colorConfigPath);
    }
}
