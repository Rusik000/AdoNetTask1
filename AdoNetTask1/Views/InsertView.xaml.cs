using AdoNetTask1.ViewModels;
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
using System.Windows.Shapes;

namespace AdoNetTask1.Views
{
    /// <summary>
    /// Interaction logic for InsertView.xaml
    /// </summary>
    public partial class InsertView : Window
    {
        public InsertView()
        {
            InitializeComponent();
            this.DataContext = new InsertViewModel() { InsertWindow = this };
        }
    }
}
