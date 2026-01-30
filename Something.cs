using Godot;
using System;

public partial class Something : Label
{
	private TimeSpan _secondsRemaining;
	private bool _isRunning;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_secondsRemaining = TimeSpan.FromSeconds(0);
		SecondsToText();
	}

	private void SecondsToText()
	{
		Text = $"{_secondsRemaining.Minutes:00}:{_secondsRemaining.Seconds:00}.{_secondsRemaining.Milliseconds:000}";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_isRunning)
		{
			_secondsRemaining = _secondsRemaining.Add(TimeSpan.FromSeconds(delta));
			SecondsToText();
		}

	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (keyEvent.Keycode == Key.Space)
			{
				if (!_isRunning && _secondsRemaining.TotalSeconds > 0)
				{
					_secondsRemaining = TimeSpan.Zero;
					SecondsToText();
				}
				else
				{
				_isRunning = !_isRunning;
					
				}
				
			}
		}
	}
}
