using AdoNetTask1.Command;
using AdoNetTask1.Views;
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
        public RelayCommand InsertViewCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

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
            InsertViewCommand = new RelayCommand(sender =>
            {
                InsertView view = new InsertView();
                view.Show();
            });

            UpdateCommand = new RelayCommand(sender =>
            {
                using (var conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                    conn.Open();

                    string query = @"UPDATE  Books
                                     SET Books.[Name]=@Name
                                     Where Id=@id ";

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@id";
                    param1.SqlDbType = System.Data.SqlDbType.Int;
                    param1.Value = int.Parse(MainView.UpdateByIDTextBx.Text);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@name";
                    param2.SqlDbType = System.Data.SqlDbType.NVarChar;
                    param2.Value = MainView.UpdateNameTextBx.Text;

                        
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.Add(param1);
                    command.Parameters.Add(param2);
                    var result = command.ExecuteNonQuery();
                    MessageBox.Show("Update is succesfully");
                }
            });


            DeleteCommand = new RelayCommand(sender =>
            {

                try
                {
                using (var conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                    conn.Open();

                    string query = @"DELETE  Books          
                                     Where Id=@id ";

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@id";
                    param1.SqlDbType = System.Data.SqlDbType.Int;
                    param1.Value = int.Parse(MainView.DeleteByIdTxtBx.Text);
                 

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.Add(param1);
                    
                    var result = command.ExecuteNonQuery();
                    MessageBox.Show("Delete is succesfully");

                }

                }
                catch (Exception )
                {
                    MessageBox.Show("You can delete only row which you insert now");
                
                }
            });







        }

    }

}
