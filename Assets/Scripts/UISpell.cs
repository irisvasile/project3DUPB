using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISpell : MonoBehaviour
{
    public Hero hero;
    public TMP_Text cooldownText;
    public TMP_Text manaCostText;
    public int index;
    [HideInInspector]
    public Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Sprite spr = Resources.Load<Sprite>("Textures/Spells/" + hero.spells[index].spellName) as Sprite;
        if (!spr)
            spr = Resources.Load<Sprite>("Textures/Spells/Missing") as Sprite;
        image.sprite = spr;
        float cooldown = hero.spells[index].cooldown;
        if (cooldown > 0)
        {
            image.color = Color.grey;
            cooldownText.text = Mathf.CeilToInt(cooldown) + "";
        }
        else
        {
            image.color = Color.white;
            cooldownText.text = "";
        }
        manaCostText.text = hero.spells[index].manaCost + "";
    }
}
