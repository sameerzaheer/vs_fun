using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.VisualBasic.Devices;

namespace CSVmanipulation {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      textBox1.Text = null;
    }

    private void button1_Click(object sender, RoutedEventArgs e) {
      if (textBox1.Text != null) {
        string[] text;
        if (File.Exists(textBox1.Text)) { text = File.ReadAllLines(textBox1.Text); } else { return; }

        int startingI = 4;
        var sorted = new string[text.Length - startingI];
        string maxString = text[startingI];

        string currStr;
        for (int i = startingI; i < text.Length; i++) {
          currStr = text[i];
          for (int j = startingI; j < text.Length; j++) {
            if (text[j].CompareTo(currStr) == -1) {

            }

          }
        }


        System.IO.Directory.CreateDirectory(System.IO.Directory.GetParent(textBox1.Text).ToString());
        try { File.WriteAllLines(textBox1.Text, text); } catch { Log.Info(".csv file write failed"); }
      }
    }

    private void fileB_Click(object sender, RoutedEventArgs e) {

      System.Diagnostics.Debug.WriteLine("Clicked!");
      OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

      OpenFileDialog1.Title = "Select batch file";
      OpenFileDialog1.InitialDirectory = "D:\\";
      //OpenFileDialog1.Filter = "Dat Files (*.txt)|*.txt|All Files (*.*)|*.*";
      OpenFileDialog1.FileName = "";
      OpenFileDialog1.Multiselect = false;
      DialogResult result = OpenFileDialog1.ShowDialog();
      Console.WriteLine(result);
      if (result == System.Windows.Forms.DialogResult.OK) {
        textBox1.Text = OpenFileDialog1.FileName;
      }    
    }
  }
}
