using UnityEngine;
using Zenject;

public class CarControllerInstaller : MonoInstaller
{
    [SerializeField] private CarController carController;

    public override void InstallBindings()
    {
        Container.Bind<CarController>().FromInstance(carController).AsSingle().NonLazy();
    }
}