
using Zenject;
//using Game.UI;
//using Game.State;
using Game.Settings;
using Game.LoaderScene;

namespace Game.Boot
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // === Загрузчик Сцен ===
            Container.Bind<ISceneLoader>()
            .To<SceneLoader>()
            .FromNewComponentOnNewGameObject()
            .AsSingle()
            .NonLazy();

            // === Глобальные сервисы ===
            Container.Bind<ISettingsProvider>()
                .To<JsonSettingsProvider>()
                .AsSingle();


            //Container.Bind<IGameStateProvider>()
            //    .To<JsonGameStateProvider>()
            //    .AsSingle();

            //// === UI Root ===
            //Container.Bind<UIRootView>()
            //    .FromComponentInNewPrefabResource("UIRoot")
            //    .AsSingle()
            //    .NonLazy();

            //// === Главный сценарий Boot ===
            //Container.Bind<BootEntry>()
            //    .AsSingle()
            //    .NonLazy();
        }
    }
}