using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
    public Hero hero;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text xpText;
    public TMP_Text lvlText;

    private void Update()
    {
        healthText.text = Mathf.FloorToInt(hero.health) + "/" + Mathf.FloorToInt(hero.healthMax);
        manaText.text = Mathf.FloorToInt(hero.mana) + "/" + Mathf.FloorToInt(hero.manaMax);
        xpText.text = hero.xp + "/" + hero.ExperienceForLevel(hero.level);
        lvlText.text = "Level " + hero.level;
    }
}
