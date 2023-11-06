using Godot;

namespace Devs.scripts;

public partial class Player : Node
{
    [Export]private PlayerInput _input;
    [Export]private CharacterMotor _motor;

    public override void _Process(double delta)
    {
        _motor.MovementPerformed(_input.MovementInput);
    }
}