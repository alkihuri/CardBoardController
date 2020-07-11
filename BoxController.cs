using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Transform point;
    public bool keyOn;
    // Start is called before the first frame update
    void Start()
    {
        keyOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="ToGrab" && transform.childCount<3)
        {
            keyOn = true;
            other.transform.position = point.transform.position;///Vector3.Slerp(other.transform.position, point.transform.position, 0.9f);
            other.transform.SetParent(transform);
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.gameObject.GetComponent<CubeController>().setOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "ToGrab" || transform.childCount == 2)
        {
            keyOn = false;
            other.gameObject.GetComponent<CubeController>().setOn = false ;
        }
    }
}
