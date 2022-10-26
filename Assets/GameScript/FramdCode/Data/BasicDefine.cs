using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramdCode
{
    public class BasicDefine 
{
    ///<summary>
    ///����ش�С
    ///</summary>
    public static int BoxQueueLen = 25;

    ///<summary>
    ///�ؿ�����λ��������
    ///</summary>
    public static float startPositionY = -5.9f;

    public static float BoxWidth = 6.8f;

    ///<summary>
    ///�ؿ��ȵ�һ��
    ///</summary>
    public static float BoxWidthLen = 3.4f;

    ///<summary>
    ///��ͼ���
    ///</summary>
    public static int MapWidthLen = 20;

    ///<summary>
    ///�ؿ��ٶ�,ÿ��
    ///</summary>
    public static float BoxSpeed = 8f;
    
    /// <summary>
    /// �ؿ��ж�����(ƫ��ʱ�䣩
    /// </summary>
    public static float GetA = 0.1f;
    public static float GetB = 0.25f;
    public static float GetC = 0.9f;

    /// <summary>
    /// �ֶε÷��ж�����(���ֵܷİٷֱ�
    /// </summary>
    public static float isNextA = 0.9f;
    public static float isNextB = 0.75f;
    public static float isNextC = 0.6f;



    public enum isComputer
    {
        w,a,s,d,b
    }
}
}

