using System;
using System.Configuration;
using System.IO;
using Windows.TaskSchedule.Extends;

namespace MyWindowsTaskSchedule
{
    /// <summary>
    /// 具体服务逻辑实现
    /// </summary>
    public class Test : IJob
    {
        public void Excute()
        {
            //throw new NotImplementedException();
            FileStream fs = new FileStream(ConfigurationManager.AppSettings["LogFile"].ToString(), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(string.Format("\"MyWindowsTaskSchedule\" Windows Service Run At {0} \n", DateTime.Now.ToString()));
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public void Init()
        {
            //throw new NotImplementedException();
        }

        public void OnError(Exception ex)
        {
            //throw new NotImplementedException();
        }
    }
}
