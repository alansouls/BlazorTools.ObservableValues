using BObservable.Values;

namespace BObservable.Services;

internal interface IInternalValueManager : IValueManager
{
    void SetValue<T>(string key, ObservableValue<T> value) where T : notnull;
}