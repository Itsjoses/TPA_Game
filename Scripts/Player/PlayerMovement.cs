using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField] private Transform cam;
    [SerializeField] public Animator anim;
    [SerializeField] private PlayerStatus PlayerStatus;
    private PlayerSound playersound;
    private int speed = 10;
    private float gravity = 9.8f;
    private float _directionY;
    float turn;

    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        playersound = GetComponent<PlayerSound>();
    }

    // Update is called once per frame
    void Update()
    {
        run(); 
        move();
    }

    void move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0, Vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turn, 0.1f);

            _directionY = moveDirection.y;
            if (anim.GetBool("isstrafe") == true)
            {
                transform.rotation = Quaternion.Euler(0f,transform.rotation.y + cam.eulerAngles.y,0f);
            }
            else transform.rotation = Quaternion.Euler(0, angle, 0);
            moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            moveDirection = moveDirection.normalized;
            moveDirection.y = _directionY;

            
        }
        else
        {
            moveDirection.x = moveDirection.x * 0;
            moveDirection.z = moveDirection.z * 0;
        }
        moveDirection.y = moveDirection.y - gravity;
        moveDirection.x = moveDirection.x * speed;
        moveDirection.z = moveDirection.z * speed;
        cc.Move(moveDirection * Time.deltaTime);
    }

    void run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10 + (PlayerStatus.getAgi() - 1);
            playersound.set_stepCooldown(10f);
            playersound.set_walknrunCooldown(0.25f);
        }
        else
        {
            speed = 5 + (PlayerStatus.getAgi() - 1);
            playersound.set_stepCooldown(9999f);
            playersound.set_walknrunCooldown(0.5f);
        }
    }
}
