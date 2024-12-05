using System;
using System.Collections.Generic;


/// <summary>
/// This Class stores a list of StatModifiers and calculates the user stats every update.
/// Entities will always have their stats updated and will return their current values after modification.
/// </summary>
public class StatsMediator
{
    readonly LinkedList<StatModifier> modifiers = new();

    public EventHandler<Query> Queries;
    public void PerformQuery(object sender, Query query) => Queries?.Invoke(sender, query);

    public void AddModifier(StatModifier modifier)
    {
        modifiers.AddLast(modifier);
        Queries += modifier.Handle;

        modifier.OnDispose += _ =>
        {
            modifiers.Remove(modifier);
            Queries -= modifier.Handle;
        };
    }

    public void Update(float deltaTime)
    {
        // Update all modifiers with deltaTime
        var node = modifiers.Last;
        while (node != null)
        {
            var modifier = node.Value;
            modifier.Update(deltaTime);
            node = node.Next;
        }
        // Dispose of any modifier that is finished, a.k.a Mark and Swep
        node = modifiers.First;
        while (node != null)
        {
            var nextNode = node.Next;
            if (node.Value.MarkedForRemoval)
            {
                node.Value.Dispose();
            }
            node = nextNode;
        }
    }
}

public class Query
{
    public readonly StatType statType;
    public int value;


    public Query(StatType statType, int value)
    {
        this.statType = statType;
        this.value = value;
    }
}

