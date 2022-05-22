using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAim : MonoBehaviour
{
    public Camera cam;

    public Transform target;
    public GameObject targetTool;
    public ShipController ship; 
    public RaycastHit objectHit;
    // Update is called once per frame
    void Update()
    {
        /*Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit)){
            print("I'm looking at " + hit.collider);
        }*/

        
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, 150))
        {
            //Debug.Log("Raycast hitted to: " + objectHit.collider);
            
            if (objectHit.collider != null)
            {
                target = objectHit.transform;
                targetTool.SetActive(true);
                targetTool.transform.position = cam.WorldToScreenPoint(target.position);
                
            }
            else
            {
                targetTool.SetActive(false);
            }
        }
        else
        {
            targetTool.SetActive(false);
        }

        /*if (hit.collider != null){
            if(hit.transform.gameObject.tag.Equals("autoAim")){
                target = hit.transform;
                //targetTool.SetActive(true);
                //targetTool.transform.position = cam.WorldToScreenPoint(target.position + new Vector3(0,2,0));
            }else if(hit.transform.gameObject.tag != ("autoAim")){
                //targetTool.SetActive(false);
            }
        }else{
            //targetTool.SetActive(false);
        }*/
    }
}
