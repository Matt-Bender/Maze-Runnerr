using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Camera cam;

    private float goUp;
    private float goRight;

    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        BasicMove();

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    private void BasicMove()
    {
        //Using getaxis for smoothing movement
        goUp = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        goRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector3(goRight, goUp, 0);
    }
}
