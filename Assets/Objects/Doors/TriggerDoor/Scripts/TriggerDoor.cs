using UnityEngine;
using System.Collections;
using System;

public class TriggerDoor : Action
{

    public override void Use()
    {
        if (gameObject.GetComponent<Animator>().GetBool("isOpen"))
        {
            gameObject.GetComponent<Animator>().SetBool("isOpen", false);
            gameObject.transform.Find("door").GetComponent<Animator>().SetBool("isOpen", false);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isOpen", true);
            gameObject.transform.Find("door").GetComponent<Animator>().SetBool("isOpen", true);
        }
    }
}
