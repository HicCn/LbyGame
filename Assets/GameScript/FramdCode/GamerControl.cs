using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramdCode
{
    public class GamerControl : MonoBehaviour
    {
        private static GamerControl gamerControl;
        private GamerControl() { }
        public static GamerControl Instance()
        {
            gamerControl ??= new GamerControl();

            return gamerControl; 
        }
        int score = 0;

        //获取主角横坐标
        public float GetXplace()
        {
            return gameObject.transform.position.x;
        }

        //返回玩家的操作
        public char GetPlayerDownClick()
        {
            char res = ' ';
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (res == ' ')
                    res = 'a';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (res == ' ')
                    res = 's';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (res == ' ')
                    res = 'd';
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (res == ' ')
                    res = 'w';
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (res == ' ')
                    res = 'b';
            }
            return res;
        }
    }
}