using System;
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

        private List<Municipalities> municipalities;

        private void import_Click(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            tableView.ItemsSource = LoadCSV(open.FileName);
            municipalities = LoadCSV(open.FileName);
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

        private void sorting(object sender, RoutedEventArgs e)
        {
            if (municipalities != null)
            {
                List<Municipalities> newList = new List<Municipalities>();

                for (int i = 0; i < municipalities.Count; i++)
                {
                    string departament = municipalities[i].Nombre_Departamento.ToString();

                    char[] x = departament.ToCharArray();
                    if (comboBox1.SelectedItem.Equals(x[0]))
                    {
                        newList.Add(municipalities[i]);


                    } 

                }
                tableView.ItemsSource = newList;
            }
            else {
                MessageBox.Show("No hay datos que filtrar");
            }
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            if (municipalities != null)
            {
                tableView.ItemsSource = municipalities;
                comboBox1.SelectedIndex = -1;
            }
            else {
                MessageBox.Show("No hay nada que refrescar");
            }
            
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
