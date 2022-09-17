using UnityEngine;
using Zenject;

public class DieScreenInstaller : MonoInstaller
{
    [SerializeField] private DieScreen dieScreen;

    public override void InstallBindings()
    {
        Container.Bind<DieScreen>().FromInstance(dieScreen).AsSingle().NonLazy();
    }
}