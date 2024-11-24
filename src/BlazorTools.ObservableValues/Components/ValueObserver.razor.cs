using BlazorTools.ObservableValues.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTools.ObservableValues.Components;

public partial class ValueObserver<T> : IDisposable
{
    private T? Value
    {
        get
        {
            var observedValue = ValueManagerResolver.ValueManager.GetValue<T>(ValueKey);

            if (observedValue is null)
                return default;

            return observedValue.Value;
        }
    }

    [Parameter]
    public RenderFragment<T?>? ChildContent { get; set; }

    [Parameter]
    public string ValueKey { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<T?> ValueChanged { get; set; }

    protected override void OnInitialized()
    {
        ValueManagerResolver.ValueManager.ObserveValue(ValueKey, OnValueChanged);
    }

    public void Dispose()
    {
        ValueManagerResolver.ValueManager.StopObservingValue(ValueKey, OnValueChanged);
    }

    private void OnValueChanged(object _)
    {
        StateHasChanged();

        ValueChanged.InvokeAsync(Value);
    }
}
