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
        playerstatus.canAttack = false;
    }

    void attackcooldown()
    {
        animator.SetBool("punch 0", false);
        animator.SetBool("punchleft", false);
        animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 0);
    }

    void attack()
    {
        if (Input.GetMouseButtonDown(0) && comboAttack == 0 && pickweapon.getequip() == false)
        {
            playersound.punchaudio();
            playerstatus.canAttack = true;
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("ispunchright"  );
            comboAttack++;
        }else if(Input.GetMouseButtonDown(0) && comboAttack > 0 && pickweapon.getequip() == false)
        {
            playersound.punchaudio();
            playerstatus.canAttack = true;
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("ispunchleft");
            comboAttack = 0;
        }

        if(Input.GetMouseButtonDown(0) && pickweapon.getequip() == true)
        {
            playersound.swordaudio();
            playerstatus.canAttack = true;
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("isMelee");
        }
    }

    void roll()
    {
        if (Input.GetMouseButtonDown(1) && animator.GetBool("isWalk") == true)
        {
            animator.SetBool("isRoll", true);
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

}
