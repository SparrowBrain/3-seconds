using System.Diagnostics;
using Godot;

public partial class Something : Label
{
    private readonly Stopwatch _stopWatch = new();

    public override void _Ready()
    {
        SecondsToText();
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
}