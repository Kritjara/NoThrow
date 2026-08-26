using System.Diagnostics.CodeAnalysis;

namespace NoThrow;

/// <summary>
/// Представляет результат выполнения операции, который может быть успешным или завершиться ошибкой.
/// </summary>
/// <typeparam name="E">Тип информации об ошибке, если операция завершилась неудачей.</typeparam>
public interface IUnitResult<E>
{  
    /// <summary>
    /// Возвращает информацию об ошибке, если операция завершилась неудачей.
    /// В случае успеха возвращает <see langword="null"/>.
    /// </summary>
    E? Error { get; }

    /// <summary>
    /// Возвращает <see langword="true"/>, если операция выполнена успешно.
    /// </summary>
    /// <remarks>
    /// Если свойство возвращает <see langword="true"/>, свойство <see cref="Error"/> гарантированно равно <see langword="null"/>. 
    /// </remarks>
    [MemberNotNullWhen(false, nameof(Error))]
    bool IsSuccess { get; }

    /// <summary>
    /// Возвращает <see langword="true"/>, если операция завершилась ошибкой.
    /// </summary>
    /// <remarks>
    /// Если свойство возвращает <see langword="true"/>, свойство <see cref="Error"/> гарантированно не равно <see langword="null"/>.
    /// </remarks>
    [MemberNotNullWhen(true, nameof(Error))]
    bool IsFailure { get; }
}

/// <inheritdoc cref="IUnitResult{E}"/>
public class UnitResult<E> : IUnitResult<E>
{  
    internal UnitResult(E? error, bool isSuccess)
    {
        Error = error;
        IsSuccess = isSuccess;
    }

    /// <inheritdoc/>
    public E? Error{ get; }

    /// <inheritdoc/>
    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess { get; }

    /// <inheritdoc/>
    [MemberNotNullWhen(true, nameof(Error))]
    public bool IsFailure => !IsSuccess;
}
