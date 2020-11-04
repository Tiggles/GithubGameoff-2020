using Godot;

public class KinematicBody2D : Godot.KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTree().Root.Get("Planets");
		var planets = GetTree().Root.GetNode<Node>("./Root/Planets").GetChildren();
		foreach (Node2D node in planets) {

		}
	}

	public override void _Process(float delta)
	{
		base._Process(delta);
		this.
	}
}
