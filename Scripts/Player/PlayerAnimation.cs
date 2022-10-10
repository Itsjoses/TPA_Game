using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerstatus;
    [SerializeField] private PlayerSound playersound;
    [SerializeField] private PickWeapon pickweapon;
    private Animator animator;
    private int comboAttack;
    private bool run;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        attack();
        if (direction.magnitude >= 0.1f)
        {
            strafe();
            runstate();
            walk();
            roll();
            animator.SetFloat("directionX", direction.x);
            animator.SetFloat("directionY", Mathf.Abs(direction.z));
        }
        else
        {
            animator.SetBool("isstrafe", false);
            animator.SetBool("isWalk", false);
            animator.SetBool("isRoll", false);
        }
    }

    void attackcooldown()
    {
        animator.SetBool("punch 0", false);
        animator.SetBool("punchleft", false);
        animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 0);
        playerstatus.resetAttack();
    }

    void attack()
    {
        if (Input.GetMouseButtonDown(0) && comboAttack == 0 && pickweapon.getequip() == false)
        {
            playersound.punchaudio();
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("ispunchright"  );
            comboAttack++;
        }else if(Input.GetMouseButtonDown(0) && comboAttack > 0 && pickweapon.getequip() == false)
        {
            playersound.punchaudio();
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("ispunchleft");
            comboAttack = 0;
        }

        if(Input.GetMouseButtonDown(0) && pickweapon.getequip() == true)
        {
            playersound.swordaudio();
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("isMelee");
        }
    }

    void roll()
    {
        if (Input.GetMouseButtonDown(1) && animator.GetBool("isWalk") == true)
        {
            animator.SetBool("isRoll", true);

        }else if(Input.GetMouseButtonDown(1) && animator.GetBool("isRun") == true)
        {
            animator.SetBool("isRoll", true);
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRoll", false);
        }
    }

    void strafe()
    {
        if (Input.GetButtonDown("Horizontal") && animator.GetBool("isWalk") == false)
        {
            animator.SetBool("isstrafe", true);
        }
        else if(Input.GetButtonUp("Horizontal") && animator.GetBool("isstrafe") == true)
        {
            animator.SetBool("isstrafe", false);
        }
    }

    void runstate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool("isWalk"))
        {
            run = true;
            animator.SetBool("isRun", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = false;
            animator.SetBool("isRun", false);
        }
    }

    void walk()
    {
        
        if (Input.GetButton("Vertical"))
        {
            animator.SetBool("isWalk", true);
            animator.SetBool("isstrafe", false);
        }
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal") && animator.GetBool("isstrafe") == false)
        {
            animator.SetBool("isWalk", true);
        }
        else if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal") && animator.GetBool("isWalk") == true)
        {
            animator.SetBool("isWalk", true);
        }
    }

    public void changeDeathscene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void setAttack()
    {
        playerstatus.setAttack();
    }

}
