using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBackuper.Core
{
    public class Observer
    {
        public event Action ?OnCreatedProcess;
        public event Action ?OnDeletedProcess;
        public List<string> ProcessNames { get; set; }

        private ManagementEventWatcher creationWatcher;
        private ManagementEventWatcher deletionWatcher;

        public Observer(List<string> processNames)
        {
            ProcessNames = processNames;

            string creationQuery = "SELECT * FROM __InstanceCreationEvent WITHIN .025 WHERE TargetInstance ISA 'Win32_Process'";
            creationWatcher = new ManagementEventWatcher(creationQuery);
            creationWatcher.EventArrived += OnCreationProcess;
            creationWatcher.Start();

            string deletionQuery = "SELECT * FROM __InstanceDeletionEvent WITHIN .025 WHERE TargetInstance ISA 'Win32_Process'";
            deletionWatcher = new ManagementEventWatcher(deletionQuery);
            deletionWatcher.EventArrived += OnDeletionProcess;
            deletionWatcher.Start();
        }
        private void OnCreationProcess(object sender, EventArrivedEventArgs e)
        {
            var targetInstance = ((System.Management.ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value);
            var processName = targetInstance.Properties["Caption"].Value.ToString();

            if (processName != null && ProcessNames.Contains(processName))
                OnCreatedProcess?.Invoke();
        }
        private void OnDeletionProcess(object sender, EventArrivedEventArgs e)
        {
            var targetInstance = ((System.Management.ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value);
            var processName = targetInstance.Properties["Caption"].Value.ToString();

            if (processName != null && ProcessNames.Contains(processName))
                OnDeletedProcess?.Invoke();
        }
        public void Dispose()
        {
            creationWatcher.Stop();
            creationWatcher.Dispose();

            deletionWatcher.Stop();
            deletionWatcher.Dispose();
        }
    }
}
