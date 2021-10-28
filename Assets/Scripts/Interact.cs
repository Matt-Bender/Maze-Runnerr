using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    //boolean to ensure only one interactable object at a time
    private bool isInteracting = false;
    private GameObject currObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Left click to destroy... Later will change to activate object
        //if (isInteracting)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        currObject.GetComponent<Interactable>().Interact();
        //        isInteracting = false;
        //    }
        //}
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && isInteracting == false)
        {
            isInteracting = true;
            other.GetComponent<Interactable>().SetInteractable(true);
            currObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInteracting = false;
            other.GetComponent<Interactable>().SetInteractable(false);
        }
    }

    public void InteractObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isInteracting)
            {
                currObject.GetComponent<Interactable>().Interact();
                isInteracting = false;
            }
        }
        //Left click to destroy... Later will change to activate object

    }
}
