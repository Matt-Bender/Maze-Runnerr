using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    enum color {Blue, Red, Green};
    [SerializeField] color currentColor;

    private ItemManager playerItemManager;

    Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerItemManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemManager>();
        doorAnim = GetComponent<Animator>();
    }
    public bool CheckForKey()
    {
        if(currentColor == color.Blue)
        {
            if (playerItemManager.CheckBlueKey())
            {
                doorAnim.SetTrigger("openDoor");
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
