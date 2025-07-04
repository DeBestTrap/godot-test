using Godot;
using System;

public partial class Health : Node
{
    [Export]
    private int health = 100;

    public void Damage(int damage)
    {
        health -= damage;
    }
}