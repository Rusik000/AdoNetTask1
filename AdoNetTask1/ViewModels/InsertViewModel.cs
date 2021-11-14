using AdoNetTask1.Command;
using AdoNetTask1.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoNetTask1.ViewModels
{
    public class InsertViewModel : BaseViewModel
    {
        public InsertView InsertWindow { get; set; }

        public RelayCommand InsertNowCommand { get; set; }

        public InsertViewModel()
        {
            InsertNowCommand = new RelayCommand(sender =>
            {
                try
                {
                    int id = int.Parse(InsertWindow.IdTxtBx.Text);
                    string name = InsertWindow.NameTxtBx.Text;
                    int pages = int.Parse(InsertWindow.PagesTxtBx.Text);
                    int yearPress = int.Parse(InsertWindow.YearPressTxtBx.Text);
                    int themesId = int.Parse(InsertWindow.ThemesIdTxtBx.Text);
                    int categoryId = int.Parse(InsertWindow.CategoryIdTxtBx.Text);
                    int authorId = int.Parse(InsertWindow.AuthorIdTxtBx.Text);
                    int pressId = int.Parse(InsertWindow.PressIdTxtBx.Text);
                    string comment = InsertWindow.CommentTxtBx.Text;
                    int quantity = int.Parse(InsertWindow.QuantityTxtBx.Text);

                    using (var conn = new SqlConnection())
                    {
                        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                        conn.Open();

                        string query = @"INSERT INTO Books(Id,Name,Pages,YearPress,Id_Themes,Id_Category,Id_Author,Id_Press,Comment,Quantity) 
                    values(@id,@name,@pages,@yearPress,@themesId,@categoryId,@authorId,@pressId,@comment,@quantity)";
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@id";
                        param1.SqlDbType = System.Data.SqlDbType.Int;
                        param1.Value = id;

                        SqlParameter param2 = new SqlParameter();
                        param2.ParameterName = "@name";
                        param2.SqlDbType = System.Data.SqlDbType.NVarChar;
                        param2.Value = name;

                        SqlParameter param3 = new SqlParameter();
                        param3.ParameterName = "@pages";
                        param3.SqlDbType = System.Data.SqlDbType.Int;
                        param3.Value = pages;



                        SqlParameter param4 = new SqlParameter();
                        param4.ParameterName = "@yearPress";
                        param4.SqlDbType = System.Data.SqlDbType.Int;
                        param4.Value = yearPress;


                        SqlParameter param5 = new SqlParameter();
                        param5.ParameterName = "@themesId";
                        param5.SqlDbType = System.Data.SqlDbType.Int;
                        param5.Value = themesId;

                        SqlParameter param6 = new SqlParameter();
                        param6.ParameterName = "@categoryId";
                        param6.SqlDbType = System.Data.SqlDbType.Int;
                        param6.Value = categoryId;

                        SqlParameter param7 = new SqlParameter();
                        param7.ParameterName = "@authorId";
                        param7.SqlDbType = System.Data.SqlDbType.Int;
                        param7.Value = authorId;


                        SqlParameter param8 = new SqlParameter();
                        param8.ParameterName = "@pressId";
                        param8.SqlDbType = System.Data.SqlDbType.Int;
                        param8.Value = pressId;

                        SqlParameter param9 = new SqlParameter();
                        param9.ParameterName = "@comment";
                        param9.SqlDbType = System.Data.SqlDbType.NVarChar;
                        param9.Value = comment;


                        SqlParameter param10 = new SqlParameter();
                        param10.ParameterName = "@quantity";
                        param10.SqlDbType = System.Data.SqlDbType.Int;
                        param10.Value = quantity;




                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.Add(param1);
                        command.Parameters.Add(param2);
                        command.Parameters.Add(param3);
                        command.Parameters.Add(param4);
                        command.Parameters.Add(param5);
                        command.Parameters.Add(param6);
                        command.Parameters.Add(param7);
                        command.Parameters.Add(param8);
                        command.Parameters.Add(param9);
                        command.Parameters.Add(param10);
                        var result = command.ExecuteNonQuery();
                        MessageBox.Show("Insert is succesfully");
                        InsertWindow.Hide();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You fill not correct or something is same with database's field ");
                }


            });
        }
    }
}
