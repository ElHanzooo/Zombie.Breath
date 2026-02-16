using Godot;
using System;

public interface LogoShake
{
    void Shaking(TextureRect _logo, float rotationAmplitude, float shakeSpeed, float delta);
}

public class Shake : LogoShake
{
    float shakeTime = 0f;
    public void Shaking(TextureRect _logo, float rotationAmplitude, float shakeSpeed, float delta)
    {
        shakeTime += (float)delta * (shakeSpeed >= 0 ? shakeSpeed : 15f);
        float rotation = Mathf.Sin(shakeTime) * (rotationAmplitude >= 0 ? rotationAmplitude : 3f);
        _logo.RotationDegrees = rotation;
    }
}