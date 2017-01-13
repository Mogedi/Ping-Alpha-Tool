using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PingAlpha_Tool
{
    class FileForServerList
    {
        public void createDirectory()
        {
            string path = "C:\\Users\\" + System.Environment.UserName + "\\PingTool\\";

            bool fileExist = System.IO.Directory.Exists(path);

            MessageBox.Show("Directory Exist: " + fileExist.ToString());

            if (!fileExist)
                System.IO.Directory.CreateDirectory(path);

            fileExist = System.IO.Directory.Exists(path);

            MessageBox.Show("Directory Exist: " + fileExist.ToString());

            createFile();
        }

        public void createFile()
        {
            string path = "C:\\Users\\" + System.Environment.UserName + "\\PingTool\\server.txt";

            bool fileExist = System.IO.File.Exists(path);

            MessageBox.Show("File Exist: " + fileExist.ToString());

            if (!fileExist)
                System.IO.File.Create(path);

            fileExist = System.IO.File.Exists(path);

            MessageBox.Show("File Exist: " + fileExist.ToString());
        }
    }
}
