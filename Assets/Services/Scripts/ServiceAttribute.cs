
using System;

namespace Game.Services
{
    /// <summary>
    /// Атрибут, которым помечаются классы-сервисы для автоматической регистрации.
    /// Указывает источник сервиса (класс, префаб, сцена) и при необходимости путь к префабу.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]

    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// Источник, из которого будет зарегистрирован сервис.
        /// </summary>
        public SourceServiceType Source { get; }

        /// <summary>
        /// Путь к префабу в папке Resources (если <see cref="Source"/> = Prefab).
        /// </summary>
        public string PrefabPath { get; }

        /// <summary>
        /// Создаёт новый атрибут для пометки сервиса.
        /// </summary>
        /// <param name="source">Источник сервиса (Class, Prefab, Scene).</param>
        /// <param name="prefabPath">
        /// Путь к префабу в Resources (только если <paramref name="source"/> = Prefab).
        /// </param>
        public ServiceAttribute(SourceServiceType source, string prefabPath = null)
        {
            Source = source;
            PrefabPath = prefabPath;
        }
    }
}
