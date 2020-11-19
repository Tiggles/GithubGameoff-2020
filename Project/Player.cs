using Godot;

public class Player : Godot.KinematicBody2D
{
	readonly float rotation_speed = 0.08f;
	readonly float movement_speed = 5;

	public override void _Ready() {	}

	public override void _PhysicsProcess(float delta)
	{
		var vec = new Vector2();

		var planets = GetTree().Root.GetNode("./Root/Planets").GetChildren();


		var player_center = new Vector2(this.Position.x, this.Position.y);

		foreach (var planet in planets) {
			vec += ((Planet) planet).GetGravityPull(player_center);
			GD.Print(vec);
		}


		if (Input.IsActionPressed("ui_up"))	{
			vec += new Vector2(0, -movement_speed);
		} else if (Input.IsActionPressed("ui_down")) {
			vec += new Vector2(0, movement_speed);
		}

		if (Input.IsActionPressed("ui_left")) {
			vec += new Vector2(-movement_speed, 0);
		} else if (Input.IsActionPressed("ui_right")) {
			vec += new Vector2(movement_speed, 0);
		}

		this.MoveAndCollide(vec);
		this.Rotate(rotation_speed);
	}
}
