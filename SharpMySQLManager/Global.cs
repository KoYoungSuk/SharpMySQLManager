using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpMySQLManager
{
    class Global
    {
        public DialogResult errormessage(String msg)
        {
           return MessageBox.Show(msg, "SharpMySQLManager", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        public DialogResult informationmessage(String msg)
        {
           return  MessageBox.Show(msg, "SharpMySQLManager", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public String checkOS()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            string osBuild = Registry.GetValue(HKLMWinNTCurrent, "CurrentBuildNumber", "").ToString();
            String label;
            String[] osName_arr = osName.Split(' ');
            if (osName_arr[1].Equals("10"))
            {
                if (Int32.Parse(osBuild) > 21000)
                {
                    label = "Your OS: Windows 11 " + osName_arr[2] + " Build: " + osBuild;
                }
                else
                {
                    label = "Your OS: " + osName + " Build: " + osBuild;
                }
            }
            else
            {
                label = "Your OS: " + osName + " Build: " + osBuild;
            }
            return label;
        }
    }
}
