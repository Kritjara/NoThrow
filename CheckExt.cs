namespace NoThrow;

public static class CheckExt
{
    #region [ Result<T> ]

    public static IResult<T> Check<T, K>(this IResult<T> result, Func<T, IResult<K>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value).Map(_ => result.Value);
        }

        return result;
    }

    public static IResult<T> Check<T, K, E>(this IResult<T> result, Func<T, IResult<K, E>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value).Map(_ => result.Value).SkipError();
        }

        return result;
    }

    #endregion

    #region [ UnitResult<E> ]

    public static IUnitResult<E> Check<E>(this IUnitResult<E> result, Func<IUnitResult<E>> func)
    {
        if (result.IsSuccess)
        {
            return func();
        }
        return result;
    }

    #endregion

    #region [ Result<T, E> ]

    public static IResult<T, E> Check<T, K, E>(this IResult<T, E> result, Func<T, IResult<K, E>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value).Map(_ => result.Value);
        }
        return result;
    }


    public static IResult<T, E> Check<T, E>(this IResult<T, E> result, Func<T, IUnitResult<E>> func)
    {
        if (result.IsSuccess)
        {
            return func(result.Value).Map(() => result.Value);
        }
        return result;
    }

    #endregion

}