using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshCollider mc;
    [SerializeField] private Transform player, weaponContainer;
    [SerializeField] private GameObject canvaspickup;
    private float pickRange = 2f;
    private bool equip = false;

    void Start()
    {

    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        canvasPickUp(distanceToPlayer);
        if (equip == false && distanceToPlayer.magnitude <= pickRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }

        if (equip)
        {
            PickUp();
        }
    }

    private void canvasPickUp(Vector3 distanceToPlayer)
    {
        if (distanceToPlayer.magnitude <= pickRange && equip == false)
        {
            canvaspickup.SetActive(true);
        }
        else
        {
            canvaspickup.SetActive(false);
        }
    }

    private void PickUp()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        equip = true;
        rb.isKinematic = true;
        mc.isTrigger = true;
        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        canvaspickup.SetActive(false);
    }

    public bool getequip()
    {
        return equip;
    }
}
