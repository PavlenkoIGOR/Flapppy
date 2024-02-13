using Godot;
using Godot.Collections;
using System;
using System.Threading;
using System.Transactions;

public partial class Bird : CharacterBody2D
{
	[Export]
	public int Gravity = 100;
	public const int Max_Velocity = 600;
	[Export]
	public int Jump_Power = 5;
	public const int Speed = 500;
	public Vector2 Velocity = new Vector2();


	//public Vector2 Start_position = new Vector2 (100, 400);
	private bool IsFlying = false;
	private bool IsFalling = false;


	public Transform2D transform2D;
	public Vector2 vector2;

	public Label ScoreLabel;
	public int Score = 0;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Reset();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		//GlobalPosition += new Vector2((float)delta*200, 0);

		if (Input.IsKeyPressed(Key.Space))
		{
			Velocity.Y = -Jump_Power;
		}
		//AnimatedSprite2D animatedSprite2D = new AnimatedSprite2D();
		//animatedSprite2D.IsPlaying();
		Velocity.Y += (float)delta * Gravity;
		MoveAndCollide(Velocity);
	}

	private void Reset()
	{
		IsFalling = false;
		IsFlying = false;
		//Position = Start_position;
		Rotate(0);
	}

	void OnBodyExited(Node characterBody2D)
	{
		
		Score++;
		ScoreLabel.Text += Score.ToString();

		GD.Print("L");
	}
}
