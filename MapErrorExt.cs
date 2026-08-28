namespace NoThrow;

public static class MapErrorExt
{
 
    public static IResult<T, K> MapError<T, K>(this IResult<T> target, Func<K> errorFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success<T, K>(target.Value);
        }
        return Result.Failure<T, K>(errorFactory());
    }

    public static IResult<T, K> MapError<T, E, K>(this IResult<T, E> target, Func<E, K> errorFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success<T, K>(target.Value);
        }
        return Result.Failure<T, K>(errorFactory(target.Error));
    }

    public static IResult<T, K> MapError<T, E, K>(this IResult<T, E> target, Func<K> errorFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success<T, K>(target.Value);
        }
        return Result.Failure<T, K>(errorFactory());
    }

    public static IUnitResult<K> MapError<E, K>(this IUnitResult<E> target, Func<E, K> errorFactory)
    {
        if (target.IsSuccess)
        {
            return UnitResult.Success<K>();
        }
        return UnitResult.Failure<K>(errorFactory(target.Error));
    }

    public static IUnitResult<K> MapError<E, K>(this IUnitResult<E> target, Func<K> errorFactory)
    {
        if (target.IsSuccess)
        {
            return UnitResult.Success<K>();
        }
        return UnitResult.Failure<K>(errorFactory());
    }
}
