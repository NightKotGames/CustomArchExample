
using System;
using Zenject;
using System.Linq;
using Game.Services;
using System.Reflection;

namespace Game.Boot
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Берём все типы из текущей сборки (можно расширить на другие)
            var assembly = Assembly.GetExecutingAssembly();

            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsAbstract == false && t.IsInterface == false)
                .Select(t => new
                {
                    Impl = t,
                    ServiceInterface = t.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType &&
                                             i.GetGenericTypeDefinition() == typeof(IService<>))
                })
                .Where(x => x.ServiceInterface != null);

            foreach (var s in serviceTypes)
            {
                // Достаём реальный контракт (например, ISceneLoader)
                var iface = s.ServiceInterface.GetGenericArguments()[0];

                // Жёсткая проверка: контракт должен быть интерфейсом
                if (iface.IsInterface == false)
                {
                    throw new Exception(
                        $"Ошибка регистрации: {s.Impl.Name} указывает {iface.Name}, но это не интерфейс!");
                }

                // Регистрируем: ISceneLoader -> SceneLoader
                Container.Bind(iface).To(s.Impl).AsSingle().NonLazy();
            }
        }
    }
}
