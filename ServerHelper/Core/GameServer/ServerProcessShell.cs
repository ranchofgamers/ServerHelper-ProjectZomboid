using ServerHelper.Forms;
using ServerHelper.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerHelper.Core
{
    public class ServerProcessShell
    {
        public event Action OnProcessStarted;
        public event Action OnProcessShutdown;

        public bool IsServerProcessStarted { get; private set; }
        public string Name { get; set; }
        public string StartFilePath { get; set; }

        private Process process;

        public ServerProcessShell(string name, string startFilePath)
        {
            Name = name;
            process = new Process();
            StartFilePath = startFilePath;

            process.EnableRaisingEvents = true;
            process.Exited += ProcessShutdown;
        }

        public void Start()
        {
            if (IsServerProcessStarted)
                throw new InvalidOperationException("Сервер уже запущен");

            try
            {
                process.StartInfo.FileName = StartFilePath;

                process.Start();
                IsServerProcessStarted = true;
            }
            catch (Exception) { IsServerProcessStarted = false; throw; }
            finally 
            {
                if(IsServerProcessStarted)
                    OnProcessStarted?.Invoke();
            }
        }
        public void KillServerProcess()
        {
            if (!process.HasExited)
                KillProcess(process.Id);
        }

        private void KillProcess(int pid)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection processCollection = processSearcher.Get();

            try
            {
                Process proc = Process.GetProcessById(pid);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException) { }

            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillProcess(Convert.ToInt32(mo["ProcessID"])); 
                }
            }
        }
        private void ProcessShutdown(object sender, EventArgs e)
        {
            IsServerProcessStarted = false;
            OnProcessShutdown?.Invoke();
        }
    }
}
