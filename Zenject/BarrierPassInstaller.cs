using UnityEngine;
using Zenject;

public class BarrierPassInstaller : MonoInstaller
{
    [SerializeField] private BarrierPass barrierPass;

    public override void InstallBindings()
    {
        Container.Bind<BarrierPass>().FromInstance(barrierPass).AsSingle().NonLazy();
    }
}