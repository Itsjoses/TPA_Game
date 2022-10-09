using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] targetposition;
    [SerializeField] private Animator anim;
    private int targetpositionidx;
    public Transform Player;
    private NavMeshAgent navMeshAgent;
    public Vector3 target;
    public bool patrol = true;

    [SerializeField] private GameObject hpBar;
     
    void Awake()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        UpdatePatrol();
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        PatrolLogic();
        chaseLogic();
       
    }

    void chaseLogic()
    {
        Vector3 playerposition = Player.position;
        if (Vector3.Distance(transform.position, playerposition) <= 3)
        {
            navMeshAgent.speed = 6f;
            anim.SetBool("isAttack", true);
            navMeshAgent.isStopped = true;
        }   
        else if (Vector3.Distance(transform.position, playerposition) <= 15)
        {
            navMeshAgent.speed = 6f;
            anim.SetBool("isRun", true);
            anim.SetBool("isAttack", false);
            patrol = false;
            target = Player.position;
            navMeshAgent.SetDestination(target);
            hpBar.SetActive(true);
            navMeshAgent.isStopped = false;
        }   
        else
        {
            navMeshAgent.speed = 3.5f;
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack", false);
            patrol = true;
            hpBar.SetActive(false);
        }
    }

    void PatrolLogic()
    {
        if (Vector3.Distance(transform.position, target) < 1 && patrol == true)
        {
            Patrol();
            UpdatePatrol();
        }
    }
    
    void Patrol()
    {
        target = targetposition[targetpositionidx].position;
        navMeshAgent.SetDestination(target);
    }

    void UpdatePatrol()
    {
        int temptargetpositionidx = Random.Range(0, targetposition.Length);
        if (targetpositionidx == temptargetpositionidx) UpdatePatrol();
        else targetpositionidx = temptargetpositionidx;
        // if (targetpositionidx == targetposition.Length) targetpositionidx = 0;
    }
}
