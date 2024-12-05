using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IVisitable
{

    [SerializeField, InlineEditor, Required] BaseStats baseStats;
    public Stats Stats {  get; private set; }
    //List<IVisitable> visitableComponents = new List<IVisitable>();


    void Awake()
    {
        Stats = new Stats(baseStats, new StatsMediator());
    }

    public void Update()
    {
        Stats.Mediator.Update(Time.deltaTime);
    }

    public void Accept(IVisitor visitor) => visitor.Visit(this);


    public void Equip(Interfaces equipable)
    {
        Stats.Mediator.AddModifier(equipable.GetStatModifier());
    }

    public void Unequip(Interfaces equipable)
    {
        equipable.GetStatModifier().MarkedForRemoval = true;
    }


    ///Implementation for multiple Ivisitables in object
    /* void Start()
    {
        visitableComponents.Add(gameObject.GetOrAddComponent<HealthComponent>());
        visitableComponents.Add(gameObject.GetOrAddComponent<ManaComponent>());
        foreach (var component in visitableComponents)
        {
            Debug.Log(component);
        }
    }
    public void Accept(IVisitor visitor)
    {
        foreach (var component in visitableComponents) {
            Debug.Log(component);
            component.Accept(visitor);
        }
    } */
}