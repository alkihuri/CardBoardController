using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
      List<Text> textList;
    public string key; 
    public bool setOn;
    Quaternion startQuternion;
    // Start is called before the first frame update
    void Start()
    { 
        setOn = false;
        textList = GetComponentsInChildren<Text>().ToList();
        startQuternion = transform.rotation;
    }

    private void Update()
    {
        foreach (Text text in textList)
        {
            text.text = key;
        }

        GetComponentInChildren<Light>().enabled = setOn;
        transform.rotation = Quaternion.Slerp(transform.rotation, startQuternion, 0.1f);
    }

}
