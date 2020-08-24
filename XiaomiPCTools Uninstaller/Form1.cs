using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace XiaomiPCTools_Uninstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }
        string deskyol= System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void btnUninstall_Click(object sender, EventArgs e)
        {
         

            try
            {

            System.IO.DirectoryInfo klasor = new DirectoryInfo(Application.StartupPath);

            foreach (FileInfo dosya in klasor.GetFiles())
            {
                dosya.Delete();
            }
            foreach (DirectoryInfo k in klasor.GetDirectories())
            {
                k.Delete(true);
            }


            }

            catch
            {

            }
            finally
            {
                Directory.Delete(Application.StartupPath + @"\data", true);
                System.IO.File.Delete(deskyol+@"\Xiaomi PC Tools.lnk");

                MessageBox.Show("Xiaomi PC Tools has been removed from your computer.", "Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("https://mirdem.wordpress.com/applications/xiaomi-pc-tools/");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            try 
            { 
            string processName = "adb"; // Kapatmak İstediğimiz Program
            Process[] processes = Process.GetProcesses();// Tüm Çalışan Programlar
            foreach (Process process in processes)
            {
                if (process.ProcessName == processName)
                {
                    process.Kill();
                }
            }
            }
            catch
            {

            }
        }
    }
}
