using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Animator background;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void fadeout()
    {
        anim.SetBool("isFade", true);
        background.SetBool("isFade", true);
    }
}
