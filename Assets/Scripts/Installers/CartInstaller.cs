using UnityEngine;
using Zenject;

public class CartInstaller : MonoInstaller
{
    public Quaternion _instanceRotation;

    public Transform _instancePoint;

    public GameObject _cartPrefab;

    public override void InstallBindings()
    {
        GameObject cartInstance = Container.InstantiatePrefab(_cartPrefab, _instancePoint.position, _instanceRotation, null);

        Container.Bind<CartPicker>().FromInstance(cartInstance.GetComponent<CartPicker>());
    }
}
