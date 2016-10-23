using UnityEngine;
using System.Collections;

public class DoubleDoor : Action
{

    public override void Use()
    {
        gameObject.GetComponent<Animator>().SetBool("isOpen", true);
    }
}
