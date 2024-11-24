namespace BlazorTools.ObservableValues.Services;

public static class ValueManagerResolver
{
    internal static IValueManagerSetter InternalValueManager { get; } = new ValueManager();
    public static IValueManager ValueManager => InternalValueManager;
}
