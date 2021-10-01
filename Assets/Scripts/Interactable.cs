using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
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
}
