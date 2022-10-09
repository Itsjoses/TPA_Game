using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public int x,y,enemyCount = 0;
    private float spawncooldown = 2f;
    private float total_cooldown;

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpawn();
    }

    void Spawn()
    {
            x = Random.Range(1, 30);
            y = Random.Range(1, 30);
            GameObject duplciate = Instantiate(enemy, new Vector3(transform.position.x + x, 2, transform.position.z + y), Quaternion.identity);
            duplciate.SetActive(true);
            enemyCount++;
    }

    void cooldownSpawn()
    {
        if (enemyCount < 5)
        {
            total_cooldown += Time.deltaTime;
            if (total_cooldown > spawncooldown)
            {
                total_cooldown = 0f;
                Spawn();
            }
        }
        
    }
}
