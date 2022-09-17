using UnityEngine;
using Zenject;

public class TimeScaleControllerInstaller : MonoInstaller
{
    [SerializeField] private TimeScaleController timeScaleController;

    public override void InstallBindings()
    {
        Container.Bind<TimeScaleController>().FromInstance(timeScaleController).AsSingle().NonLazy();
    }
}