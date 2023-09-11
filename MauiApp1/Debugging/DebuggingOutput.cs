using MauiApp1.Views;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MauiApp1.Debugging;

public static class DebuggingOutput
{
    public static void Log(Type type, string additional = null, [CallerMemberName] string method = null)
    {
#if !DEBUG
        return;
#endif
        var navigationStack = Shell.Current?.Navigation.NavigationStack
            ?.Select((x, i) =>
            {
                if (x is not IContentPage page)
                {
                    return $"{i}:NULL";
                }

                var route = (string)page.GetType().GetProperty($"{typeof(IContentPage).FullName}.{nameof(IContentPage.PageRoute)}", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

                return $"{i}:{route}";
            }) ?? Enumerable.Empty<string>();

        Debug.WriteLine($"{type.Name}.{method} | Stack: {string.Join(", ", navigationStack)}{(!string.IsNullOrEmpty(additional) ? $" | Additional: {additional}" : "")}", "DEBUG");
    }
}