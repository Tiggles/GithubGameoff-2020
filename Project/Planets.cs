using Godot;
using System;

public class Planets : Node
{
	readonly int base_size = 32;


	public override void _Ready() {
		this.AddChild(this.NewPlanet(5, 32, 50, 50));
		this.AddChild(this.NewPlanet(5, 32, 400, 50));
		this.AddChild(this.NewPlanet(5, 32, 400, 400));
		this.AddChild(this.NewPlanet(5, 32, 50, 400));
	}

	private Node NewPlanet(float mass, float radius, int x, int y) {
		var scale = radius / this.base_size;
		var scale_vec = new Vector2(scale, scale);

		var node = new Node();
		var body = new KinematicBody2D() {
			Position = new Vector2(x, y),
		};

		var shape = new CircleShape2D
		{
			Radius = radius,
		};

		var collision_shape = new CollisionShape2D
		{
			Shape = shape
		};

		var sprite = new Sprite {
			Texture = GD.Load<Texture>("res://Assets/planet.png")
		};
		body.AddChild(collision_shape);
		body.AddChild(sprite);
		node.AddChild(body);
		
		body.Scale = scale_vec;
		
		foreach (var b in body.GetPropertyList()) {
			GD.Print(b);
		}

		GD.Print(body.Get("mass"));
		return node;
	}
}
