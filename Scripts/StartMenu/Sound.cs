using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource startbutton;
    // Start is called before the first frame update
    public void playsound()
    {
        startbutton.Play();
    }
}
