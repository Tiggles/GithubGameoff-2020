using Godot;
using System;

public class Planet : KinematicBody2D
{
	private float distance_threshold = 0;
	readonly private int IMAGE_WIDTH = 64;
	
	public Planet() {}

	public Planet(float distance_threshold) {
		this.distance_threshold = distance_threshold;
	}

	public override void _Ready() {
		var shape = this.GetNode<CollisionShape2D>("./CollisionShape2D");
		var circle = (CircleShape2D) shape.Shape;
		var radius = circle.Radius;
		GD.Print(radius);
		var image_to_radius_scale = (radius / IMAGE_WIDTH) * 2;
		GD.Print(image_to_radius_scale);
		var sprite = this.GetNode<Sprite>("./Sprite");
		sprite.Scale = new Vector2(image_to_radius_scale, image_to_radius_scale);
		sprite.Texture = GD.Load<Texture>("res://Assets/planet.png");
		this.distance_threshold = radius * 4;
	}
	
	public override void _PhysicsProcess(float delta) {}

	public Vector2 GetGravityPull(Vector2 player_position) {

		var vec = new Vector2(0, 0);
		var planet_position = this.Position;


		var difference = new Vector2(
			this.Position.x - player_position.x,
			this.Position.y - player_position.y
		);


		var distance = Math.Sqrt(Math.Pow(difference.x, 2) + Math.Pow(difference.y, 2));
		if (distance > this.distance_threshold) return vec;
		

		var abs_x = Math.Abs(difference.x);
		var abs_y = Math.Abs(difference.y);
		if (planet_position.x < player_position.x) {
			vec.x = -0.05f * abs_x;
		} else {
			vec.x = 0.05f  * abs_x;
		}

		if (planet_position.y < player_position.y) {
			vec.y = -0.05f * abs_y;
		} else {
			vec.y = 0.05f * abs_y;
		}



		return vec;
	}
}
