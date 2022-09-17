using UnityEngine;
using Zenject;

public class BalanceRefresherInstaller : MonoInstaller
{
    [SerializeField] private BalanceRefresher balanceRefresher;

    public override void InstallBindings()
    {
        Container.Bind<BalanceRefresher>().FromInstance(balanceRefresher).AsSingle().NonLazy();
    }
}