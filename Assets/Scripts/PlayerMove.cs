using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed;


    CharacterController _character;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirect = transform.forward * verticalInput + transform.right * horizontalInput;

        moveDirect.y -= 9.81f * Time.deltaTime;

        _character.Move(moveDirect * speed * Time.deltaTime);
    }
}
