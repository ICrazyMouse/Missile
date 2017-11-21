using System;
using System.Reflection;
using System.Windows.Forms;

namespace Missile
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
            //扫描resources中的DLL
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                AssemblyName assemToLoad = new AssemblyName(args.Name);
                if (assemToLoad.Name == "websocket-sharp-with-proxy-support")
                {
                    Object obj = Properties.Resources.ResourceManager.GetObject(assemToLoad.Name.Replace("-", "_"));
                    return Assembly.Load((byte[])obj);
                }
                else if (assemToLoad.Name == "Newtonsoft.Json")
                {
                    Object obj = Properties.Resources.ResourceManager.GetObject(assemToLoad.Name.Replace(".", "_"));
                    return Assembly.Load((byte[])obj);
                }
                else
                {
                    return null;
                }
            };
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSetting());
        }
    }
}
