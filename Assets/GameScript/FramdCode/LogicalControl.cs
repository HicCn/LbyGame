namespace FramdCode
{
    public class LogicalControl 
    {
        private static LogicalControl logicalControl;
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
    }
}

