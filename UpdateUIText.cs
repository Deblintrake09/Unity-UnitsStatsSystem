using UnityEngine;
using TMPro;

public class UpdateUIText: MonoBehaviour
{
    [SerializeField] TMP_Text AttackText;
    [SerializeField] TMP_Text DefenseText;
    [SerializeField] Hero hero;


    public void Update()
    {
        AttackText.text = $"Attack: {hero.Stats.Attack}";
        DefenseText.text = $"Attack: {hero.Stats.Defense}";
    }
}