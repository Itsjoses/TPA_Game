using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Slider slider;
    public EnemyStat enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hp = enemy.CurrenthealthEnemy / enemy.maxhealthEnemy;
        slider.value = hp;
    }
}
