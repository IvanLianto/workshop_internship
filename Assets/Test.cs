using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Debug.Log("Ini GetKey");
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("Ini GetKeyDown");
        //}
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    Debug.Log("Ini GetKeyUp");
        //}
        InputAxis();
    }

    public void InputAxis()
    {
        float test = Input.GetAxis("Horizontal");
        Debug.Log(test);
    }

}
