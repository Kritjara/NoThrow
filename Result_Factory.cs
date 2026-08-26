namespace NoThrow;

/// <summary>
/// Фабричный класс для создания экземпляров результатов выполнения операций.
/// </summary>
public static class Result
{
    /// <summary>
    /// Создаёт <see cref="Result{T}"/> с успехом и с указанным значением.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
    /// <param name="value">Значение результата.</param>
    /// <returns>Экземпляр <see cref="Result{T}"/> со статусом успеха.</returns>
    public static Result<T> Success<T>(T value)
    {
        return new Result<T>(value, true);
    }

    /// <summary>
    /// Создаёт <see cref="Result{T}"/>, указывающий на ошибку выполнения операции.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
    /// <returns>Экземпляр <see cref="Result{T}"/> со статусом ошибки.</returns>
    public static Result<T> Failure<T>()
    {
        return new Result<T>(default, false);
    }

    /// <summary>
    /// Создаёт <see cref="Result{T, E}"/> с успехом и с указанным значением.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
    /// <typeparam name="E">Тип информации об ошибке.</typeparam>
    /// <param name="value">Значение результата.</param>
    /// <returns>Экземпляр <see cref="Result{T, E}"/> со статусом успеха.</returns>
    public static Result<T, E> Success<T, E>(T value)
    {
        return new Result<T, E>(value);
    }

    /// <summary>
    /// Создаёт <see cref="Result{T, E}"/> с указанной информацией об ошибке.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения.</typeparam>
    /// <typeparam name="E">Тип информации об ошибке.</typeparam>
    /// <param name="error">Информация об ошибке.</param>
    /// <returns>Экземпляр <see cref="Result{T, E}"/> со статусом ошибки.</returns>
    public static Result<T, E> Failure<T, E>(E error)
    {
        return new Result<T, E>(error);
    }
}