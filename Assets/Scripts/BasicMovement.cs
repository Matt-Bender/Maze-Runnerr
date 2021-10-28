using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;

    private Vector2 inputMovement;
    private Vector2 outputMovement;

    private float goUp;
    private float goRight;

    private float upInput;
    private float rightInput;

    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        BasicMove();
    }

    private void BasicMove()
    {
        outputMovement = new Vector2(inputMovement.x * speed * Time.deltaTime, inputMovement.y * speed * Time.deltaTime);
        rb.velocity = new Vector3(outputMovement.x, 0, outputMovement.y);
    }
    public void Movement(InputAction.CallbackContext context)
    {
        //Debug.Log(context.control);
        inputMovement = context.ReadValue<Vector2>();
        //transform.forward = rb.velocity.normalized;
        //transform.forward = context.ReadValue<Vector2>();
    }
}
