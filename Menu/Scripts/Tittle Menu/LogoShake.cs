using Godot;
using System;

public partial class LogoShake : Node
{
    [Export] TextureRect _logo;
    [Export] float rotationAmplitude = 3f;
    [Export] float shakeSpeed = 15f;

    float shakeTime = 0f;

    public void Shake(double delta)
    {
        shakeTime += (float)delta * shakeSpeed;
        float rotation = Mathf.Sin(shakeTime) * rotationAmplitude;
        _logo.RotationDegrees = rotation;
    }
}
