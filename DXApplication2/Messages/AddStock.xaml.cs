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
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DXApplication2.Models;
using DXApplication2.Views.Page;


namespace DXApplication2.Messages
{
    /// <summary>
    /// Interaction logic for AddStock.xaml
    /// </summary>
    public partial class AddStock : ThemedWindow
    {
        int _n;
        IEnumerable<Stock> _stocks;
        List<string> products = new List<string>()
        {
             "pain", "Tomato", "pomme de terre","spaghetti","viand","poulets","huiles"
        };
        List<string> months = new List<string>()
        {
            "janv","fevr","mars","april","may","september","october","november","December"
        };
        food _foodWindow;
        public AddStock(int n, IEnumerable<Stock> stocks, food _food)
        {
            InitializeComponent();
            _n = n;
            _stocks = stocks;
            Number.Value = _n.ToString();
            Product.cbData.ItemsSource = products;
            Month.cbData.ItemsSource = months;
            _foodWindow = _food;
        }

        private void Product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                Product.Focus();
            }
        }

        private void Month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                Month.Focus();
            }
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Load sample data
            var sampleData = new Fooding.ModelInput()
            {
                Month = Month.cbData.Text,
                Vacance = (float)Convert.ToDouble(Vacance.Value),
                Nom = Product.cbData.Text,
                N = (float)Convert.ToDouble(Number.Value),
            };

            //Load model and predict output
            var result = Fooding.Predict(sampleData);

            var qt = result.Score;
            MessageBox.Show("Quantité : " + qt.ToString());
            float quantity = _stocks.Where(s => s.Name == Product.cbData.Text).FirstOrDefault().Quantity;
            quantity  -= - qt;
            List<Stock> temp =new List<Stock>();
            foreach (Stock stock in _stocks) {
                if(stock.Name == Product.cbData.Text)
                {
                    stock.Quantity = quantity;
                }
                temp.Add(stock);
            }
            _foodWindow.stocks = temp;
            _foodWindow.RfStockList.ItemsSource = temp;
            _foodWindow.RfStockList.RefreshData();
            this.Close();
        }
    }
}
