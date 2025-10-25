
namespace Game.Services
{
    /// <summary>
    /// Определяет источник, из которого должен быть зарегистрирован сервис.
    /// Используется в <see cref="ServiceAttribute"/> для автоматической регистрации.
    /// </summary>
    public enum SourceServiceType
    {
        /// <summary>
        /// Значение по умолчанию. Не используется для реальной регистрации.
        /// </summary>
        None = 0,

        /// <summary>
        /// Сервис реализован как обычный класс (без MonoBehaviour).
        /// Регистрируется через <c>Bind(contract).To(impl).AsSingle()</c>.
        /// </summary>
        Class,

        /// <summary>
        /// Сервис реализован как MonoBehaviour и должен быть создан из префаба.
        /// Префаб указывается в <see cref="ServiceAttribute.PrefabPath"/>.
        /// </summary>
        Prefab,

        /// <summary>
        /// Сервис реализован как MonoBehaviour и уже присутствует в сцене.
        /// Регистрируется через <c>FromComponentInHierarchy()</c>.
        /// </summary>
        Scene
    }
}
