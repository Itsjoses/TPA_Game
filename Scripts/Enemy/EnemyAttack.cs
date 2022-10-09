using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PlayerSound playersound;
    public EnemyStat enemystat;
    public PlayerStatus enemy;
    private void OnTriggerEnter(Collider other)
    {
        float atk = enemystat.getattack();
        if (other.tag == "Player")
        {
            playersound.hitaudio();
            enemy.sethealth(atk);
        }
    }
}
