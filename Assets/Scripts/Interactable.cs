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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteractable(bool setInt)
    {
        isInteractable = setInt;
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
