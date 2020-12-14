using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _vector3;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _vector3 = Vector3.zero;
        _vector3.x = Input.GetAxisRaw("Horizontal");
        _vector3.y = Input.GetAxisRaw("Vertical");

        if(_vector3 != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        _vector3.Normalize();
        _rigidbody2D.MovePosition(transform.position + _vector3 * speed * Time.deltaTime);
    }
}
