using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (isInteracting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(currObject);
                isInteracting = false;
            }
        }
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
}
