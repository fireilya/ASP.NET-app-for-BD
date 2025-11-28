using System;
using System.Collections.Generic;

namespace Core.Common.Linq;

public static class LinqExtensions
{
    public static void Foreach<TSource>(this IEnumerable<TSource> collection, Action<TSource> action)
    {
        foreach (var source in collection)
        {
            action(source);
        }
    }
}