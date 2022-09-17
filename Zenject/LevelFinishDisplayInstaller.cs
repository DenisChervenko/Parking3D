using UnityEngine;
using Zenject;

public class LevelFinishDisplayInstaller : MonoInstaller
{
    [SerializeField] private LevelFinishDisplay levelFinishDisplay;

    public override void InstallBindings()
    {
        Container.Bind<LevelFinishDisplay>().FromInstance(levelFinishDisplay).AsSingle().NonLazy();
    }
}