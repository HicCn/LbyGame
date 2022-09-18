using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class WordScript : MonoBehaviour
{

    static Level Level_Console;
    int index_count = 0;
    char[] Upholstery;

    // Start is called before the first frame update
    public GameObject box_map_click;
    public GameObject box_map_Press;
    public string JsonPath;
    public float OBJ_x;
    public float OBJ_y;

    bool cear = true;

    public class Level
    {
        public float Level_Speed; //������ƶ��ٶ�
        public float Level_Time;//����ĳ��ּ��
        public string Level_Upholstery;//�ؿ������棨�����˽������������ߺ�����޸�
    }

    public Level getJson(string JsonPath)
    {
        string JsonStr;

        StreamReader sr = new StreamReader(Application.dataPath + JsonPath);
        JsonStr = sr.ReadToEnd();
        Level res = JsonUtility.FromJson<Level>(JsonStr);

        return res;
    }

    private float T_times;//���Ƽ����
    void Start()
    {
        Level_Console = getJson(JsonPath);
        BoxScript.Speed = Level_Console.Level_Speed;
        Upholstery = Level_Console.Level_Upholstery.ToCharArray();

        T_times = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if(T_times >= 0)
        {
            T_times -= Time.deltaTime;
        }
        else
        {
            if(index_count == Upholstery.Length)
            {
                WIN();
            }
            else
            {
                T_times = Level_Console.Level_Time;
                createBox();
            }

        }
    }
    
    void createBox()
    {
        
        if (Upholstery[index_count] == '0')
        {
            Instantiate(box_map_click, new Vector3(OBJ_x, OBJ_y, 0), Quaternion.identity);
            index_count++;
        }
        else
        { 
            Upholstery[index_count]--;
            if (cear)
            {
                PressScript.index_box = 1;//���½���box���//��һ�γ��ָ�ֵ1��
                cear = false;
            }
            else
            {
                if (Upholstery[index_count] == '0')//���һ��
                {
                    PressScript.index_box = 0;
                    cear = true;
                }
                else
                {
                    PressScript.index_box = 2;

                }
            }
            Instantiate(box_map_Press, new Vector3(OBJ_x, OBJ_y, 0), Quaternion.identity);

           
            if(Upholstery[index_count] == '0')
            {
                index_count++;
            }
        }
    }
    void WIN()
    {

    }

}
