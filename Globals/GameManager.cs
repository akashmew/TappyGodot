using Godot;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }

    private PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main.tscn");

    private PackedScene _gameScene = GD.Load<PackedScene>("res://Scenes/game.tscn");

    public PackedScene MainScene { get { return _mainScene; } }
    public PackedScene GameScene { get { return _gameScene; } }
    public override void _Ready()
    {
        Instance = this;
    }

    public static void LoadMainScene()
    {
        Instance.GetTree().ChangeSceneToPacked(Instance.MainScene);
    }

    public static void LoadGameScene()
    {
        Instance.GetTree().ChangeSceneToPacked(Instance.GameScene);
    }

}
