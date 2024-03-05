using Godot;
using System;
using Devs.scripts;

public partial class BasicEnemy : Node
{
    [Export] private CharacterMotor _motor = null;
    [Export] private Player _player = null;

    [Export] private float _attackDistance = 1f;
    public override void _Process(double delta)
    {
        Vector2 deltaPlayerPosition = _player.BodyPosition - _motor.GlobalPosition;
        float distanceToPlayer = deltaPlayerPosition.Length();

        if (distanceToPlayer < _attackDistance)
        {
            Attack();
            return;
        }
        GoTopPlayer(deltaPlayerPosition);
        
    }

    private void Attack()
    {
        _motor.Stop();
    }

    private void GoTopPlayer(Vector2 deltaPlayerPosition)
    {
        _motor.MovementPerformed(deltaPlayerPosition.Normalized());
    }
}

