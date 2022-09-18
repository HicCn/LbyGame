using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressScript : MonoBehaviour
{
    // Start is called before the first frame update
    //这是长条的控件、长条有三种状态，第一次出现，需要对按下进行判断，中间的部分需要保持空格按下，最后一次出现需要对抬起判断
    public static int index_box;//第一次出现赋值1，最后一次出现赋值0，其他时候赋值2
    public static bool index_console = true;//抬起前都为true
    GameObject gamer;
    int index_cur;

    void Start()
    {
        index_cur = index_box;
        gamer = GameObject.Find("Gamer");
    }

    // Update is called once per frame
    void Update()
    {
        //进入判断区时,且没抬起
         if (index_console && transform.position.x > -2 + gamer.transform.position.x && transform.position.x < 2 + gamer.transform.position.x)
        {
            if (index_cur == 1) //第一次出现
            {
                if (Input.GetKeyDown(KeyCode.Space))//如果点击空格
                {
                    float x_coordinate = Mathf.Abs(transform.position.x - gamer.transform.position.x);
                    if (x_coordinate < 1 && x_coordinate > -1)
                    {
                        operationPerfect();
                    }
                    else
                    {
                        operationbad();
                    }
                }
            }
            else if(index_cur == 2)
            {
                if (!Input.GetKey(KeyCode.Space))
                {
                    index_console = false;
                    operationbad();
                }
            }

            //如果发生抬起空格的操作
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (index_cur == 0)
                {
                    float x_coordinate = Mathf.Abs(transform.position.x - gamer.transform.position.x);
                    if (x_coordinate < 1 && x_coordinate > -1)
                    {
                        Debug.Log("????");
                        operationPerfect();
                    }
                    else
                    {
                        operationbad();
                    }
                }
                else
                {
                    operationbad();
                }
                index_console = false;
            }
        }
        //离开时重新给index_console赋值为true
        if (index_cur == 0 && transform.position.x < -2 + gamer.transform.position.x)
        {
            index_console = true;
        }
    }
    void operationPerfect()
    {
        gamer.GetComponent<Renderer>().material.color = Color.green;

    }
    void operationbad()
    {
        gamer.GetComponent<Renderer>().material.color = Color.red;
        gamer.transform.position = gamer.transform.position + new Vector3(4, 0, 0);
    }
}
