
using UnityEngine;
using Game.Services;
using Cysharp.Threading.Tasks;

namespace Game.ContentService
{
    public interface IContentProvider : IService<IContentProvider>
    {
        UniTask<T> Load<T>(string key) where T : class;
        UniTask<GameObject> Instantiate(string key);
        void Release<T>(T obj);
    }
}