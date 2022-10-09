using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSkyBox : MonoBehaviour
{
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1f);
    }
}
