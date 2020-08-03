using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBuff : MonoBehaviour
{
    public Hero hero;
    public TMP_Text durationText;
    public TMP_Text stacksText;
    public int index;
    [HideInInspector]
    public Image border;
    public Image image;

    public void Start()
    {
        border = GetComponent<Image>();
    }

    private void Update()
    {
        Buff b = null;
        if (hero.buffs.Count > index)
        {
            b = hero.buffs[index];
        }
        if (b == null || b is BuffInstant)
        {
            border.enabled = false;
            image.enabled = false;
            durationText.text = "";
            stacksText.text = "";
            return;
        }
        border.enabled = true;
        image.enabled = true;
        Debug.LogWarning(b.buffName);
        Sprite spr = Resources.Load<Sprite>("Textures/Spells/" + b.buffName) as Sprite;
        if (!spr)
            spr = Resources.Load<Sprite>("Textures/Spells/Missing") as Sprite;
        image.sprite = spr;
        durationText.text = Mathf.CeilToInt(hero.buffDuration[b]) + "";
        if (b.stacksMax > 1)
            stacksText.text = hero.buffStacks[b] + "";
        else
            stacksText.text = "";
    }

}
