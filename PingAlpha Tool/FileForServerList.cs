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
            {
                System.IO.Directory.CreateDirectory(path);
                createFile();
            }
                
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

            if (fileExist)
                writeToFile(path);

            fileExist = System.IO.File.Exists(path);

            MessageBox.Show("File Exist: " + fileExist.ToString());
        }

        public void writeToFile(string path)
        {
            string[] alphas = {"Starfury,10.111.11.20","Normandy,10.111.11.21","Tigersclaw,10.111.11.22","WhiteStar,10.111.11.23","JupiterII,10.111.13.244",
                "Voyager,10.111.11.25","Serenity,10.111.11.26","Galactica,10.111.11.27","Enterprise,10.111.11.28","LobbyFx,10.111.13.155","Nostromo,10.111.13.177",
                "HeartOfGold,10.111.13.141","awing,10.111.11.29","bwing,10.111.11.30","ywing,10.111.11.31","xwing,10.111.11.32"};

            foreach(string item in alphas)
            {
                System.IO.File.AppendAllText(path, item + Environment.NewLine);
            }
        }
    }
}
