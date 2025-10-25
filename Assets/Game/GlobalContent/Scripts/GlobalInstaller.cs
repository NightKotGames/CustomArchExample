
using System;
using Zenject;
using UnityEngine;
using System.Linq;
using Game.Services;
using System.Reflection;

public class GlobalInstaller : MonoInstaller
{
    // Optional: root for Resources lookups, can be overridden per-attribute via PrefabPath
    [SerializeField] private string _defaultResourcesRoot = "Prefabs";

    public override void InstallBindings()
    {
        // Choose assemblies you want to scan.
        // In most Unity setups, using the assembly of GlobalInstaller is sufficient,
        // or use AppDomain.CurrentDomain.GetAssemblies() and filter by name.
        var assembliesToScan = new[]
        {
            Assembly.GetExecutingAssembly()
        };

        foreach (var assembly in assembliesToScan)
        {
            BindAttributedServices(assembly);
        }
    }

    private void BindAttributedServices(Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .ToArray();

        foreach (var impl in types)
        {
            // Find IService<TContract> implemented by impl
            var serviceInterface = impl.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType &&
                                     i.GetGenericTypeDefinition() == typeof(IService<>));
            if (serviceInterface == null)
                continue;

            var contract = serviceInterface.GetGenericArguments()[0];

            // Read ServiceAttribute
            var attr = impl.GetCustomAttribute<ServiceAttribute>();
            if (attr == null)
                continue;

            switch (attr.Source)
            {
                case SourceServiceType.Class:
                    // Pure class service
                    Container.Bind(contract)
                             .To(impl)
                             .AsSingle()
                             .NonLazy();
                    break;

                case SourceServiceType.Prefab:
                    {
                        // MonoBehaviour service loaded and instantiated from Resources
                        var path = ResolvePrefabPath(attr.PrefabPath);
                        var prefab = Resources.Load<GameObject>(path);

                        if (prefab == null)
                            throw new Exception($"GlobalInstaller: Prefab not found at Resources path '{path}' for {impl.Name}");

                        // Bind contract using component from new prefab instance
                        Container.Bind(contract)
                                 .FromComponentInNewPrefab(prefab)
                                 .AsSingle()
                                 .NonLazy();
                        break;
                    }

                case SourceServiceType.Scene:
                    // MonoBehaviour service that already exists in the scene hierarchy
                    Container.Bind(contract)
                             .FromComponentInHierarchy()
                             .AsSingle()
                             .NonLazy();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(attr.Source), $"Unsupported ServiceSource '{attr.Source}' in {impl.Name}");
            }
        }
    }

    private string ResolvePrefabPath(string explicitPath)
    {
        // If attribute specified a full Resources path, use it; otherwise, combine with default root
        if (!string.IsNullOrEmpty(explicitPath))
            return explicitPath;

        // Fall back to a sensible default folder if none provided
        // e.g., "Prefabs/UIRoot"
        return _defaultResourcesRoot;
    }
}
