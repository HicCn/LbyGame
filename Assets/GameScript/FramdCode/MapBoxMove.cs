using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FramdCode;

public class MapBoxMove : MonoBehaviour
{
    //�÷������ڷ��������ı�ʱ֪ͨ��ʾ����иı�
    int lockScore = 0;
    Vector2 dir= new Vector2(-1, 0);

    private void Update()
    {
        transform.Translate(dir* BasicDefine.BoxSpeed * Time.deltaTime);
        if(transform.position.x <= -BasicDefine.MapWidthLen-BasicDefine.BoxWidthLen) MapBoxControl.BackToQueue(gameObject);
    }

    //�ж��Ƿ�����ж���

    //ש���Ǵ�20��-20�ߵģ�����������������
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

    //ȡ������ؿ��Ӧ�Ĳ���
    private char getTrueInput()
    {
        return ' ';
    }
}
