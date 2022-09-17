using UnityEngine;
using Zenject;

public class CarBuyinInstaller : MonoInstaller
{
    [SerializeField] private CarBuying carBuying;

    public override void InstallBindings()
    {
        Container.Bind<CarBuying>().FromInstance(carBuying).AsSingle().NonLazy();
    }
}