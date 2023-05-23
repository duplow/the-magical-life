using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Vector2 cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        cameraRotation = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movimentAxis = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            movimentAxis.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movimentAxis.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movimentAxis.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movimentAxis.x = 1;
        }

        // Horizontal moviment
        movimentAxis = movimentAxis.normalized;
        Vector3 movimentDirection = new Vector3(movimentAxis.x, 0f, movimentAxis.y);
        transform.position += movimentDirection * moveSpeed * Time.deltaTime;

        // Jump
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
        }

        // Camera rotation
        this.cameraRotation.x += Input.GetAxis("Mouse X");
        this.cameraRotation.y += Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(-this.cameraRotation.y, this.cameraRotation.x, 0f);
    }

    void OldStyleMoviment()
    {
        if (Input.GetKeyDown("w"))
        {
            Debug.Log("Frente");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
        }

        if (Input.GetKeyDown("s"))
        {
            Debug.Log("Costas");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
        }

        if (Input.GetKeyDown("a"))
        {
            Debug.Log("Esquerda");
            GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, 0);
        }

        if (Input.GetKeyDown("d"))
        {
            Debug.Log("Direita");
            GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
        }
    }
}
