using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace Arknights.BaseSimulator
{
    public static class Extensions
    {
        public static MarkupString ToMarkup(this string str) =>
            new MarkupString(str);

        public static (MarkupString, MarkupString) ToMarkup(this (object, object) tuple) =>
            (tuple.Item1.ToString().ToMarkup(), tuple.Item2.ToString().ToMarkup());

        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> src)
        {
            return src.SelectMany(inner => inner.Select((item, index) => new { item, index }))
                      .GroupBy(i => i.index, i => i.item)
                      .Select(g => g.ToList())
                      .ToList();
        }
    }
}
