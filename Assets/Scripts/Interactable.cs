using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    enum intObject {Chest, Door};
    [SerializeField] intObject currentObject;

    [SerializeField] private Material defaultMat;
    [SerializeField] private Material highlightMat;

    private MeshRenderer meshRender;

    private bool isInteractable = false;
    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    //Sets color to white when interacting with
    public void SetInteractable(bool setColor)
    {
        isInteractable = setColor;
        if (isInteractable)
        {
            meshRender.material = highlightMat;
        }
        else
        {
            meshRender.material = defaultMat;
        }
    }
    //This is called whenever player is looking at object and left clicks ie...(Door opens with key, chest opens)
    public void Interact()
    {
        if(currentObject == intObject.Door)
        {
            if (GetComponent<Door>().CheckForKey())
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Missing Key");
            }
        }
        else if(currentObject == intObject.Chest)
        {
            Destroy(gameObject);
        }
    }
}
