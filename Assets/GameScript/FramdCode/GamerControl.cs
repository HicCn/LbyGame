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

        songBasic exmSong;//本轮谱面

        [HideInInspector]
        public float mainTime;
        /// <summary>
        /// 玩家阶段结算分数
        /// </summary>
        int flowScore = 0;
        /// <summary>
        /// 分段计数
        /// </summary>
        int flowIndex = 1;

        /// <summary>
        /// 出现的格子计数
        /// </summary>
        int CountId;
        /// <summary>
        /// 主角位置
        /// </summary>
        /// <returns></returns>
        float GameerXplace = 0;

        bool isPress = false;

        /// <summary>
        /// 长按锁
        /// </summary>
        bool PressLock = false;

        //获取主角横坐标
        public void GetXplace()
        {
            GameerXplace = gameObject.transform.position.x;
            //点击的时机为 生成位置-判定线位置除以速度+生成时间
        }

        //返回玩家的操作
        public void GetPlayerDownClick()
        {
            char res = ' ';
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (res == ' ')
                    res = 'a';
                EventModel.Notify(EventId.boxMove);
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
                isPress = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (res == ' ')
                    res = 'b';
                isPress = false;
            }
            
            if(exmSong.GetGenerationType(CountId) == 1)
            {
                if (toTrueClickTime(CountId)+GetSpeedTime()/2 < mainTime)
                {
                    MissBox();
                }
                else if (res != ' ')
                {
                    ProcessShortInput(res, CountId);

                }
            }
            else
            {
                if(toTrueClickTime(CountId) + GetSpeedTime() / 2 + GetSpeedTime()*(exmSong.GetGenerationType(CountId)-1) < mainTime)
                {
                    MissBox();
                }
                else if (res != ' ')
                {
                    ProcessLongInput(CountId);
                }
            }
        }

        //点按的情况
        void ProcessShortInput(char key,int id)
        {
            float isScoring =Mathf.Abs(mainTime - toTrueClickTime(id));
            float isScoringTime = BasicDefine.BoxWidthLen * 2 / BasicDefine.BoxSpeed * 1000;

            //判断点击时是否在判定区间
            if (isScoring <= isScoringTime)
            {
                //判断按键是否正确
                if (exmSong.GetIsButton(CountId) == key)
                {
                    flowScore += GetAddScore(isScoring, isScoringTime);
                }
                else
                {
                    MissBox();
                }
                AddProcess();
            }

            
        }
        //长按的情况
        void ProcessLongInput(int id)
        {
            float isScoring = Mathf.Abs(mainTime - toTrueClickTime(id));//点击时间和正确时间的偏差量，伪判定是需要加上长条的位移时间
            float isScoringTime = GetSpeedTime();
            //如果处于按下状态，即按下时间
            if (isPress)
            {
                PressLock = true;//可以进行尾判断
                if (isScoring <= isScoringTime)
                {
                    flowScore += GetAddScore(isScoring, isScoringTime);
                }
            }
            else if(PressLock && !isPress)//抬起时间，保证抬起前没有未松开的判断
            {
                PressLock = false;//等待下一次长条
                //将时间前移
                isScoring -= (isScoringTime * (exmSong.GetGenerationType(CountId) - 1));
                flowScore += GetAddScore(isScoring, isScoringTime);
                AddProcess();
            }
        }
        //没有点击时间
        void MissBox()
        {
            AddProcess();
        }

        //取得本轮谱面
        public void GetSong(songBasic song)
        {
            exmSong = song;
        }

        //放回玩家应该正确点击的时间（按下）对长按的抬起在长按的情况中处理
        float toTrueClickTime(int index)
        {
            if(index >= exmSong.GetLen())
            {
                return -1;
            }
            else
            {
                return (BasicDefine.MapWidthLen + BasicDefine.BoxWidthLen - GameerXplace) / BasicDefine.BoxSpeed * 1000 + exmSong.GetGenerationTime(index);

            }
        }
        /// <summary>
        /// 进度管理
        /// </summary>
        void AddProcess()
        {
            if (exmSong.GetIsEnd(CountId) && flowIndex!=0)//还没做游戏结束的方法，这里写法可能有问题
            {
                //对本轮进行结算
                float tempScore = flowScore / flowIndex * 3;
                if (tempScore > BasicDefine.isNextA)
                {
                    //向消息队列中添加下一列数据
                    LogicalControl.switchTextual(0);
                }
                else if (tempScore > BasicDefine.isNextB)
                {
                    LogicalControl.switchTextual(1);
                }
                else if (tempScore > BasicDefine.isNextC)
                {
                    LogicalControl.switchTextual(2);
                }
                else
                {
                    LogicalControl.switchTextual(3);
                }
                flowIndex = 0;
                flowScore = 0;
            }
            if (CountId < exmSong.GetLen() - 1)
            {
                CountId++;
                flowIndex++;
            }
        }

        //计算单次得分
        int GetAddScore(float isScoring, float isScoringTime)
        {
            int GetScore = 0;
            if (isScoring < isScoringTime * BasicDefine.GetA)
            {
                GetScore = 3;
            }
            else if (isScoring < isScoringTime * BasicDefine.GetB)
            {
                GetScore = 2;
            }
            else if (isScoring < isScoringTime * BasicDefine.GetC)
            {
                GetScore = 1;
            }
            return GetScore;
        }

        /// <summary>
        /// 走过一个完整地块需要的时间
        /// </summary>
        /// <returns></returns>
        float GetSpeedTime()
        {
            return BasicDefine.BoxWidthLen * 2 / BasicDefine.BoxSpeed * 1000;
        }
    }
}