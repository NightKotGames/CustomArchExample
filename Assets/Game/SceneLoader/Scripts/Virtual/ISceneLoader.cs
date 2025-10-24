
using Game.Services;
using Cysharp.Threading.Tasks;

namespace Game.LoaderScene
{
    public interface ISceneLoader : IService<ISceneLoader>
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}