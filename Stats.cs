public enum StatType {Attack, Defense}


/// <summary>
/// The Stats Class will always return the current stats updated by all the modifiers that apply through the StatsMediator Class
/// </summary>
public class Stats {
    readonly BaseStats baseStats;
    readonly StatsMediator mediator;
    public StatsMediator Mediator => mediator;

    public Stats (BaseStats baseStats, StatsMediator mediator)
    {
        this.baseStats = baseStats;
        this.mediator = mediator;
    }

    public override string ToString() => $"Attack: {Attack}, Defense: {Defense}";

    
    public int Attack { 
        get {
            // return value with modifiers applied
            var q = new Query(StatType.Attack, baseStats.attack);
            mediator.PerformQuery(this, q);
            return q.value;
        }

    }

    public int Defense { 
        get {
            // return value with modifiers applied
            var q = new Query(StatType.Defense, baseStats.defense);
            mediator.PerformQuery(this, q);
            return q.value;
        }

    }
}