using System;
using ImprovedTimers;


/// <summary>
///  This class Generates stats modifiers that can be applied to any through the StatsMediator.
///  when duration is less than 0, the effect is permanent until it is Marked for Removal manually.
/// </summary>
public abstract class StatModifier : IDisposable
{
    public bool MarkedForRemoval {  get; set; }
    public event Action<StatModifier> OnDispose = delegate { };

    readonly CountdownTimer timer;

    protected StatModifier(float duration)
    {
        if (duration <= 0) return;
        timer = new CountdownTimer(duration);
        timer.OnTimerStop += () => MarkedForRemoval = true;
        timer.Start();
    }

    public void Update(float deltaTime) => timer?.Tick(deltaTime);

    public abstract void Handle(object sender, Query query);



    public void Dispose()
    {
        OnDispose.Invoke(this);
    }
}


public class BasicStatModifier : StatModifier
{
    readonly StatType Type;
    readonly Func<int, int> operation;
    

    public BasicStatModifier(StatType type, Func<int, int> operation, float duration) : base(duration)
    {
        Type = type;
        this.operation = operation;
    }

    public override void Handle(object sender, Query query)
    {
        if (query.statType == Type)
        {
            query.value =operation(query.value);
        }
    }
}