using Godot;
using System;

public partial class CampaignMenu : Control
{
    [Export] private AnimationPlayer _AnimationPlayer;

    private bool _IsExiting = false;

    public override void _Ready()
    {
        MenuMusicPlayer.Instance.PlayMusic();

        _AnimationPlayer.AnimationFinished += OnAnimationFinished;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_filedialog_up_one_level"))
        {
            _IsExiting = true;
            _AnimationPlayer.Play("Out");
        }
        else if (@event.IsActionPressed("ui_accept"))
        {
            _IsExiting = false;
            _AnimationPlayer.Play("Out");
        }
    }

    private void OnAnimationFinished(StringName animName)
    {
        if (animName == "Out")
        {
            switch (_IsExiting)
            {
                case true:
                    SceneChanger.Instance.ChangeScene("res://Menu/Scenes/main_menu.tscn");
                    break;
                default:
                    GD.Print("O Game cara");
                    break;
            }
        }
    }

}
