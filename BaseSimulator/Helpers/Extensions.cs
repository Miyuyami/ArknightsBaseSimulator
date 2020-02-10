using Microsoft.AspNetCore.Components;

namespace Arknights.BaseSimulator
{
    public static class Extensions
    {
        public static MarkupString ToMarkup(this string str) =>
            new MarkupString(str);

        public static (MarkupString, MarkupString) ToMarkup(this (object, object) tuple) =>
            (tuple.Item1.ToString().ToMarkup(), tuple.Item2.ToString().ToMarkup());
    }
}
