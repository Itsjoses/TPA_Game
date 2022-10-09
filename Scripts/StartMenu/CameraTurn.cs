using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.Rotate(new Vector3(0f, Random.Range(0.1f, 5f) * Time.deltaTime, 0f));
    }
}
