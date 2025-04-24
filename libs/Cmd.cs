using frp_control.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frp_control.libs
{
    public class Cmd
    {
        public Cmd(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;     //是否使用操作系统shell启动
            process.StartInfo.CreateNoWindow = true;        //不显示程序窗口
            process.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
            process.StartInfo.RedirectStandardInput = true;  //接受来自调用程序的输入信息
            process.StartInfo.RedirectStandardError = true;  //重定向标准错误输出
            process.Start();
            process.StandardInput.WriteLine(command + "&exit");   //向cmd窗口发送输入信息
            process.StandardInput.AutoFlush = true;
            string output = process.StandardOutput.ReadToEnd();  //获取cmd的输出信息
            process.WaitForExit();
            process.Close();
            process.Dispose();
        }


    }
}
