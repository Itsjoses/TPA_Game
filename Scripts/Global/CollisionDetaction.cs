using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetaction : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus playerstatus;
    // private bool hitted = false;
    
    private void OnTriggerEnter(Collider other)
    {
        float atk = playerstatus.str * 20;
        if (other.tag == "Enemy")
        {
            Debug.Log(other.name);
            EnemyStat enemy = other.GetComponent<EnemyStat>();
            
            enemy.sethealth(atk);
            if(enemy.gethealth() <= 0)
            {
                enemy.destory();
            }
           
        }
    }
}
