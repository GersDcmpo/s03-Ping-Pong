using Godot;

public class Ball : Area2D
{
	private const int DefaultSpeed = 400;
	public Vector2 Direction = Vector2.Left;
	private Vector2 _initialPos;
	private float _speed = DefaultSpeed;
	private float _ceilingY = -300;
	private float _floorY = 390;

	public override void _Ready()
	{
		_initialPos = Position;
	}

	public override void _Process(float delta)
	{
		_speed += delta * 2;
		Position += Direction * _speed * delta;

		if (Position.y < _ceilingY || Position.y > _floorY)
		{
			Direction = new Vector2(Direction.x, -Direction.y);
		}
	}

	public void Reset()
	{
		Direction = Vector2.Left;
		Position = _initialPos;
		_speed = DefaultSpeed;
	}

	public void IncreaseSpeed(int amount)
	{
		_speed += amount;
	}
}
