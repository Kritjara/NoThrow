namespace NoThrow;

/// <summary>
/// Фабричный класс для создания экземпляров результатов выполнения операций.
/// </summary>
public static class UnitResult
{
    /// <summary>
    /// Создаёт <see cref="UnitResult{E}"/> с успехом.
    /// </summary>
    /// <typeparam name="E">Тип информации об ошибке.</typeparam>
    /// <param name="value">Значение результата.</param>
    /// <returns>Экземпляр <see cref="UnitResult{E}"/> со статусом успеха.</returns>
    public static UnitResult<E> Success<E>()
    {
        return new UnitResult<E>(default, true);
    }

    /// <summary>
    /// Создаёт <see cref="UnitResult{E}"/> с указанной информацией об ошибке.
    /// </summary>
    /// <typeparam name="E">Тип информации об ошибке.</typeparam>
    /// <param name="error">Информация об ошибке.</param>
    /// <returns>Экземпляр <see cref="UnitResult{E}"/> со статусом ошибки.</returns>
    public static UnitResult<E> Failure<E>(E error)
    {
        return new UnitResult<E>(error, false);
    }
}