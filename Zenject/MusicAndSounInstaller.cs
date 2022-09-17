using UnityEngine;
using Zenject;

public class MusicAndSounInstaller : MonoInstaller
{
    [SerializeField] private MusicSound musicSound;

    public override void InstallBindings()
    {
        Container.Bind<MusicSound>().FromInstance(musicSound).AsSingle().NonLazy();
    }
}