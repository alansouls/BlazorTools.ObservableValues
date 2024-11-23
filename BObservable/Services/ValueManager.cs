using BObservable.Values;

namespace BObservable.Services;

public class ValueManager : IValueManager, IInternalValueManager
{
    private readonly Dictionary<string, object> _valueBag = [];
    
    private readonly Dictionary<string, Action<object>?> _valueChangedEvents = [];

    void IInternalValueManager.SetValue<T>(string key, ObservableValue<T> value)
    {
        _valueBag[key] = value;
        _valueChangedEvents.GetValueOrDefault(key)?.Invoke(value);
    }

    public ObservableValue<T>? GetValue<T>(string key)
    {
        return _valueBag.GetValueOrDefault(key) as ObservableValue<T>;
    }

    public void ObserveValue(string key, Action<object> onChanged)
    {
        if (!_valueChangedEvents.TryAdd(key, onChanged))
        {
            _valueChangedEvents[key] += onChanged;
        }
    }
    
    public void StopObservingValue(string key, Action<object> onChanged)
    {
        if (_valueChangedEvents.TryGetValue(key, out var action))
        {
            action -= onChanged;
            _valueChangedEvents[key] = action;
        }
    }
}