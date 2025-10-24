
using Zenject;
using UnityEngine;
using Game.EntryPoint;
using Game.LoaderScene;
using Cysharp.Threading.Tasks;

namespace Assets.Game.Boot
{
    namespace Assets.Game.Boot
    {
        public class BootLoader : MonoBehaviour
        {
            private ISceneLoader _sceneLoader;

            [Inject]
            public void Construct(ISceneLoader sceneLoader)
            {
                _sceneLoader = sceneLoader;
            }

            private void Start()
            {
                _sceneLoader.LoadSceneAsync(Scenes.MAINMENU).Forget();
            }
        }
    }
}
