using Godot;
using Godot.Collections;
using System;
using System.Threading.Tasks;

public partial class Cloud : TextureRect
{
    [Export] private float MaxTime = 9f;
    [Export] private float MinTime = 5f;
    [Export] private float MaxScale = 0.25f;
    [Export] private float MinScale = 0.2f;
    [Export] private Array<Texture2D> cloudTextures;

    private Tween _tween;
    
    public override void _Ready()
    {
        PlayCloudAnimation();        
    }

    private async void PlayCloudAnimation()
    {
        await ToSignal(GetTree().CreateTimer((float)GD.RandRange(0.5f, 2f)), "timeout");

        float textureWidth = Texture.GetWidth();
        Position = new Vector2(-textureWidth, (float)(GD.RandRange(100f, GetViewportRect().Size.Y / 2.5f))); 

        Texture = cloudTextures[(int)(GD.Randi() % cloudTextures.Count)];
        Scale = new Vector2((float)GD.RandRange(MinScale, MaxScale), (float)GD.RandRange(MinScale, MaxScale));

        _tween?.Kill();
        _tween = GetTree().CreateTween();

        float duration = (float)GD.RandRange(MinTime, MaxTime);
        float screenWidth = GetViewportRect().Size.X;

        _tween.TweenProperty(this, "position:x", screenWidth, duration)
              .SetTrans(Tween.TransitionType.Linear)
              .SetEase(Tween.EaseType.InOut);
        
        await ToSignal(_tween, "finished");

        if (IsInstanceValid(this))
        {
            PlayCloudAnimation();
        }
    }
}
