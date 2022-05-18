using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidBody;
    private float horizontalInput, verticalInput;
    [SerializeField] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(horizontalInput, 0, verticalInput);
        playerMovement *= speed;
        rigidBody.AddForce(playerMovement);
    }

}
