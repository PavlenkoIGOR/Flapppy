using Godot;
using System;

public partial class MenuScreen : Control
{
	[Export]
	public Label ScoresLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoresLabel.Text += " " + GameManager.Scores;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
