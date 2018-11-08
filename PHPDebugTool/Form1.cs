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

namespace PHPDebugTool
{
    public partial class Form1 : Form
    {
        string strFileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run test = new Run();
            //请把PHP运行环境放到指定位置
            output_textbox.Text = test.RunProgram(".\\php\\php.exe", strFileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PHP文件(*.php)|*.php|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFileName = ofd.FileName;
                //其他代码
                Text = "PHPDebugTool - " + ofd.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1_Click(null,null);
            string path = Application.StartupPath + "\\test.html";
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(output_textbox.Text);//开始写入值
            sr.Close();
            fs.Close();
            System.Diagnostics.Process.Start(path);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            output_textbox.Width = ClientSize.Width - 24;
            output_textbox.Height = ClientSize.Height - 80;
            button1.Top = output_textbox.Top + output_textbox.Height + 6;
            button2.Top = button1.Top;
            button3.Top = button2.Top;
            linkLabel1.Top = button2.Top + 12;
            linkLabel1.Left = ClientSize.Width - linkLabel1.Width - 12;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ppjun.cn");
        }
    }
}
