
namespace Game.Services
{
    /// <summary>
    /// Маркерный интерфейс для сервисов.
    /// Используется для того, чтобы <c>GlobalInstaller</c> мог автоматически
    /// находить и регистрировать реализации.
    /// </summary>
    /// <typeparam name="T">
    /// Контракт (интерфейс), который реализует данный сервис.
    /// </typeparam>
    public interface IService<T> where T : class { }
}