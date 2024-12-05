using System.Net;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject, IVisitor
{
    public int healthBonus = 10;
    public int manaBonus = 10;
    public void Visit(HealthComponent healthComponent)
    {
        healthComponent.Health += healthBonus;
        Debug.Log("PowerUp.Visit(HealthComponent)");
    }

    public void Visit(ManaComponent manaComponent)
    {
        manaComponent.Mana += manaBonus;
        Debug.Log("PowerUp.Visit(ManaComponent)");
    }


    public void Visit<T>(T visitable) where T : Component, IVisitable
    {
        return;
    }

    /// <summary>
    /// Reflective Visitor - Checks if there is a Visit Method on the object for the given type
    /// </summary>
    /// <param name="o"></param>
    /*public void Visit(object o)
    {
        MethodInfo visitMethod = GetType().GetMethod("Visit", new [] {o.GetType()});
        if (visitMethod != null && visitMethod != GetType().GetMethod("Visit", new [] { typeof(object) }))
        {
            visitMethod.Invoke(this, new [] {o});
        }
        else 
        { 
            DefaultVisit(o); 
        }
        Debug.Log("PowerUp.Visit(ManaComponent)");
    }

    void DefaultVisit(object o)
    {
        Debug.Log("PowerUp.DefaultVisit");
    }*/
}