using Godot;
using System;

public interface ISaveFormatter
{
    string GetExtension();
    byte[] Serialize<T>(T data);
    T Deserialize<T>(byte[] data);
}
