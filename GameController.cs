using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public GameObject cube;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
         
        char[] word_array = GameStates.originalWord.ToCharArray();

        for(int i=0;i<word_array.Length ;i++)
        {
            MakeCude(word_array[i]);
            Debug.Log(word_array[i]);
            MakeBox(i);
        }
    }

    public void MakeCude(char key)
    {
        GameObject newOne = Instantiate(cube, new Vector3(Random.Range(-5,5), Random.Range(0, 4), Random.Range(0, 3)), Quaternion.identity);
        newOne.GetComponent<CubeController>().key = key.ToString();
        newOne.AddComponent<Rigidbody>();
        newOne.tag = "ToGrab";
    }
    public void MakeBox(int index )
    {
        GameObject newOne = Instantiate(box, new Vector3(index *1.3f - 4.5f, 0.5f, -2 + Random.Range(0,0.8f)), new Quaternion(0, Random.Range(0, 25),0,0));   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
