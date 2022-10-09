using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController cc;
    [SerializeField] private AudioSource run;
    [SerializeField] private AudioSource levelUp;
    [SerializeField] private AudioClip[] levelupClip;
    [SerializeField] private AudioSource punch;
    [SerializeField] private AudioClip[] punchClip;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioClip[] hitClip;
    [SerializeField] private AudioSource deadth;
    [SerializeField] private AudioSource sword;

    private float step_cooldown;
    private float totalstep_cooldown = 0f;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        playerrun();
    }

    void playerrun()
    {
        /*float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0, Vertical).normalized;*/
        if (cc.velocity.sqrMagnitude >= 0.1f)
        {
            totalstep_cooldown += Time.deltaTime;
            if(totalstep_cooldown > step_cooldown)
            {
                run.Play();
                totalstep_cooldown = 0f;
            }
            
        }else totalstep_cooldown = 0f;
    }

    public void levelupaudio()
    {
        levelUp.clip = levelupClip[Random.Range(0, levelupClip.Length)];
        levelUp.Play();
    } 

    public void punchaudio()
    {
        punch.clip = punchClip[Random.Range(0, punchClip.Length)];
        punch.Play();
    }

    public void hitaudio()
    {
        hit.clip = hitClip[Random.Range(0, hitClip.Length)];
        hit.Play();
    }

    public void deathaudio()
    {
        deadth.Play();
    }

    public void swordaudio()
    {
        sword.Play();
    }

    public void set_stepCooldown(float step_cooldown)
    {
        this.step_cooldown = step_cooldown;
    }


}
