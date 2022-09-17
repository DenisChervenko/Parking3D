using UnityEngine;
using Zenject;

public class CoinCollectLogicInstaller : MonoInstaller
{
    [SerializeField] private CoinCollectLogic coinCollectLogic;

    public override void InstallBindings()
    {
        Container.Bind<CoinCollectLogic>().FromInstance(coinCollectLogic).AsSingle().NonLazy();
    }
}