using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDefine : MonoBehaviour
{
    ///<summary>
    ///对象池大小
    ///</summary>
    public static int BoxQueueLen = 25;

    ///<summary>
    ///地块生成位置纵坐标
    ///</summary>
    public static int startPositionY = 0;



    ///<summary>
    ///地块宽度的一半
    ///</summary>
    public static int BoxWidthLen = 2;

    ///<summary>
    ///地图宽度
    ///</summary>
    public static int MapWidthLen = 20;

    ///<summary>
    ///地块速度,每秒
    ///</summary>
    public static float BoxSpeed = 8f;
    
    /// <summary>
    /// 地块判定区间(偏差时间）
    /// </summary>
    public static float GetA = 0.1f;
    public static float GetB = 0.25f;
    public static float GetC = 0.9f;

    /// <summary>
    /// 分段得分判定区间(与总分的百分比
    /// </summary>
    public static float isNextA = 0.9f;
    public static float isNextB = 0.75f;
    public static float isNextC = 0.6f;



    public enum isComputer
    {
        w,a,s,d,b
    }
}
