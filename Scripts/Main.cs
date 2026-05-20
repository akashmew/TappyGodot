using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Main : Control
{

   

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_cancel"))
        {
            GameManager.LoadGameScene();
        }
    }

    
}
