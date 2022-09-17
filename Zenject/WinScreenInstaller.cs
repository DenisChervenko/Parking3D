using UnityEngine;
using Zenject;

public class WinScreenInstaller : MonoInstaller
{
    [SerializeField] private WinScreen winScreen;

    public override void InstallBindings()
    {
        Container.Bind<WinScreen>().FromInstance(winScreen).AsSingle().NonLazy();
    }
}