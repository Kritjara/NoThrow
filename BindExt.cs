namespace NoThrow;

public static class BindExt
{

    #region [ Result<T> ]

    public static IResult<T> Bind<T>(this IResult<T> target, Func<T, IResult<T>> func)
    {
        if (target.IsSuccess)
        {
            return func(target.Value);
        }
        return target;
    }

    public static IResult<K> Bind<T, K>(this IResult<T> target, Func<T, IResult<K>> func)
    {
        if (target.IsSuccess)
        {
            return func(target.Value);
        }
        return Result.Failure<K>();
    }

    #endregion

    #region [ UnitResult<E> ]

    public static IUnitResult<E> Bind<E>(this IUnitResult<E> result, Func<IUnitResult<E>> func)
    {
        if (result.IsSuccess)
        {
            return func();
        }
        return result;
    }

    public static IResult<T, E> Bind<T, E>(this IUnitResult<E> target, Func<IResult<T, E>> func)
    {
        if (target.IsSuccess)
        {
            return func();
        }
        return Result.Failure<T, E>(target.Error);
    }

    public static IResult<K, E> Bind<T, K, E>(this IUnitResult<E> target, Func<IResult<K, E>> func)
    {
        if (target.IsSuccess)
        {
            return func();
        }
        return Result.Failure<K, E>(target.Error);
    }


    #endregion

    #region [ Result<T, E> ]

    public static IResult<T, E> Bind<T, E>(this IResult<T, E> result, Func<T, IResult<T, E>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value);
        }
        return result;
    }

    public static IResult<K, E> Bind<T, K, E>(this IResult<T, E> result, Func<T, IResult<K, E>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value);
        }
        return Result.Failure<K, E>(result.Error);
    }

    public static IUnitResult<E> Bind<T, E>(this IResult<T, E> result, Func<T, IUnitResult<E>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value);
        }
        return UnitResult.Failure(result.Error);
    }

    #endregion

}
