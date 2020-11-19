using Godot;

public class Player : Godot.RigidBody2D
{
	readonly float rotation_speed = 0.08f;
	readonly float movement_speed = 100;

	public override void _Ready() {
		this.ApplyImpulse(new Vector2(), new Vector2(200, 0));
	}

	public override void _PhysicsProcess(float delta)
	{
		var vec = new Vector2();
		var planets = GetTree().Root.GetNode("./Root/Planets").GetChildren();
		var player_center = new Vector2(this.Position.x, this.Position.y);

		foreach (var planet in planets) {
			var result = ((Planet) planet).GetGravityPull(player_center);
			vec += result;
		}

		this.AddForce(new Vector2(), vec);
		this.Rotate(rotation_speed);
	}
}
