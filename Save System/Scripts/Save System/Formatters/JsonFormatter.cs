using Godot;
using System;
using System.Text;
using System.Text.Json;

public partial class JsonFormatter : ISaveFormatter
{
    public string GetExtension() => "json";

    public byte[] Serialize<T>(T data) =>
        Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));

    public T Deserialize<T>(byte[] bytes) =>
        JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(bytes));
}
