using Godot;
using System;

public partial class Tappy : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	const float JUMP_POWER = -350.0f;

	public const string GROUP_NAME = "tappy";
	[Export] AnimatedSprite2D _sprite;
	[Export] AnimationPlayer _animator;
	[Export] AudioStreamPlayer _engineSound;

	
	
	private bool _isJumped = false;
	public override void _Ready()
	{
	}

    public override void _EnterTree()
    {
		AddToGroup(GROUP_NAME);
    }


	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("jump"))
		{
			_isJumped = true;
			_animator.Play("jump");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		//velocity.X = 100;

		if (_isJumped)
		{
			velocity.Y = JUMP_POWER;
			Velocity = velocity;
			_isJumped = false;
		}
		else
		{

			ApplyGravity(delta);

		}


		MoveAndSlide();
		if (IsOnFloor())
		{
			Die();
		}

	}

	public void Die()
	{
		SignalHub.EmitTappyDiedSignal();
		//SetPhysicsProcess(false);
		_sprite.Stop();
		GetTree().Paused = true;
    }

    private void ApplyGravity(double delta)
	{
		Vector2 downWardVelocity = Velocity;

		downWardVelocity.Y += _gravity * (float)delta;

		Velocity = downWardVelocity;

	}

	
}
