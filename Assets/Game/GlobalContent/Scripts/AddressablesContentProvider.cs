
using UnityEngine;
using Game.Services;
using Game.ContentService;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Game.GlobalContent
{
    public class AddressablesContentProvider : IContentProvider, IService<IContentProvider>
    {
        public async UniTask<T> Load<T>(string key) where T : class
        {
            var handle = Addressables.LoadAssetAsync<T>(key);
            await handle.ToUniTask();
            return handle.Result;
        }

        public async UniTask<GameObject> Instantiate(string key)
        {
            var handle = Addressables.InstantiateAsync(key);
            await handle.ToUniTask();
            return handle.Result;
        }

        public void Release<T>(T obj) => Addressables.Release(obj);
    }
}
