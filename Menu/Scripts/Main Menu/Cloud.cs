using Godot;
using Godot.Collections;
using System;
using System.Threading.Tasks;

public partial class Cloud : TextureRect
{
    [Export] private AnimationPlayer animationPlayer;
    [Export] private Array<Texture2D> cloudTextures;

    private Random _random = new Random();

    public override void _Ready()
    {
        animationPlayer.AnimationFinished += OnAnimationFinished;
    }

    private async void OnAnimationFinished(StringName animName)
    {
        if (animName == "Cloud")
        {
            Texture = cloudTextures[_random.Next(cloudTextures.Count)];
            animationPlayer.SpeedScale = (float)_random.NextDouble() * 0.5f + 0.5f; // Random speed between 0.5 and 1.0

            await ToSignal(GetTree().CreateTimer(_random.Next(0, 5)), "timeout");
            
            animationPlayer.Play("Cloud");
        }
    }
}
