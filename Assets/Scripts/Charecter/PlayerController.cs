using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Character
{
    int jumpTimes = 0;
    float xRotation = 0;
    float sens;
    [SerializeField] Transform Camera;
    [SerializeField] BoolVariable pause;
    private void Update()
    {
        if (pause.value)
        {
            return;
        }
        sens = PlayerPrefs.GetFloat("Sens");
        Move();
        Jump();
        Look();
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity -= new Vector3(0, -2, 0) * Physics.gravity.y * Time.deltaTime;
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move;

        move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += move * Time.deltaTime * runSpeed;
        }
        else
        {
            transform.position += move * Time.deltaTime * moveSpeed;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimes<2)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,0, GetComponent<Rigidbody>().velocity.z);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * jumpPower,ForceMode.Impulse);
            jumpTimes++;
        }
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.fixedDeltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 3)
        {
            jumpTimes = 0;
        }
    }
}
