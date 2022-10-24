using System.Collections.Generic;

namespace FramdCode
{
    public class LogicalControl 
    {
        /// <summary>
        /// 消息队列，存放文字
        /// </summary>
        readonly static Queue<string> messageQueue = new();

        /// <summary>
        /// 阶段评分
        /// </summary>
        private static int nowId = 0;

        static LogicalControl logicalControl;
        private LogicalControl() { }
        public static LogicalControl Instance()
        {
            logicalControl ??= new LogicalControl();

            return logicalControl;
        }

        /// <summary>
        /// 选谱方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public songBasic choiceSong(int id)
        {

            songBasic choice;
            switch (id)
            {
                case 1:
                    choice = new Test();
                    break;
                default:
                    choice = null;
                    break;
            }
            return choice;
        }

        #region 流程控制相关

        public static void switchTextual(int Grade)
        {
            nowId = logic.GetNextStory(nowId)[Grade];
            if (nowId != -1)
            {
                logicalControl.addMessage(nowId);
            }
        }

        #endregion

        #region 队列相关

        private void addMessage(int id)
        {
            string[] tual = textual.GetChapter(id);
            foreach(string tualItem in tual)
            {
                messageQueue.Enqueue(tualItem);
            }
        }

        public string takeMessage()
        {
            return messageQueue.Dequeue();
        }

        #endregion
    }
}

