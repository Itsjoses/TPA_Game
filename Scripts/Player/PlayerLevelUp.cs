using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUp : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerstatus;
    [SerializeField] private Text[] statusText;
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(playerstatus.getPoint() > 0)
        {
            canvas.SetActive(true);
        }else canvas.SetActive(false);
        setText();
    }

    public void setText()
    {
        statusText[0].text = playerstatus.getAgi().ToString();
        statusText[1].text = playerstatus.getStr().ToString();
        statusText[2].text = playerstatus.getPow().ToString();
        statusText[3].text = "Status Point(s): " + playerstatus.getPoint().ToString();
    }

    public void agiup()
    {
        playerstatus.setAgi();
        playerstatus.setPoint();
    }

    public void strup()
    {
        playerstatus.setStr();
        playerstatus.setPoint();
    }

    public void powup()
    {
        playerstatus.setPow();
        playerstatus.setPoint();
    }
}
