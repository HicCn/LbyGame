using System.Collections.Generic;

namespace FramdCode
{
    public class LogicalControl 
    {
        /// <summary>
        /// ��Ϣ���У��������
        /// </summary>
        readonly static Queue<string> messageQueue = new();

        /// <summary>
        /// �׶�����
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
        /// ѡ�׷���
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

        #region ���̿������

        public static void switchTextual(int Grade)
        {
            nowId = logic.GetNextStory(nowId)[Grade];
            if (nowId != -1)
            {
                logicalControl.addMessage(nowId);
            }
        }

        #endregion

        #region �������

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

