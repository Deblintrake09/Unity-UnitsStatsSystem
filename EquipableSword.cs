using JetBrains.Annotations;
using UnityEngine;

public class EquipableSword : MonoBehaviour, Interfaces
{
    StatModifier swordModifier = new BasicStatModifier(StatType.Attack, x => x + 1, 10);
    public StatModifier GetStatModifier() => swordModifier;
}
 