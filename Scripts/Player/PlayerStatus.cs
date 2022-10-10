using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private PlayerSound playersound;
    public bool canAttack = false;
    public int level = 1;
    public float maxHealth = 1000f;
    public float currentHealth = 1000f;
    public int currentXp = 0;
    public int maxXp = 100;
    [SerializeField] private int upPoint = 0;
    public int str = 1;
    public int agi = 1;
    public int pow = 1;
    private bool Death = false;

    private void Awake()
    {
        playersound = GetComponent<PlayerSound>();
    }

    private void Update()
    {
        levelup();
        DeathMenu();
    }

    private void DeathMenu()
    {
        if(currentHealth <= 0 && Death == false)
        {
            playersound.deathaudio();
            anim.SetBool("isDeath", true);
            Death = true;
        }
    }

    private void levelup()
    {
        if(currentXp >= maxXp)
        {
            playersound.levelupaudio();
            maxHealth += level * 250 + ((str - 1) * 250);
            currentHealth = maxHealth;
            level+= 1;
            maxXp *= level;
            currentXp = 0;
            upPoint++;
        }
    }


    public void sethealth(float getAttack)
    {
        currentHealth -= getAttack;
    }

    public int getXp()
    {
        return level;
    }

    public void setXp(int Xpget)
    {
        currentXp += Xpget;
    }

    public void setAgi()
    {
        this.agi++;
    }

    public void setStr()
    {
        this.str++;
    }

    public void setPow()
    {
        this.pow++;
    }

    public void setPoint()
    {
        this.upPoint--;
    }

    public int getAgi()
    {
        return agi;
    }

    public int getStr()
    {
        return str;
    }

    public int getPow()
    {
        return pow;
    }

    public int getPoint()
    {
        return upPoint;
    }

    public int getLevel()
    {
        return level;
    }

    public void setAttack()
    {
        canAttack = true;
    }

    public void resetAttack()
    {
        canAttack = false;
    }

    public bool getAttack()
    {
        return canAttack;
    }

}
