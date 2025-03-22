using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public Vector3 moveDirection; //holds direction player is moving
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); //Use left, right, a or d inputs
        float z = Input.GetAxisRaw("Vertical"); //Use up, down, w or s inputs

        moveDirection = new Vector3(x, 0, z);
        transform.Translate(moveDirection * Time.fixedDeltaTime * speed);
    }
}
