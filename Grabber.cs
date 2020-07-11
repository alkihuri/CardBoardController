using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    RaycastHit objOnLine;
    Transform originalOfObject, toSetTransform;
    public bool isGrabed;
    // Start is called before the first frame update
    void Start()
    {
        isGrabed = false;
        toSetTransform = GameObject.Find("PostitionForTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out objOnLine))
        {
          
                originalOfObject = objOnLine.transform;
                
           
        }
         if(Input.GetButton("Fire1"))
        {
            isGrabed = true;
        }
         else
        {
            isGrabed = false;
        }
        if(objOnLine.transform.gameObject.tag == "ToGrab")
        {
            if (isGrabed && toSetTransform.childCount < 1) 
            {
                Destroy(objOnLine.transform.gameObject.GetComponent<Rigidbody>());
                // objOnLine.transform.position = toSetTransform.position;
                objOnLine.transform.SetParent(toSetTransform); 
                objOnLine.transform.position = Vector3.MoveTowards(objOnLine.transform.position, toSetTransform.position,1000);
                objOnLine.transform.gameObject.GetComponent<CubeController>().setOn = false;
               // objOnLine.transform.position = Vector3.Slerp(objOnLine.transform.position, toSetTransform.position, 0.7f);
              
            }
            if(Input.GetButtonUp("Fire1"))
            {
                objOnLine.transform.gameObject.AddComponent<Rigidbody>();
                 
                objOnLine.transform.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 850);
                objOnLine.transform.SetParent(null); 
            }
        }
        
    }
}
