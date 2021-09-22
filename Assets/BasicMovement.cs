using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;

    private float goUp;
    private float goRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {    }
    private void FixedUpdate()
    {
        BasicMove();   
    }

    private void BasicMove()
    {
        //Using getaxis for smoothing movement
        goUp = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        goRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector3(goRight, 0, goUp);
    }
}
