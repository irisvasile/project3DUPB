using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISpellTooltip : MonoBehaviour
{
    public Hero hero;
    private TMP_Text tooltip;
    public int index;

    public void Start()
    {
        tooltip = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ++index;
            if (index > 4)
                index = 0;
        }
        if (index == -1)
            tooltip.text = "Apasa P ca sa vezi descrierea fiecarui spell.\nAsta e doar placeholder.";
        else
        {
            Spell spell = hero.spells[index];
            if (spell == null)
                tooltip.text = "No spell. (Placeholder text).";
            else
                tooltip.text = spell.spellName + "\n" + spell.GetDescription();
        }
    }
}
