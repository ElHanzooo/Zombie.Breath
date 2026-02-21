using Godot;
using System;

public partial class CampaignAction : ButtonAction
{
    [Signal] public delegate void StartCampaignEventHandler();

    public override void Execute()
    {
        EmitSignal(SignalName.StartCampaign);
    }
}
