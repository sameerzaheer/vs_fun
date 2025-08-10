using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Claron.WIF;
using ClearCanvas.Dicom;
using System.IO;

namespace SetImagePositions
{
    public partial class SetImagePosition : Form
    {
        public SetImagePosition()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            string batchFilePath;

            OpenFileDialog1.Title = "Select a file in the DICOM folder";
            OpenFileDialog1.InitialDirectory = "D:\\ds";            
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.Multiselect = false;
            DialogResult result = OpenFileDialog1.ShowDialog();
            Console.WriteLine(result);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                batchFilePath = OpenFileDialog1.FileName;
                textBox1.Text = batchFilePath;
            }
            else
            {
                Console.WriteLine("not ok");
            }       
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string dir=Directory.GetParent(textBox1.Text).ToString();
            string fileName = System.IO.Path.GetFileName(textBox1.Text);

            if (!Directory.Exists(dir))
                return;

            int lastSeparatorI = dir.LastIndexOf(".");


            int numSlices = Int32.Parse(dir.Substring(lastSeparatorI+1));
            for (int i = 1; i <= numSlices; i++)
            {
                var a = i.ToString("0000");

                string DICOMfile = dir + "\\" + fileName.Substring(0, fileName.Length - 7 - 1) + a + ".dcm";
                //string filename = @"D:\ds\AutoSpine\code\paby.ba.bu.0218\paby.ba.bu.0" + a + ".dcm";
                var dcmFile = new DicomFile(DICOMfile);
                dcmFile.Load(DicomReadOptions.Default);

                var thickness = dcmFile.DataSet[DicomTags.SliceThickness].GetFloat64(0, -1);
                var num = dcmFile.DataSet[DicomTags.InstanceNumber].GetInt32(0, -1);

                dcmFile.DataSet[DicomTags.ImageOrientationPatient].SetStringValue("0\\1\\0\\0\\0\\-1");
                dcmFile.DataSet[DicomTags.ImagePositionPatient].SetFloat64(0, thickness * num);
                dcmFile.DataSet[DicomTags.ImagePositionPatient].SetFloat64(1, 0.0);
                dcmFile.DataSet[DicomTags.ImagePositionPatient].SetFloat64(2, 0.0);

                dcmFile.Save();
            }

          
        }
    }
}
