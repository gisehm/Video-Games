using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    public float xRot = 0f;   //how much you tilt up or tilt down
    public float minY = -90f; //min position of the MOUSE in the Y direction
    public float maxY = 90f;  //max position of the MOUSE in the Y direction
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position; //Hey, move the camera to where the player is
        MouseLook();
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, minY, maxY);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
