using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdle : MonoBehaviour
{
    [SerializeField] private PickWeapon pickupweapon;
    private float ampli = 0.1f;
    private float freq = 1.2f;
    Vector3 offset = new Vector3();
    Vector3 position = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickupweapon.getequip() == true)
        {
            ampli = 0f;
        }
        transform.Rotate(new Vector3(0f, 0f, 0.3f));
        position = offset;
        position.y = position.y + Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * ampli;
        transform.position = position;
    }
}
