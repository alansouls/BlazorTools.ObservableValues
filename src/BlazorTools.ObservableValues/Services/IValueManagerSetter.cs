using BlazorTools.ObservableValues.Values;

namespace BlazorTools.ObservableValues.Services;

public interface IValueManagerSetter : IValueManager
{
    void SetValue<T>(string key, ObservableValue<T> value);
}