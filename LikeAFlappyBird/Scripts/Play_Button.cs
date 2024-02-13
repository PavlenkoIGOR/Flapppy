using Godot;
using System;

public partial class Play_Button : Node
{
	public int font_size;
	[Export]
	public string text;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    private void ButtonPlayPress()
    {
        SetProcess(!IsProcessing());
        //change start scene to current scene
        GetTree().ChangeSceneToFile("res://Scenes/GameScene.tscn");
		GD.Print("play is pressed");
    }
}
