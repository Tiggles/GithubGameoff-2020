using Godot;
using System;

public class Planet : KinematicBody2D
{
	readonly private double mass;
	readonly private double radius;
	readonly private int IMAGE_WIDTH = 64;
	
	public Planet() {}

	public Planet(double mass, double radius) {
		this.mass = mass;
		this.radius = radius;
	}

	public override void _Ready() {
		var shape = this.GetNode<CollisionShape2D>("./CollisionShape2D");
		var circle = (CircleShape2D) shape.Shape;
		var radius = circle.Radius;
		GD.Print(radius);
		var image_to_radius_scale = (IMAGE_WIDTH / radius) / 2;
		GD.Print(image_to_radius_scale);
		shape.Scale = new Vector2(image_to_radius_scale, image_to_radius_scale);
		var sprite = this.GetNode<Sprite>("./Sprite");
		sprite.Scale = new Vector2(1, 1);
		sprite.Texture = GD.Load<Texture>("res://Assets/planet.png");


	}
	
	public override void _PhysicsProcess(float delta) {}

	public Vector2 GetGravityPull(Player player) {
		var vec = new Vector2();


		return vec;
	}
}
