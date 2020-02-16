using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHardwareInfo
{
    class HardwareProgram
    {
        public string Id { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Product { get; set; }
        public string Caption { get; set; }
        public string SystemName { get; set; }
    }

    class SoftwarePrograme
    {
        public string DisplayName { get; set; }
        public string Version { get; set; }
        public string InstalledDate { get; set; }
        public string Publisher { get; set; }
        public string UnninstallCommand { get; set; }
        public string ModifyPath { get; set; }

    }
}
