using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    enum color {Blue, Red, Green};
    [SerializeField] color currentColor;

    private ItemManager playerItemManager;

    // Start is called before the first frame update
    void Start()
    {
        playerItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckForKey()
    {
        if(currentColor == color.Blue)
        {
            if (playerItemManager.CheckBlueKey())
            {
                return true;
            }
        }
        else if(currentColor == color.Red)
        {
            if (playerItemManager.CheckRedKey())
            {
                return true;
            }
        }
        else if(currentColor == color.Green)
        {
            if (playerItemManager.CheckGreenKey())
            {
                return true;
            }
        }
        return false;
    }
}
