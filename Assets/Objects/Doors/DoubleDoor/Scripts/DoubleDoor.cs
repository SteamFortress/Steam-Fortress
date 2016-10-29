using UnityEngine;
using System.Collections;

public class DoubleDoor : Action
{
    Player playerScript;

    public override void Use()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("isOpen")) {
            playerScript.Move(gameObject.transform.Find("point").transform.position, playAnimation);
        }
    }

    void Start ()
    {
        playerScript = (Player)GameObject.FindWithTag("Player").GetComponent(typeof(Player));
    }

    public void playAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("isOpen", true);
    }
}
