using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private PlayerStatus playerstatus;
    [SerializeField] private EnemySpawn enemyspawn;
    public bool canAttack = false;
    [SerializeField] public float maxhealthEnemy = 100f;
    [SerializeField] public float CurrenthealthEnemy = 100f;
    [SerializeField] private float atkEnemy = 4f;
    [SerializeField] private int xp = 20;
    private bool enemyCanAttack = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void sethealth(float getAttack)
    {
        CurrenthealthEnemy -= getAttack;
    }

    public float gethealth()
    {
        return CurrenthealthEnemy;
    }

    public float getattack()
    {
        return atkEnemy;
    }

    public void deadthanimation()
    {
        
        anim.SetBool("isDeath", true);
    }

    public void destory()
    {
        enemyspawn.enemyCount -= 1;
        playerstatus.setXp(xp);
    }

    public void deleteBody()
    {
        
        Destroy(this.gameObject);
    }
    
}
