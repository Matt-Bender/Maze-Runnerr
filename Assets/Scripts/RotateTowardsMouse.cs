using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] private float smoothness;

    Vector2 playerRot;
    public PlayerInput playerinput = new PlayerInput();

    //Keeps track if current control scheme is keyboard or gamepad
    bool controlKeyboard = true;
    // Start is called before the first frame update
    void Start()
    {
        if(smoothness <= 0)
        {
            smoothness = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerinput.currentControlScheme == "Keyboard")
        {
            controlKeyboard = true;
            RotateMouse();
        }
        else if(playerinput.currentControlScheme == "Gamepad")
        {
            controlKeyboard = false;
        }
    }

    private void RotateMouse()
    {
        //Player always rotates towards mouse position
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness * Time.deltaTime);
        }
    }

    public void Rotation(InputAction.CallbackContext context)
    {
        if (context.performed && !controlKeyboard)
        {
            transform.forward = new Vector3(playerRot.x, 0, playerRot.y);
        }
        playerRot = context.ReadValue<Vector2>();
    }
}
