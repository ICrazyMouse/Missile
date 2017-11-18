using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissileText
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += (sender, error) => {

            };
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += (sender, error) => {

            };
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSetting());
        }
    }
}
