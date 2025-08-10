using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;


namespace GetAllSubfolders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {


          string path = textBox1.Text;
          string FileName;
          var dirs = Directory.GetDirectories(path, "****.**.**", SearchOption.TopDirectoryOnly);


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("'batchrun files");
            for (int i = 0; i < dirs.Length; i++)
            {
                FileName = System.IO.Path.GetFileName(dirs[i]);
                if (FileName.Length == 15 || true)
                {
                    sb.AppendLine(dirs[i]);
                }
            }
            sb.AppendLine("");

            StreamWriter outfile = null;

            //string dir = Directory.GetParent(textBox1.Text).ToString();
            //string FileName = System.IO.Path.GetFileName(textBox2.Text);

            if (Directory.Exists(textBox1.Text))
            {
                if (File.Exists(textBox2.Text))
                {
                    outfile = File.AppendText(textBox2.Text);
                }
            }
            if (outfile == null)
            {
                Directory.CreateDirectory(textBox2.Text);
                outfile = new StreamWriter(textBox2.Text);
            }

            outfile.Write(sb.ToString());
            outfile.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
          string dir = @"D:\ds\Lesions\BatchRun\TestData";
          string userId = Environment.UserName;
          string[] dirs = Directory.GetDirectories(dir);
          foreach (var _dir in dirs) {
            var files = Directory.GetFiles(_dir);
            foreach (var file in files) {
              if (file.Contains("meshR")) {
                string newFileName = file.Replace("meshR", "meshRef_" + userId);
                System.IO.File.Move(file, newFileName);
              }
            }
          }
        }
    }
}

/*sample input: 
 * D:\ds\CTA
 * D:\ds\SpineMapper\BatchRun2.txt
 * 
 * \\passat\D\ds\Pedicle\code
 * D:\ds\Pedicle\BatchRun.txt\ReleaseAug12Code.txt
*/