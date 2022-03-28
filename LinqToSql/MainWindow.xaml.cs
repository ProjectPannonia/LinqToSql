using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace LinqToSql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            // connection string = PanjuTutotialsDbConnectionString
            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSql.Properties.Settings.PanjuTutotialsDbConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            InsertUniversities();
        }

        public void InsertUniversities()
        {
            University yale = new University();
            yale.Name = "Beijing Tech";
            dataContext.Universities.InsertOnSubmit(yale);
            
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }
    }
}
