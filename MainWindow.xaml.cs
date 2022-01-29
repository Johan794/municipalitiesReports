using System;
using System.Collections.Generic;
using System.Data;
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
        }

        static void Main(String[] args) {

            DataTable table1 = new DataTable("municipalities");
            DataColumn column1 = new DataColumn("column1");
            DataColumn column2 = new DataColumn("column2");
            DataColumn column3 = new DataColumn("column3");
            DataColumn column4 = new DataColumn("column4");
            DataColumn column5 = new DataColumn("column5");

        }
    }
}
