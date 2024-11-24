using BlazorTools.ObservableValues.Values;

namespace BlazorTools.ObservableValues.Services;

public interface IValueManager
{
    ObservableValue<T>? GetValue<T>(string key);
    void ObserveValue(string key, Action<object> onChanged);
    void StopObservingValue(string key, Action<object> onChanged);
}