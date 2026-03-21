using Godot;
using System;

public partial class SaveManager : Node
{
    public static SaveManager Instance { get; private set; }

    private readonly ISaveFormatter _formatter = new JsonFormatter();
    private const string SavePath = "user://autosave";

    public override void _Ready()
    {
        Instance = this;
    }

    public void SaveGame(SaveData data)
    {
        string fullPath = $"{SavePath}.{_formatter.GetExtension()}";
        byte[] bytes = _formatter.Serialize(data);

        using var file = FileAccess.Open(fullPath, FileAccess.ModeFlags.Write);
        file.StoreBuffer(bytes);
        GD.Print($"Game saved automatically to {fullPath}");
    }

    public SaveData LoadGame()
    {
        string fullPath = $"{SavePath}.{_formatter.GetExtension()}";

        if (!FileAccess.FileExists(fullPath)) return new SaveData();

        using var file = FileAccess.Open(fullPath, FileAccess.ModeFlags.Read);
        byte[] bytes = file.GetBuffer((long)file.GetLength());
        return _formatter.Deserialize<SaveData>(bytes);
    }
}
