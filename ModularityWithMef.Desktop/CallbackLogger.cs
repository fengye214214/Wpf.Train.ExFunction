using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularityWithMef.Desktop
{
    /// <summary>
    /// 日之类去处理日志入口，直到一个回调委托被设置，开始回调日志入口和发送一个新入口
    /// </summary>
    public class CallbackLogger : ILoggerFacade
    {
        private readonly Queue<Tuple<string, Category, Priority>> savedLogs =
            new Queue<Tuple<string, Category, Priority>>();

        private Action<string, Category, Priority> callback;

        public Action<string, Category, Priority> Callback
        {
            get { return this.callback; }
            set { this.callback = value; }
        }

        public void Log(string message, Category category, Priority priority)
        {
            if (this.Callback != null)
            {
                this.Callback(message, category, priority);
            }
            else
            {
                this.savedLogs.Enqueue(new Tuple<string, Category, Priority>(message, category, priority));
            }
        }


        public void ReplaySaveLogs()
        {
            if(this.Callback != null)
            {
                while(this.savedLogs.Count > 0)
                {
                    var log = this.savedLogs.Dequeue();
                    this.Callback(log.Item1, log.Item2, log.Item3);
                }
            }
        }
    }
}
