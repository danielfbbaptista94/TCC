using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    
    private Rigidbody2D _Rigidbody2D;
    private Vector3 _Vector3;
    private Animator _Animator;

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _Vector3 = Vector3.zero;
        _Vector3.x = Input.GetAxisRaw("Horizontal");
        _Vector3.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMovement();
    }

    void UpdateAnimationAndMovement()
    {
        if (_Vector3 != Vector3.zero)
        {
            MoveCharacter();
            _Animator.SetFloat("moveX", _Vector3.x);
            _Animator.SetFloat("moveY", _Vector3.y);
            _Animator.SetBool("moving", true);
        }
        else
        {
            _Animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        _Vector3.Normalize();
        _Rigidbody2D.MovePosition(transform.position + _Vector3 * speed * Time.deltaTime);
    }
}
