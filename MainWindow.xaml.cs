﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.OleDb;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace municipalitiesReports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillComboBox();
        }

        /*static void Main(String[] args) {
            InitializeComponent();

            DataTable table1 = new DataTable("municipalities");
            DataColumn column1 = new DataColumn("column1");
            DataColumn column2 = new DataColumn("column2");
            DataColumn column3 = new DataColumn("column3");
            DataColumn column4 = new DataColumn("column4");
            DataColumn column5 = new DataColumn("column5");

            import();
        }*/

        private void fillComboBox()
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            foreach(char c in alpha)
            {
                comboBox1.Items.Add(c);
            }

        }
        private void import_Click(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            tableView.ItemsSource = LoadCSV(open.FileName);
        }

        private void initializeTableview() {
            for (int i=0;i<10;i++) {
                
            }
        }

        private void import() {

            OpenFileDialog openFile = new OpenFileDialog();
            
            if (openFile.ShowDialog()==true) {

                var reader = new StreamReader(File.OpenRead(openFile.FileName));

                List<string> column_1 = new List<string>();
                List<string> column_2 = new List<string>();
                List<string> column_3 = new List<string>();
                List<string> column_4 = new List<string>();
                List<string> column_5 = new List<string>();

                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    var data = line.Split(';');

                    column_1.Add(data[0]);
                    column_2.Add(data[1]);
                    column_3.Add(data[2]);
                    column_4.Add(data[3]);
                    column_5.Add(data[4]);

                  
                    
                    
                    

                    foreach (var c in column_1) {
                        Console.WriteLine(c);
                    }
                }
            }
            

        }

        public List<Municipalities> LoadCSV(string csvFile) {
            var query = from l in File.ReadAllLines(csvFile)
                        let data = l.Split(';')
                        select new Municipalities
                        {
                            Codigo_Departamento = data[0],
                            Codigo_municipio = data[1],
                            Nombre_Departamento = data[2],
                            Nombre_Municipio = data[3],
                            Tipo = data[4]
                        };
            return query.ToList();
        }

        /*public static void import() {
            if (selectImport) {
                Console.WriteLine("SI FUNCIONA....");
            }
        }*/


    }

    public class Municipalities { 
        public string Codigo_Departamento { get; set; }

        public string Codigo_municipio { get; set; }

        public string Nombre_Departamento { get; set; }

        public string Nombre_Municipio { get; set; }

        public string Tipo { get; set; }
    }
}
