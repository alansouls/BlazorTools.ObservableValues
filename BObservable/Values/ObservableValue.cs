using BObservable.Services;

namespace BObservable.Values;

public class ObservableValue<T>
{
    private readonly IInternalValueManager _valueManager;

    public ObservableValue(IValueManager valueManager)
    {
        var internalValueManager = valueManager as IInternalValueManager;

        if (internalValueManager is null)
        {
            throw new Exception("ValueManager must implement IInternalValueManager");
        }
        
        _valueManager = internalValueManager;
    }
    
    public T? Value
    {
        get => field;
        set
        {
            field = value;
        }
    }
}