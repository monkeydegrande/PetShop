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

namespace AniMall
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowVM MWVM = new MainWindowVM(this);
            InitializeComponent();
            DataContext = MWVM;
        }

        // Ensures username and password fields are not empty
        public bool LoginValidateEntries()
        {
            if (string.IsNullOrWhiteSpace(Login.userName.Text))
            { return false; }
            if (string.IsNullOrWhiteSpace(Login.pwBox.Password))
            { return false; }
            return true;
        }
    }
}
