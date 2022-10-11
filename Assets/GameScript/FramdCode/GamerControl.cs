using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramdCode
{
    public class GamerControl : MonoBehaviour
    {
        //判断是否处于按下状态
        bool isPress = false;

        //获取主角横坐标
        public float GetXplace()
        {
            return gameObject.transform.position.x;
        }
        //判断玩家是否在长按
        public bool GetisPress()
        {
            return isPress;
        }

        //返回玩家的操作
        public char GetPlayerClick()
        {
            char res = ' ';
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (res == ' ')
                    res = 'A';
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (res == ' ')
                    res = 'S';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (res == ' ')
                    res = 'D';
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (res == ' ')
                    res = 'W';
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (res == ' ')
                    res = 'B';
                isPress = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (res == ' ')
                    res = 'b';
                isPress = false;
            }
            else if (Input.anyKey)
            {
                if (res == ' ')
                    res = 'G';
            }
            else if (GetisPress())
            {
                if (res == ' ')
                    res = '-';
            }
            return res;
        }
    }
}