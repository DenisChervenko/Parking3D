using UnityEngine;
using Zenject;

public class AddBalanceInstaller : MonoInstaller
{
    [SerializeField] private AddBalance addBalance;

    public override void InstallBindings()
    {
        Container.Bind<AddBalance>().FromInstance(addBalance).AsSingle().NonLazy();
    }
}