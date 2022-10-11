using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FramdCode;

public class MapBoxMove : MonoBehaviour
{
    //得分锁，在分数发生改变时通知显示层进行改变
    int lockScore = 0;
    Vector2 dir= new Vector2(-1, 0);

    private void Update()
    {
        transform.Translate(dir* BasicDefine.BoxSpeed * Time.deltaTime);
        if(transform.position.x <= -BasicDefine.MapWidthLen-BasicDefine.BoxWidthLen) MapBoxControl.BackToQueue(gameObject);
    }

    //判断是否进入判断区

    //砖块是从20往-20走的，坐标点均在物体中心
    private bool isStartJudge()
    {
        float xCur = gameObject.transform.position.x;
        bool res = false;
        if(xCur <= StartGame.DecisionLine+ BasicDefine.BoxWidthLen && xCur >= StartGame.DecisionLine - BasicDefine.BoxWidthLen)
        {
            res = true;
        }
        return res;
    }

    //取到这个地块对应的操作
    private char getTrueInput()
    {
        return ' ';
    }
}
