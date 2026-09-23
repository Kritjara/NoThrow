using System.Diagnostics.CodeAnalysis;

namespace NoThrow;

/// <summary>
/// Представляет результат выполнения операции, который может быть успешным или завершиться ошибкой.
/// </summary>
/// <typeparam name="T">Тип возвращаемого значения при успешном выполнении операции.</typeparam>
/// <typeparam name="E">Тип информации об ошибке, если операция завершилась неудачей.</typeparam>
public interface IResult<T, E>
{
    /// <summary>
    /// Возвращает результат операции, если она выполнена успешно.
    /// В случае ошибки возвращает <see langword="null"/>.
    /// </summary>
    T? Value { get; }

    /// <summary>
    /// Возвращает информацию об ошибке, если операция завершилась неудачей.
    /// В случае успеха возвращает <see langword="null"/>.
    /// </summary>
    E? Error { get; }


    /// <summary>
    /// Возвращает <see langword="true"/>, если операция выполнена успешно.
    /// </summary>
    /// <remarks>
    /// Если свойство возвращает <see langword="true"/>, то
    /// <list>
    ///   <item>- свойство <see cref="Value"/> гарантированно не равно <see langword="null"/>;</item>
    ///   <item>- свойство <see cref="Error"/> гарантированно равно <see langword="null"/>.</item>
    /// </list>
    /// </remarks>
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
    bool IsSuccess { get; }

    /// <summary>
    /// Возвращает <see langword="true"/>, если операция завершилась ошибкой.
    /// </summary>
    /// <remarks>
    /// Если свойство возвращает <see langword="true"/>, то
    /// <list>
    ///   <item>- свойство <see cref="Value"/> гарантированно равно <see langword="null"/>;</item>
    ///   <item>- свойство <see cref="Error"/> гарантированно не равно <see langword="null"/>.</item>
    /// </list>
    /// </remarks>
    [MemberNotNullWhen(false, nameof(Value))]
    [MemberNotNullWhen(true, nameof(Error))]
    bool IsFailure { get; }
}


/// <inheritdoc cref="IResult{T,E}"/>
public class Result<T, E> : IResult<T, E>
{
    internal Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    internal Result(E error)
    {
        Error = error;
        IsSuccess = false;
    }

    /// <inheritdoc cref="IResult{T,E}.Value"/>
    public T? Value { get; }

    /// <inheritdoc cref="IResult{T,E}.Error"/>
    public E? Error { get; }

    /// <inheritdoc cref="IResult{T,E}.IsSuccess"/>
    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess { get; }

    /// <inheritdoc cref="IResult{T,E}.IsFailure"/>
    [MemberNotNullWhen(false, nameof(Value))]
    [MemberNotNullWhen(true, nameof(Error))]
    public bool IsFailure => !IsSuccess;

    public static implicit operator Result<T, E>(T value)
    {
        return Result.Success<T, E>(value);
    }
    public static implicit operator Result<T, E>(E error)
    {
        return Result.Failure<T, E>(error);
    }

    public static implicit operator Result<T>(Result<T, E> result)
    {
        if (result.IsSuccess)
            return Result.Success(result.Value);
        else
            return Result.Failure<T>();
    }

    public static implicit operator UnitResult<E>(Result<T, E> result)
    {
        if (result.IsSuccess)
            return UnitResult.Success<E>();
        else
            return UnitResult.Failure(result.Error);
    }
}