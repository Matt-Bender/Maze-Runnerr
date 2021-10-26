using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool hasRedKey = false;
    private bool hasBlueKey = true;
    private bool hasGreenKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickupRedKey()
    {
        hasRedKey = true;
    }
    public void PickupBlueKey()
    {
        hasBlueKey = true;
    }
    public void PickupGreenKey()
    {
        hasGreenKey = true;
    }
    public bool CheckRedKey()
    {
        return hasRedKey;
    }
    public bool CheckBlueKey()
    {
        return hasBlueKey;
    }

    public bool CheckGreenKey()
    {
        return hasGreenKey;
    }
}
