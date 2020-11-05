using Godot;
using System;

public class Planets : Node
{
	readonly int base_size = 64;


	public override void _Ready() {
		this.AddChild(this.NewPlanet(5, 64, 50, 100));
		this.AddChild(this.NewPlanet(5, 64, 100, 50));
		this.AddChild(this.NewPlanet(5, 64, 50, 50));
		this.AddChild(this.NewPlanet(5, 64, 100, 100));
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }

	private Node NewPlanet(float mass, float radius, int x, int y) {
		var scale = radius / this.base_size;
		GD.Print(scale);
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
			Shape = shape,
			Scale = scale_vec
		};
		collision_shape.Scale = new Vector2(scale, scale);

		var sprite = new Sprite {
			Texture = GD.Load<Texture>("res://Assets/planet.png")
		};
		sprite.Scale = scale_vec;
		body.AddChild(collision_shape);
		body.AddChild(sprite);
		node.AddChild(body);

		return node;
	}
}
