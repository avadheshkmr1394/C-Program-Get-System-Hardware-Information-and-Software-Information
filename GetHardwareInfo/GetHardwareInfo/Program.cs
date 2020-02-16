using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace GetHardwareInfo
{
    class Program
    {

        public void GetInfo()
        {

            List<SoftwarePrograme> softwareList = new List<SoftwarePrograme>();
           string registry_key=  @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        softwareList.Add(new SoftwarePrograme
                        {
                            DisplayName = (string)subkey.GetValue("DisplayName"),
                            Version = (string)subkey.GetValue("DisplayVersion"),
                            InstalledDate = (string)subkey.GetValue("InstallDate"),
                            Publisher = (string)subkey.GetValue("Publisher"),
                            UnninstallCommand = (string)subkey.GetValue("UninstallString"),
                            ModifyPath = (string)subkey.GetValue("ModifyPath")
                        });
                        Console.WriteLine(subkey.GetValue("DisplayName"));
                    }
                }
            }

            string registrykey = @"HARDWARE\DEVICEMAP";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registrykey))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        Console.WriteLine(subkey.GetValue("DisplayName"));
                    }
                }
            }

            List<HardwareProgram> hardwareList = new List<HardwareProgram>();
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                hardwareList.Add(new HardwareProgram
                {
                    Id = Convert.ToString(mo.Properties["processorID"].Value),
                    Manufacturer = Convert.ToString(mo.GetPropertyValue("Manufacturer")),
                    SerialNumber = Convert.ToString(mo.GetPropertyValue("SerialNumber")),
                    Caption=Convert.ToString(mo.GetPropertyValue("Caption")),
                   SystemName= Convert.ToString(mo.GetPropertyValue("SystemName"))
                });
            }
        }
    }

                        
    class test { 

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.GetInfo();

            Console.ReadLine();
        }
    }
}
