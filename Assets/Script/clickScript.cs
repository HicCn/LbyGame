using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScript : MonoBehaviour
{
    public GameObject gamer;
    // Start is called before the first frame update
    private bool console_input = true;
    void Start()
    {
        gamer = GameObject.Find("Gamer");
    }

    // Update is called once per frame
    void Update()
    {
        if(console_input && transform.position.x > -2+gamer.transform.position.x && transform.position.x < 2 + gamer.transform.position.x)//进去判定区
        {
            //只能点击一次
            if (Input.GetKeyDown(KeyCode.Space))//如果点击空格
            {
                console_input = false;
                float x_coordinate = Mathf.Abs( transform.position.x - gamer.transform.position.x);
                if(x_coordinate < 1 && x_coordinate > -1)
                {
                    operationPerfect();
                }
                else
                {
                    operationbad();
                }
            }
        }
        if (console_input && transform.position.x < -2 + gamer.transform.position.x)
        {
            operationbad();
            console_input = false ;
        }
    }

    void operationPerfect()
    {
        gamer.GetComponent<Renderer>().material.color = Color.green;

    }
    void operationbad()
    {
        gamer.GetComponent<Renderer>().material.color = Color.red;
        gamer.transform.position = gamer.transform.position + new Vector3(2, 0, 0); 
    }
}
