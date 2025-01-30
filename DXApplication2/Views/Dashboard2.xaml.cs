using DXApplication2.Views.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXApplication2.Views
{
    /// <summary>
    /// Interaction logic for Dashboard2.xaml
    /// </summary>
    public partial class Dashboard2 : UserControl
    {
        public Dashboard2()
        {
            InitializeComponent();
            main.Navigate(new food());
        }
    }
}
