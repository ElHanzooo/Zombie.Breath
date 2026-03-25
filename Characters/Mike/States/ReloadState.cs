using Godot;

[GlobalClass]
public partial class ReloadState : State
{
    [Export] private Mike Mike { get; set; }

    private AnimatedSprite2D animations;

    public override void _Ready()
    {
        animations = Mike.GetNode<AnimatedSprite2D>("Animations");
        animations.AnimationFinished += () => EmitSignal(SignalName.Transitioned, "Idle");
    }

    public override void Enter()
    {
        animations.Play("Reload");
        Global.Instance.PlaySFX(GD.Load<AudioStream>("res://Characters/Mike/Assets/SFXs/Reload.ogg"));
    }

    public override void Exit()
    {
        Mike.NeedReload = false;
    }
}
