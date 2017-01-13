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

            bool directoryExist = System.IO.Directory.Exists(path);

            if (!directoryExist)
            {
                System.IO.Directory.CreateDirectory(path);
                createFile();
            }
                
            createFile();
        }

        public void createFile()
        {
            string path = "C:\\Users\\" + System.Environment.UserName + "\\PingTool\\server.txt";

            bool fileExist = System.IO.File.Exists(path);

            if (fileExist)
            {
                int counter = 0;
                string line;
                string[] alphas = {"Starfury,10.111.11.20","Normandy,10.111.11.21","Tigersclaw,10.111.11.22","WhiteStar,10.111.11.23","JupiterII,10.111.13.244",
                    "Voyager,10.111.11.25","Serenity,10.111.11.26","Galactica,10.111.11.27","Enterprise,10.111.11.28","LobbyFx,10.111.13.155","Nostromo,10.111.13.177",
                    "HeartOfGold,10.111.13.141","awing,10.111.11.29","bwing,10.111.11.30","ywing,10.111.11.31","xwing,10.111.11.32"};

                System.IO.StreamReader file = new System.IO.StreamReader(path);
                
                while ((line = file.ReadLine()) != null)
                {
                    if (String.Compare(line, alphas[counter]) == 0)
                    {
                        System.Console.WriteLine(line);
                        System.Console.WriteLine(counter);
                        file.Close();
                        System.IO.File.Delete(path);
                        fileExist = System.IO.File.Exists(path);
                        break;
                    }
                    counter++;
                }
                file.Close();
            }
                

            if (!fileExist)
            {
                System.IO.File.Create(path).Close();

                string[] alphas = {"Starfury,10.111.11.20","Normandy,10.111.11.21","Tigersclaw,10.111.11.22","WhiteStar,10.111.11.23","JupiterII,10.111.13.244",
                    "Voyager,10.111.11.25","Serenity,10.111.11.26","Galactica,10.111.11.27","Enterprise,10.111.11.28","LobbyFx,10.111.13.155","Nostromo,10.111.13.177",
                    "HeartOfGold,10.111.13.141","awing,10.111.11.29","bwing,10.111.11.30","ywing,10.111.11.31","xwing,10.111.11.32"};

                foreach (string item in alphas)
                {
                    System.IO.File.AppendAllText(path, item + Environment.NewLine);
                }
            }
        }

        public static void writeToFile(string hostname, string ipAddress)
        {
            string path = "C:\\Users\\" + System.Environment.UserName + "\\PingTool\\userIPs.txt";

            if (!(System.IO.File.Exists(path)))
            {
                System.IO.File.Create(path).Close();
            }
            

            if (!(string.IsNullOrEmpty(hostname)) && !(string.IsNullOrEmpty(ipAddress)))
            {
                System.Console.WriteLine(string.IsNullOrEmpty(hostname));
                System.Console.WriteLine(string.IsNullOrEmpty(ipAddress));
                System.IO.File.AppendAllText(path, hostname + "," + ipAddress + Environment.NewLine);
            }
            else if (string.IsNullOrEmpty(hostname) && string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Please type a Hostname or an Ip Address");
            }
            else if (string.IsNullOrEmpty(hostname))
            {
                hostname = "Empty Hostname";
                System.IO.File.AppendAllText(path, hostname + "," + ipAddress + Environment.NewLine);
            }
            else if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = "Empty Ip Address";
                System.IO.File.AppendAllText(path, hostname + "," + ipAddress + Environment.NewLine);
            }


        }
    }
}
