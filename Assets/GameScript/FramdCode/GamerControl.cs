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

        songBasic exmSong;//��������

        public float mainTime;
        /// <summary>
        /// ��ҽ������
        /// </summary>
        int flowScore = 0;
        /// <summary>
        /// �ֶμ���
        /// </summary>
        int flowIndex = 1;

        /// <summary>
        /// �ܼ���
        /// </summary>
        int CountId;

        /// <summary>
        /// ����λ��
        /// </summary>
        /// <returns></returns>
        float GameerXplace = 0;

        bool isPress = false;

        /// <summary>
        /// ������
        /// </summary>
        bool PressLock = false;

        //��ȡ���Ǻ�����
        public void GetXplace()
        {
            GameerXplace = gameObject.transform.position.x;
            //�����ʱ��Ϊ ����λ��-�ж���λ�ó����ٶ�+����ʱ��
        }

        //������ҵĲ���
        public void GetPlayerDownClick()
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
                isPress = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (res == ' ')
                    res = 'b';
                isPress = false;
            }
            //���û�е�����򴥷��ͷ�
            if(exmSong.GetGenerationType(CountId) == 1)
            {
                if (toTrueClickTime(CountId)+GetSpeedTime()/2 < mainTime)
                {
                    MissBox();
                }
                else if (res != ' ')
                {
                    Debug.Log(CountId);
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
                    Debug.Log(CountId);
                    ProcessLongInput(CountId);
                }
            }
        }

        void ProcessShortInput(char key,int id)
        {
            float isScoring =Mathf.Abs(mainTime - toTrueClickTime(id));
            float isScoringTime = BasicDefine.BoxWidthLen * 2 / BasicDefine.BoxSpeed * 1000;

            //�жϵ��ʱ�Ƿ����ж�����
            if (isScoring <= isScoringTime)
            {
                //�жϰ����Ƿ���ȷ
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
        void ProcessLongInput(int id)
        {
            float isScoring = Mathf.Abs(mainTime - toTrueClickTime(id));//���ʱ�����ȷʱ���ƫ������α�ж�����Ҫ���ϳ�����λ��ʱ��
            float isScoringTime = GetSpeedTime();
            //������ڰ���״̬��������ʱ��
            if (isPress)
            {
                PressLock = true;//���Խ���β�ж�
                if (isScoring <= isScoringTime)
                {
                    flowScore += GetAddScore(isScoring, isScoringTime);
                }
            }
            else if(PressLock && !isPress)//̧��ʱ�䣬��̧֤��ǰû��δ�ɿ����ж�
            {
                PressLock = false;//�ȴ���һ�γ���
                //��ʱ��ǰ��
                isScoring -= (isScoringTime * (exmSong.GetGenerationType(CountId) - 1));
                flowScore += GetAddScore(isScoring, isScoringTime);
                AddProcess();
            }
        }
        //û�е��ʱ��
        void MissBox()
        {
            AddProcess();
        }

        //ȡ�ñ�������
        public void GetSong(songBasic song)
        {
            exmSong = song;
        }

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
        /// ���ȹ���
        /// </summary>
        void AddProcess()
        {
            if (exmSong.GetIsEnd(CountId) && flowIndex!=0)//��û����Ϸ�����ķ���������д������������
            {
                //�Ա��ֽ��н���
                float tempScore = flowScore / flowIndex * 3;
                if (tempScore > BasicDefine.isNextA)
                {
                    Debug.Log("�õ�3��");
                }
                else if (tempScore > BasicDefine.isNextB)
                {
                    Debug.Log("�õ�2��");
                }
                else if (tempScore > BasicDefine.isNextC)
                {
                    Debug.Log("�õ�1��");
                }
                else
                {
                    Debug.Log("�õ�0��");
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

        int GetAddScore(float isScoring, float isScoringTime)
        {
            int GetScore = 0;
            string t = "��" + CountId + "��";
            if (isScoring < isScoringTime * BasicDefine.GetA)
            {
                t += "�õ�3��";
                Debug.Log(t);

                GetScore = 3;
            }
            else if (isScoring < isScoringTime * BasicDefine.GetB)
            {
                t += "�õ�2��";
                Debug.Log(t);
                GetScore = 2;
            }
            else if (isScoring < isScoringTime * BasicDefine.GetC)
            {
                t += "�õ�1��";
                Debug.Log(t);
                GetScore = 1;
            }
            return GetScore;
        }

        /// <summary>
        /// �߹�һ�������ؿ���Ҫ��ʱ��
        /// </summary>
        /// <returns></returns>
        float GetSpeedTime()
        {
            return BasicDefine.BoxWidthLen * 2 / BasicDefine.BoxSpeed * 1000;
        }
    }
}