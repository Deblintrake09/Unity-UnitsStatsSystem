using UnityEngine;

public class ManaComponent : MonoBehaviour, IVisitable
{
    public int Mana = 100;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        Debug.Log("ManaComponent.Accept");
    }

    public void AddMana(int mana)
    {
        Mana += mana;
    }
}
