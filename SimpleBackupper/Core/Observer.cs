using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Management.Instrumentation;
using System.Text;

namespace SimpleBackupper.Core
{
    public class Observer
    {
        public event Action OnCreatedProcess;
        public event Action OnDeletedProcess;

        public List<string> DetectedProcessNames { get; private set; }
        public bool IsWorking { get; private set; } = false;

        private ManagementEventWatcher createdWatcher;
        private ManagementEventWatcher deletednWatcher;

        public Observer(List<string> detectedProcessNames)
        {
            DetectedProcessNames = detectedProcessNames;
        }

        public void Start()
        {
            if (IsWorking)
                throw new InvalidOperationException("Сканирование процессов уже запущено.");
            try
            {
                string createdQuety = "SELECT * FROM __InstanceCreationEvent WITHIN .025 WHERE TargetInstance ISA 'Win32_Process'";
                createdWatcher = new ManagementEventWatcher(createdQuety);
                createdWatcher.EventArrived += OnCreatedProcessHandler;
                createdWatcher.Start();

                string deletedQuety = "SELECT * FROM __InstanceDeletionEvent WITHIN .025 WHERE TargetInstance ISA 'Win32_Process'";
                deletednWatcher = new ManagementEventWatcher(deletedQuety);
                deletednWatcher.EventArrived += OnDeletedProcessHanlder;
                deletednWatcher.Start();

                IsWorking = true;
            }
            catch (Exception) { IsWorking = false; }
        }
        public void Stop()
        {
            createdWatcher.EventArrived -= OnCreatedProcessHandler;
            createdWatcher.Stop();
            createdWatcher.Dispose();

            deletednWatcher.EventArrived -= OnDeletedProcessHanlder;
            deletednWatcher.Stop();
            deletednWatcher.Dispose();
        }

        private void OnCreatedProcessHandler(object sender, EventArrivedEventArgs e)
        {
            var target = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
            var targetProcessName = target.Properties["Caption"].Value.ToString();

            if (targetProcessName != null && DetectedProcessNames.Contains(targetProcessName))
                OnCreatedProcess?.Invoke();
        }
        private void OnDeletedProcessHanlder(object sender, EventArrivedEventArgs e)
        {
            var target = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
            var targetProcessName = target.Properties["Caption"].Value.ToString();

            if (targetProcessName != null && DetectedProcessNames.Contains(targetProcessName))
                OnDeletedProcess?.Invoke();
        }
    }
}
