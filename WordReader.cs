using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordReader : MonoBehaviour
{
    public string word;
    public List<GameObject> cubes;
    // Start is called before the first frame update
    void Start()
    {
        some = GameObject.Find("lastLight").GetComponent<Light>();
        lightPower = 0;
    }
    public Light some;
    float lightPower;
    // Update is called once per frame
    void Update()
    {
        cubes = GameObject.FindGameObjectsWithTag("ToGrab").ToList();
        List<GameObject> orderCubes = cubes.OrderBy(o => o.transform.position.x).ToList();
         orderCubes.Reverse();
        bool lineIsBuilt = false ;
        for(int i =1;i<orderCubes.Count;i++)
        {
            if ((Mathf.Abs(orderCubes[i - 1].transform.position.z) - Mathf.Abs(orderCubes[i].transform.position.z)) < 0.5f)
                lineIsBuilt = true;

        }


        string wordToApprove = "";
        foreach(GameObject cube in orderCubes)
        {
            if (cube.GetComponent<CubeController>().setOn)
                wordToApprove += cube.GetComponent<CubeController>().key;
            else
                wordToApprove += "*";
        }
        word = wordToApprove;
        GameStates.toApprove = word;
        some.intensity += lightPower;
        some.range += lightPower;
     
        if (GameStates.toApprove.Equals(GameStates.originalWord) &&  lineIsBuilt)
        {
             lightPower = 0.9f;
            
           StartCoroutine(FinishScene());
           
           
        }
    }
    IEnumerator FinishScene()
    {
        
        yield return new WaitForSeconds(2);
        foreach (GameObject gm in cubes)
        {
            Destroy(gm);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Start");
    }
}
