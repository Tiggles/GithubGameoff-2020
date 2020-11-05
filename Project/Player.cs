using Godot;

public class PlayerScript : Godot.KinematicBody2D
{
	float rotation_speed = 0.08f;
	float movement_speed = 5;

	public override void _Ready()
	{
		GetTree().Root.Get("Planets");
		var planets = GetTree().Root.GetNode<Node>("./Root/Planets").GetChildren();
		GD.Print(planets.Count);
		
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionPressed("ui_up"))	{
			this.MoveAndCollide(new Vector2(0, -movement_speed));
		} else if (Input.IsActionPressed("ui_down")) {
			this.MoveAndCollide(new Vector2(0, movement_speed));
		}

		if (Input.IsActionPressed("ui_left")) {
			this.MoveAndCollide(new Vector2(-movement_speed, 0));
		} else if (Input.IsActionPressed("ui_right")) {
			this.MoveAndCollide(new Vector2(movement_speed, 0));
		}

		this.Rotate(rotation_speed);
	}
}
