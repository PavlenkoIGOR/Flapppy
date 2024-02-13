using Godot;
using System;
using System.Reflection.Emit;

public partial class GroundMove : ParallaxLayer//ParallaxBackground
{
	[Export]
	public float Speed;
	[Export]
	public ParallaxLayer Layer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Layer.MotionOffset += new Vector2((float)(-Speed * delta),0); /// Layer.MotionScale);
    }
}

/*
 for staticBody etc:

		GlobalPosition += new Vector2((float)(-GroundSpeed * delta), 0);

		Vector2 currPos = Position;
		if (GlobalPosition.X <= -920)
		{
			GD.Print("Ground reached -1728");

			GlobalPosition = (new Vector2(2528, 860));
		}
 */
/*
 if inherit from ParallaxBackground:

        var offset = ScrollBaseOffset;
        offset.X += -(float)delta * Speed;
        ScrollBaseOffset = offset;

if inherit from ParallaxLayer:

Layer.MotionOffset += new Vector2((float)(-Speed * delta),0);
 */