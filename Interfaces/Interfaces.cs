using UnityEngine;

public interface IVisitor
{
    // void Visit(object o);   // Reflective Visitor
    // void Visit(HealthComponent healthComponent);
    // void Visit(ManaComponent manaComponent);

    void Visit<T>(T visitable) where T : Component, IVisitable;
}


public interface IVisitable
{
    void Accept(IVisitor visitor);
}

public interface IEquipable
{
    StatModifier GetStatModifier();
}


