
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.LoaderScene
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);
            await asyncOp.ToUniTask();
        }
    }
}