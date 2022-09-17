using UnityEngine;
using Zenject;

public class ParticleControllerInstaller : MonoInstaller
{
    [SerializeField] private ParticleController particleController;

    public override void InstallBindings()
    {
        Container.Bind<ParticleController>().FromInstance(particleController).AsSingle().NonLazy();
    }
}