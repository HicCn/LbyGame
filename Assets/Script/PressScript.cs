using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressScript : MonoBehaviour
{
    // Start is called before the first frame update
    //���ǳ����Ŀؼ�������������״̬����һ�γ��֣���Ҫ�԰��½����жϣ��м�Ĳ�����Ҫ���ֿո��£����һ�γ�����Ҫ��̧���ж�
    public static int index_box;//��һ�γ��ָ�ֵ1�����һ�γ��ָ�ֵ0������ʱ��ֵ2
    public static bool index_console = true;//̧��ǰ��Ϊtrue
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
        //�����ж���ʱ,��û̧��
         if (index_console && transform.position.x > -2 + gamer.transform.position.x && transform.position.x < 2 + gamer.transform.position.x)
        {
            if (index_cur == 1) //��һ�γ���
            {
                if (Input.GetKeyDown(KeyCode.Space))//�������ո�
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

            //�������̧��ո�Ĳ���
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
        //�뿪ʱ���¸�index_console��ֵΪtrue
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
