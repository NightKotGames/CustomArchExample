
using UnityEngine;
using Game.LoaderScene;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.EntryPoint
{
    public class GameEntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            Application.targetFrameRate = 60;

#if !UNITY_EDITOR && UNITY_ANDROID || UNITY_IOS  

            // Отключаем сон экрана на  Мобильных устройствах
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

#endif
            Application.runInBackground = true;

            Debug.Log("=== GameEntryPoint started ===");

            // Проверяем, что активная сцена — Boot
            var activeScene = SceneManager.GetActiveScene();
            if (activeScene.name != Scenes.BOOT)
            {
                Debug.LogWarning($"Game started from scene '{activeScene.name}'. Switching to Boot...");
                var loader = new SceneLoader(); // или получить через Zenject
                loader.LoadSceneAsync(Scenes.BOOT).Forget();
            }
        }
    }
}
