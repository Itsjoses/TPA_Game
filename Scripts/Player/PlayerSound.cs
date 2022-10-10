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
    [SerializeField] private AudioClip[] walksound;
    [SerializeField] private AudioSource walknrunsound;

    private float step_cooldown;
    private float walksound_cooldown;
    private float totalwalksound_cooldown;
    private float totalstep_cooldown = 0f;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        playerrun();
        playerwalksound();
    }

    void playerwalksound()
    {
        if (cc.velocity.sqrMagnitude >= 0.1f)
        {
            totalwalksound_cooldown += Time.deltaTime;
            if (totalwalksound_cooldown > walksound_cooldown)
            {
                walknrunsound.volume = Random.Range(0.3f, 0.6f);
                walknrunsound.clip = walksound[Random.Range(0, walksound.Length)];
                walknrunsound.Play();
                totalwalksound_cooldown = 0f;
            }

        }
        else totalwalksound_cooldown = 0f;
    }

    void playerrun()
    {
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

    public void set_walknrunCooldown(float walksound_cooldown)
    {
        this.walksound_cooldown = walksound_cooldown;
    }


}
