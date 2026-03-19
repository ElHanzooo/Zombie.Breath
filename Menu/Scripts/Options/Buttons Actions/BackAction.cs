using Godot;
using System;

public partial class BackAction : ButtonAction
{
    public override void Execute()
    {
        SceneChanger.Instance.ChangeScene("res://Menu/Scenes/main_menu.tscn");
    }
}
