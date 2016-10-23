using UnityEngine;
using System.Collections;

public class User : MonoBehaviour
{
    public new Camera camera;
    RaycastHit hit;
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "usable" && Input.GetKeyDown(KeyCode.F))
            {
                GameObject obj = hit.collider.gameObject;
                Action action = (Action)obj.GetComponentInParent(typeof(Action));
                action.Use();
            }
        }
	}
}
