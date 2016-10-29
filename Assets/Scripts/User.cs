using UnityEngine;
using System.Collections;
//using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public new Camera camera;
    //FirstPersonController firstPersonControllerScript;
    public float speed;
    RaycastHit hit;

    void Start ()
    {
        //firstPersonControllerScript = (FirstPersonController)gameObject.GetComponent(typeof(FirstPersonController));
    }

	void Update ()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "usable" && Input.GetKeyDown(KeyCode.F))
            {
                GameObject obj = hit.collider.gameObject;
                Action action = (Action)obj.GetComponentInParent(typeof(Action));
                action.Use();
            }
        }
	}

    public delegate void afterMove();

    public void Move(Vector3 target, afterMove after)
    {
        StartCoroutine(MovePlayer(target, after));
    }

    IEnumerator MovePlayer(Vector3 target, afterMove after)
    {
        //firstPersonControllerScript.enabled = false;
        while (Vector3.Distance(target, gameObject.transform.position) > 0.6f)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, step);
            yield return null;
        }
        //firstPersonControllerScript.enabled = true;
        after();
    }
}
