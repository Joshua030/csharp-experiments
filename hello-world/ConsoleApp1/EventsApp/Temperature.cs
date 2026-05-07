using System;

namespace EventsApp;

public delegate void TemperatureChangeHandler(string message);

public class TemperatureChangeEventArgs : EventArgs
{
    public int Temperature { get; }

    public TemperatureChangeEventArgs(int temperature)
    {
        Temperature = temperature;
    }
}

public class TemperatureMonitor
{
    //public event TemperatureChangeHandler? OnTemperatureChange;
    public event EventHandler<TemperatureChangeEventArgs>? TemperatureChange;

    private int _temperature;
    public int Temperature
    {
        get => _temperature;

        set
        {

            if (_temperature != value)
            {
                _temperature = value;
                OnTemperatureChange(new TemperatureChangeEventArgs(_temperature));
            }
        }
    }

    protected virtual void OnTemperatureChange(TemperatureChangeEventArgs e)
    {
        TemperatureChange?.Invoke(this, e);
    }

}

public class TemperatureAlert
{
    public void OnTemperatureChange(object? sender, TemperatureChangeEventArgs e)
    {
        Console.WriteLine("Alert: " + e.Temperature + " sender is " + sender);
    }
}

