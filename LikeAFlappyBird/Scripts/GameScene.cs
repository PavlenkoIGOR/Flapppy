using Godot;
using System;

public partial class GameScene : Node
{

	[Signal]
	public delegate void PauseEventHandler();
	[Signal]
	public delegate void TimerEventHandler();

	

	private float PipesPrefab_Start_position_X;
	private float PipesPrefab_Start_position_Y;

	[Export]
	public PipesPrefab pipesPrefab;

	[Export]
	public Timer timer;

	public GameScene gameScene { get; set; }

	[Export]
	public Label ScoreLabel;
	public int Scores;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer.Start();

		FindElements();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{        
		var screen = GetWindow().Size;
		if (Input.IsKeyPressed(Key.Escape))
		{
			_on_pause();
		}
		if (timer.TimeLeft == 0)
		{
			_on_timer_timeout();
			timer._Ready();
		}
		ScoreLabel.Text = "Scores: " + GameManager.Scores.ToString();
	}
	private void _on_pause()
	{
		//change to current scene
		GetTree().ChangeSceneToFile("res://Scenes/MenuScreen.tscn");
		GD.Print("play is pressed");
	}
	private void CreatePipesPrefab()
	{
		PackedScene packedScene = GD.Load<PackedScene>("res://Scenes/Prefab/PipesPrefab.tscn");
		pipesPrefab = packedScene.Instantiate<PipesPrefab>();


		//or var screen = GetWindow().Size;
		//pipesPrefab.GlobalPosition = new Vector2((int)GetViewport().GetVisibleRect().Size.X + 10, pipesPrefab.RandomizeYPosition());
		pipesPrefab.Position = new Vector2((int)GetViewport().GetVisibleRect().Size.X + 10, pipesPrefab.RandomizeYPosition());//1672
		AddChild(pipesPrefab);

		GD.Print($"GP_X: {pipesPrefab.GlobalPosition.X}, GP_Y: {pipesPrefab.GlobalPosition.Y}");
		if (pipesPrefab == null)
		{
			GD.Print("scene \'pipesPrefab\' not found");
		}
	}

	//public void MovePipesPrefab(double delta)
	//{
	//	pipesPrefab.GlobalPosition += new Vector2(-PipesPrefab_Speed * (float)delta, 0);
	//	GD.Print($"Prefab from Move method GP_X: {pipesPrefab.GlobalPosition.X}, GP_Y: {pipesPrefab.GlobalPosition.Y}");
	//}

	private void _on_timer_timeout()
	{
		CreatePipesPrefab();
	}
	public void FindElements()
	{
		//PackedScene scene = (PackedScene)GD.Load("res://Scenes/GameScene.tscn");
		//Node instance = scene.Instantiate();
		//CanvasLayer canvasLayer = instance.GetNode<CanvasLayer>("CanvasLayer");
		//var ScoreLabel = canvasLayer.GetNode<Label>("ScoreLabel");
		//if (ScoreLabel != null) { GD.Print("The node 'label GS' was founded!"); }

		//PackedScene packedScene1 = (PackedScene)ResourceLoader.Load("res://Scenes/GameScene.tscn");
		//Node sceneInstance1 = packedScene1.Instantiate();
		//CharacterBody2D birdNode = GetNode<CharacterBody2D>("Bird");
		//if (birdNode != null) { GD.Print("The node 'birdNode GS' founded!"); }
	}
	private void OnArea2dBodyExited(Node2D body)
	{
		GD.Print("XYU");
	}		
}

