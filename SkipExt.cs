namespace NoThrow;

public static class SkipExt
{
    public static IUnitResult<E> SkipValue<T, E>(this IResult<T, E> result)
    {
        if (result.IsSuccess)
        {
            return UnitResult.Success<E>();
        }

        return UnitResult.Failure(result.Error);
    }

    public static IResult<T> SkipError<T, E>(this IResult<T, E> result)
    {
        if (result.IsSuccess)
        {
            return Result.Success(result.Value);
        }

        return Result.Failure<T>();
    }
}
