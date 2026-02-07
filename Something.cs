using System;
using System.Diagnostics;
using Godot;

public partial class Something : Label
{
    private readonly Stopwatch _stopWatch = new();

    public override void _Ready()
    {
        SecondsToText();
        DisplayTimerProperties();
    }

    private void SecondsToText()
    {
        Text = $"{_stopWatch.Elapsed.Minutes:00}:{_stopWatch.Elapsed.Seconds:00}.{_stopWatch.Elapsed.Milliseconds:000}";
    }

    public override void _Process(double delta)
    {
        SecondsToText();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
            if (keyEvent.Keycode == Key.Space)
            {
                if (_stopWatch.IsRunning)
                {
                    _stopWatch.Stop();
                }
                else
                {
                    if (_stopWatch.ElapsedMilliseconds > 0)
                        _stopWatch.Reset();
                    else
                        _stopWatch.Restart();
                }
            }
    }
    
    public static void DisplayTimerProperties()
    {
        // Display the timer frequency and resolution.
        if (Stopwatch.IsHighResolution)
        {
            GD.Print("Operations timed using the system's high-resolution performance counter.");
        }
        else
        {
            GD.Print("Operations timed using the DateTime class.");
        }

        long frequency = Stopwatch.Frequency;
        GD.Print($"  Timer frequency in ticks per second = {frequency}");
        long nanosecPerTick = (1000L*1000L*1000L) / frequency;
        GD.Print($"  Timer is accurate within {nanosecPerTick} nanoseconds");
    }
}