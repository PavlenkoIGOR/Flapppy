using Godot;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class PipesPrefab : Node2D
{
	private float Start_position_X;
	private float Start_position_Y;
	[Export]
	public int Speed;
	[Export]
	public CharacterBody2D BirdPlayer;
	[Export]
	public Area2D Trigger;
	[Export]
	public Label ScoreLabel;
	[Signal]
	public delegate void HitEventHandler();
	public int Scores = 0;
	public delegate void BodyExitedEventHandler();
	public PipesPrefab()
	{

	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (BirdPlayer != null) { GD.Print("BirdPlayer not null"); }
		if (Trigger != null) { GD.Print("Trigger not null"); }

		//Start_position_X = GlobalPosition.X;
		//Start_position_Y = RandomizeYPosition();
		//Translate(new Vector2(Start_position_X, Start_position_Y));
		//GD.Print($"Start pos Pipes Prefab:\nX: {Start_position_X}; Y: {Start_position_Y}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(-Speed * (float)delta, 0);

	}
	public float RandomizeYPosition()
	{
		var Rand_Start_position_Y = GD.RandRange(210, 640);
		return Rand_Start_position_Y;
	}

	/// <summary>
	/// deleting an object when it has left the screen. thats all!
	/// </summary>
	public void _on_visible_on_screen_notifier_2d_screen_exited()
	{
		QueueFree();
	}
	private void _on_area_2d_body_exited(Node2D body)
	{
		GameManager.Scores++;

		PackedScene packedScene2 = GD.Load<PackedScene>("res://Scenes/GameScene.tscn");
		Node sceneInstance2 = packedScene2.Instantiate();
		Label label = sceneInstance2.GetNode<Label>("ScoreLabel");
		if (label != null)
		{
			//GD.Print("The node 'label' founded!", GameManager.Scores.ToString());
			
			//label.Text = "Scores: " + GameManager.Scores.ToString();
		}		
	}
	private void _on_bottom_pipe_tree_entered()
	{
		GetTree().ChangeSceneToFile("res://Scenes/MenuScreen.tscn");
	}
}










