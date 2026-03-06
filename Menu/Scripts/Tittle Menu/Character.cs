using Godot;
using System;
using Godot.Collections;
using System.Diagnostics;

public partial class Character : TextureRect
{
    [Export] private Dictionary<Episodes, Texture2D> characterTextures = new();

    public override void _Ready()
    {
        switch (Global.Episode)
        {
            case Episodes.Day:
                ChangeTexture(Episodes.Day, new Vector2(1.7f, 1.7f));
                break;
            case Episodes.Afternoon:
                ChangeTexture(Episodes.Afternoon, new Vector2(1.84f, 1.84f), new Vector2(0f, 470f));
                break;
            case Episodes.Night:
                ChangeTexture(Episodes.Night, new Vector2(1.7f, 1.7f), new Vector2(0f, -40f));
                break;
        }
    }

    private void ChangeTexture(Episodes episode, Vector2 scale, Vector2 pivot = default)
    {
        var newTexture = characterTextures[episode];
        Texture = newTexture;
        Size = newTexture.GetSize();
        Scale = scale;
        PivotOffset = pivot;
    }
}
