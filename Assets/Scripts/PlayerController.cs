using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator;

    private CharacterController _characterController;
    private float _fallVelosity = 0;
    private Vector3 _moveVector;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }
    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        var rudDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            rudDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            rudDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            rudDirection = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            rudDirection = 4;
        }

        animator.SetInteger("run direction", rudDirection);
    }

    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelosity = -jumpForce;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * speed * Time.deltaTime);

        //Fall and jump
        _fallVelosity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelosity * Time.fixedDeltaTime);

        //Stop fall if on the ground
        if (_characterController.isGrounded)
        {
            _fallVelosity = 0;
        }
    }
}
