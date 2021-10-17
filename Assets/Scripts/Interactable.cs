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
    //When set true such as for chests or doors
    //Will no longer be able to be interactable after being opened
    private bool hasInteracted = false;
    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    //Sets color to white when interacting with
    public void SetInteractable(bool setColor)
    {
        isInteractable = setColor;
        if (isInteractable && !hasInteracted)
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
        if (!hasInteracted)
        {
            if (currentObject == intObject.Door)
            {
                if (GetComponent<Door>().CheckForKey())
                {
                    Destroy(gameObject);
                    //Door is no longer interactable
                    hasInteracted = true;
                }
                else
                {
                    Debug.Log("Missing Key");
                }
            }
            else if (currentObject == intObject.Chest)
            {
                GetComponent<Chest>().OpenChest();
                //Chest is no longer interactable
                hasInteracted = true;
            }
        }

    }
}
