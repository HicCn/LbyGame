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
    ///地块速度
    ///</summary>
    public static float BoxSpeed = 8f;

}
