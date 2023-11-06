using Godot;

public partial class CameraFollower : Node2D
{
	[Export] private Node2D _objectToFollow = null;

	public override void _Process(double delta)
	{
		Position = _objectToFollow.Position;
	}
}
