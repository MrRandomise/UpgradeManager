using Game.Gameplay.Player;
using Game.CoreUpgrade;
using Zenject;

namespace Game.Installer
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyStorage>().AsSingle().NonLazy();
            Container.Bind<UpgradesManager>().AsSingle().NonLazy();
        }
    }
}
