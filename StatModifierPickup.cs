using UnityEngine;
using System;

/// <summary>
/// This Class Implements Stats modifiers through Class Inheritance. Each new type of Pickup inherits from Pickup
/// In this case, all the data is stored in the class instead of using Scriptable Objects for the data.
/// </summary>
public class StatModifierPickup : Pickup
{
    public enum OperatorType { Add, Substract, Multiply, Divide }
    [SerializeField] StatType type = StatType.Attack;
    [SerializeField] OperatorType operatorType = OperatorType.Add;
    [SerializeField] int value = 10;
    [SerializeField] float duration = 5f;

    protected override void ApplyPickupEffect(Entity entity)
    {
        StatModifier modifier = operatorType switch
        {
            OperatorType.Add => new BasicStatModifier(type, v => v + value, duration),
            OperatorType.Multiply => new BasicStatModifier(type, v => v * value, duration),
            OperatorType.Substract => new BasicStatModifier(type, v => v - value, duration),
            _ => throw new ArgumentOutOfRangeException()
        };

        entity.Stats.Mediator.AddModifier(modifier);
    }
}