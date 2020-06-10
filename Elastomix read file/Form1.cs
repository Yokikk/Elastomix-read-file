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

namespace Elastomix_read_file
{
    public partial class Main : Form
    {
        string mooney = "C:\\Users\\IKKI-PC01\\Desktop\\MOONEY VISCOMETOR";
        string bkfile = "C:\\Users\\IKKI-PC01\\Desktop";
        
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkfilemooney();
        }
        private void checkfilemooney()
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(mooney);
                FileInfo[] Files = d.GetFiles("*.CSV");

                foreach (FileInfo file in Files)
                {
                    readFile(file.Name);
                }
            }
            catch (IOException)
            {

            }
           
        }
        private void readFile(string fileName) // อ่านไฟล์จาก text file 
        {
            string datafromMV = "";
            var fileStream = new FileStream(mooney + "\\" + fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.Default))
            {
                string datamooney;
                while ((datamooney = streamReader.ReadLine()) != null)
                {
                    datafromMV = datamooney;
                }
            }

            //Send Data to BackUp Folder check data and do some think
            bkUpData(fileName);
            fileStream.Close();
        }
        private void bkUpData(string fileName) //Send Data to BackUp Folder 
        {
            string sourceFile = mooney + "\\" + fileName;
            string destinationFile = bkfile + "\\BK\\" + fileName;
            try
            {
                File.Move(sourceFile, destinationFile);
            }
            catch (IOException)
            {
                //MessageBox.Show(io.ToString());
            }
        }
    }
}
