using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OnStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product>  Products { get; set; }
        public ObservableCollection<Product>  TempProducts { get; set; }
        EditWindow editWindow;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            Products = new ObservableCollection<Product>
            {
                new Product{ Name="Hummel Qara Ayaqqabı", Price= 30, Image_Source="Images/shoes.png"},
                new Product{ Name="Nike Dry Park T-Shirt", Price=12,Image_Source="Images/T-shirt1.png"},
                new Product{ Name="GymLegend T-Shirt", Price=17, Image_Source="Images/T-shirt2.png"},
                new Product{ Name="POLO Rucci Kişi Qol Saatı", Price=100, Image_Source="Images/saat.png"},
            };
            TempProducts = Products;
        }

        public string Time { get; set; } = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            editWindow = new EditWindow();
            editWindow.Product = (sender as ListBox).SelectedItem as Product;
            editWindow.Visibilty ="Hidden";
            editWindow.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            editWindow = new EditWindow();
            editWindow.Visibilty = "Visible";
            editWindow.Show();
        }

        private void txb_main_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txb_main.Text))
            {
                txb_second.Visibility = System.Windows.Visibility.Visible;
                txb_main.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void txb_second_GotFocus(object sender, RoutedEventArgs e)
        {
            txb_second.Visibility = System.Windows.Visibility.Collapsed;
            txb_main.Visibility = System.Windows.Visibility.Visible;
        }

        private void txb_main_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txb_main.Text.Length != 0 && txb_main.Text != "Search")
            {
                var searchText = txb_main.Text.ToLower();
                List<Product> productsList = new List<Product>();
                productsList = TempProducts.Where(p => p.Name.ToLower().StartsWith(searchText)).ToList();
                ObservableCollection<Product> newList = new ObservableCollection<Product>(productsList);
                Products = newList;
                lbox_products.ItemsSource = newList;

            }
            else if (txb_main.Text.Length == 0)
            {
                Products = TempProducts;
                lbox_products.ItemsSource = Products;
            }
        }
    }
}
