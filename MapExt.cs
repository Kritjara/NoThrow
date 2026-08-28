namespace NoThrow;

public static class MapExt
{

    public static IResult<K> Map<T, K>(this IResult<T> target, Func<T, K> valueFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success(valueFactory(target.Value));
        }
        return Result.Failure<K>();
    }

    public static IResult<K> Map<T, K>(this IResult<T> target, Func<K> valueFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success(valueFactory());
        }
        return Result.Failure<K>();
    }

    public static IResult<K, E> Map<T, K, E>(this IResult<T, E> target, Func<T, K> valueFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success<K, E>(valueFactory(target.Value));
        }
        return Result.Failure<K, E>(target.Error);
    }

    public static IResult<K, E> Map<T, K, E>(this IResult<T, E> target, Func<K> valueFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success<K, E>(valueFactory());
        }
        return Result.Failure<K, E>(target.Error);
    }

    public static IResult<K, T> Map<T, K>(this IUnitResult<T> target, Func<K> valueFactory)
    {
        if (target.IsSuccess)
        {
            return Result.Success<K, T>(valueFactory());
        }
        return Result.Failure<K, T>(target.Error);
    }
}
