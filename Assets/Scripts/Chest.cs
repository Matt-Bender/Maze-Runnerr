using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator chestAnim;
    // Start is called before the first frame update
    void Start()
    {
        chestAnim = GetComponent<Animator>();
    }
    public void OpenChest()
    {
        chestAnim.SetTrigger("openChest");
    }
}
