using AdoNetTask1.Command;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoNetTask1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainWindow MainView { get; set; }

        public RelayCommand ShowAllCommand { get; set; }

        SqlConnection conn;

        string cs = "";

        DataSet set;

        SqlDataAdapter dataAdapter;

        public MainViewModel()
        {
            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

            ShowAllCommand = new RelayCommand(sender =>
            {
                using (conn = new SqlConnection())
                {
                    conn.ConnectionString = cs;
                    conn.Open();
                    set = new DataSet();
                    dataAdapter = new SqlDataAdapter("SELECT * FROM Books;", conn);

                    dataAdapter.Fill(set, "mybook");
                    MainView.MyDataGrid.ItemsSource = set.Tables[0].DefaultView;                                     
                }

            });



        }

    }

}
