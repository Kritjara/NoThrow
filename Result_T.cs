using System.Diagnostics.CodeAnalysis;

namespace NoThrow;

/// <summary>
/// Представляет результат выполнения операции, который может быть успешным или завершиться ошибкой.
/// </summary>
/// <typeparam name="T">
/// Тип возвращаемого значения при успешном выполнении операции.
/// </typeparam>
public interface IResult<T>
{
    /// <summary>
    /// Возвращает результат операции, если она выполнена успешно.
    /// В случае ошибки возвращает <see langword="null"/>.
    /// </summary>
    T? Value { get; }

    /// <summary>
    /// Возвращает <see langword="true"/>, если операция выполнена успешно.
    /// </summary>
    /// <remarks>
    /// Если свойство возвращает <see langword="true"/>, свойство <see cref="Value"/> гарантированно не равно <see langword="null"/>.
    /// </remarks>
    [MemberNotNullWhen(true, nameof(Value))]
    bool IsSuccess { get; }

    /// <summary>
    /// Возвращает <see langword="true"/>, если операция завершилась ошибкой.
    /// </summary>
    /// <remarks>
    /// Если свойство возвращает <see langword="true"/>, свойство <see cref="Value"/> гарантированно равно <see langword="null"/>.
    /// </remarks>
    [MemberNotNullWhen(false, nameof(Value))]
    bool IsFailure { get; }
}

/// <inheritdoc cref="IResult{T}"/>
public class Result<T> : IResult<T>
{ 
    internal Result(T? value, bool isSuccess)
    {
        Value = value;
        IsSuccess = isSuccess;
    }


    /// <inheritdoc cref="IResult{T}.Value"/>
    public T? Value { get; }

    /// <inheritdoc cref="IResult{T}.IsSuccess"/>
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess { get; }

    /// <inheritdoc cref="IResult{T}.IsFailure"/>
    [MemberNotNullWhen(false, nameof(Value))]
    public bool IsFailure => !IsSuccess;

    public static implicit operator Result<T>(T value)
    {
        return Result.Success(value);
    }

}

