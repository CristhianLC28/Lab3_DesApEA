using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


namespace WPFWeek4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-29TAV15;Initial Catalog=School;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            
            List<Person> people = new List<Person>();
            conn.Open();
            SqlCommand command = new SqlCommand("BuscarPersonaNombre", conn);
            command.CommandType = CommandType.StoredProcedure;

            //SqlParameter parameter1 = new SqlParameter();
            //parameter1.SqlDbType = SqlDbType.VarChar;
            //parameter1.Size = 50;
            //parameter1.Value = "";
            //parameter1.ParameterName = "@LastName";

            SqlParameter parameter2 = new SqlParameter();
            parameter2.SqlDbType = SqlDbType.VarChar;
            parameter2.Size = 50;
            parameter2.Value = "";
            parameter2.ParameterName = "@FirstName";

            //command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);

            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    PersonID = dataReader["PersonID"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    FirstName= dataReader["FirstName"].ToString(),
                    HireDate = dataReader["HireDate"].ToString(),
                    EnrollmentDate = dataReader["EnrollmentDate"].ToString(),
                }) ;
            }
            conn.Close();
            dgvPeople.ItemsSource = people;
        }
    }
}
