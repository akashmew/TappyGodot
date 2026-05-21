using Godot;
using System;

public partial class SignalHub : Node
{
    public static SignalHub Instance { get; private set; }

    [Signal] public delegate void OnTappyDiedEventHandler();

    [Signal] public delegate void OnPlayerScoredEventHandler();
    public override void _Ready()
    {
        Instance = this;
    }

    public static void EmitTappyDiedSignal()
    {
        Instance.EmitSignal(SignalName.OnTappyDied);
    }

    public static void EmitPointsScore()
    {
        Instance.EmitSignal(SignalName.OnPlayerScored);
    }
   
}
