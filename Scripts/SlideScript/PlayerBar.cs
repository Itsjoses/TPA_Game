using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBar : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Text hpText;
    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider xpBar;
    [SerializeField] private Text level;
    private void Awake()
    {
        
    }

    private void Update()
    {
        HpBar();
        XpBar();
        leveltext();
    }

    void HpBar()
    {
        float fillslider = playerStatus.currentHealth / playerStatus.maxHealth;

        hpText.text = playerStatus.currentHealth.ToString() + " / " + playerStatus.maxHealth.ToString();
        hpBar.value = fillslider;
    }

    void XpBar()
    {
        float fillslider = (float)playerStatus.currentXp / (float)playerStatus.maxXp;
        xpBar.value = fillslider;
    }

    void leveltext()
    {
        level.text = "Lvl. " + playerStatus.getLevel().ToString();
    }

}
