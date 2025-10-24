
using Game.Services;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.LoaderScene
{
    public class SceneLoader : ISceneLoader, IService<ISceneLoader>
    {
        public async UniTask LoadSceneAsync(string sceneName)
        {
            var asyncOp = SceneManager.LoadSceneAsync(sceneName);
            await asyncOp.ToUniTask();
        }
    }
}