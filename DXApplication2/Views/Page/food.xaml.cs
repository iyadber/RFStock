using DXApplication2.Messages;
using DXApplication2.Models;
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
using System.Windows.Threading;

namespace DXApplication2.Views.Page
{
    /// <summary>
    /// Interaction logic for food.xaml
    /// </summary>
    public partial class food : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        int l = 3;
        int number;
        public IEnumerable<Stock> stocks;
        public food()
        {
            InitializeComponent();
            timer.Tick += UpdateTimer;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            if (trafficLightsIndicator.StateIndex == 0)
                trafficLightsIndicator.StateIndex = l;
            else
                trafficLightsIndicator.StateIndex = 0;
        }

        public async Task GetRfStockData()
        {

            await Task.Delay(200);
            timer.Start();
            
            trafficLightsIndicator.StateIndex = 2;
           
            l = 1;
            trafficLightsIndicator.StateIndex = 1;
            await Task.Delay(200);
            stocks = new List<Stock>()
            {
                new Stock() { Id = 1, Name = "pain", Quantity = 0},
                new Stock() { Id = 2, Name = "Tomato", Quantity = 0},
                new Stock() { Id = 3, Name = "pomme de terre", Quantity = 0},
                new Stock() { Id = 4, Name = "spaghetti", Quantity = 0},
                new Stock() { Id = 5, Name = "viand", Quantity = 0},
                new Stock() { Id = 6, Name = "poulets", Quantity = 0},
                new Stock() { Id = 7, Name = "huiles", Quantity = 0},
                

            };
            RfStockList.ItemsSource = stocks;
            number = new Random().Next(1000, 6000);
            RfStockNumbers.Text = $"Total Number : { number }";
            trafficLightsIndicator.Visibility = Visibility.Collapsed;

            timer.Stop();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await GetRfStockData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStock addstockPage = new AddStock(number, stocks, this);
            addstockPage.ShowDialog();
        }
    }
}
