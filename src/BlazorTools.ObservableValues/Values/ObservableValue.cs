using BlazorTools.ObservableValues.Services;

namespace BlazorTools.ObservableValues.Values;

public class ObservableValue<T>
{
    private readonly IValueManagerSetter _valueManager;

    public ObservableValue(string key, IValueManagerSetter valueManager)
    {
        _valueManager = valueManager;
        Key = key;
    }

    public ObservableValue(string key) : this(key, ValueManagerResolver.InternalValueManager)
    {
    }

    public T? Value
    {
        get => field;
        set
        {
            field = value;
            _valueManager.SetValue(Key, this);
        }
    }

    public string Key { get; }
}