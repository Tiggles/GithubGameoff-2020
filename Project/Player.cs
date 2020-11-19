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
			var result = ((Planet) planet).GetGravityPull(player_center);
			//GD.Print(result);
			vec += result;
		}

		GD.Print(vec);

		var movement = new Vector2(0, 0);
		if (Input.IsActionPressed("ui_up"))	{
			movement += new Vector2(0, -1);
		} else if (Input.IsActionPressed("ui_down")) {
			movement += new Vector2(0, 1);
		}

		if (Input.IsActionPressed("ui_left")) {
			movement += new Vector2(-1, 0);
		} else if (Input.IsActionPressed("ui_right")) {
			movement += new Vector2(1, 0);
		}

		this.MoveAndCollide(vec + movement.Normalized() * this.movement_speed);
		this.Rotate(rotation_speed);
	}
}
