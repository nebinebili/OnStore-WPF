using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace OnStore
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window, INotifyPropertyChanged
    {
        public Product Addproduct { get; set; }

        private Product product;


        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyRaised(); }
        }


        public string Visibilty { get; set; }

        public EditWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox_Name.Text==null || txtbox_price.Text==null || image.Source==null)
            {
                MessageBox.Show("Fill Product !");
            }
            else
            {
                Addproduct = new Product()
                {
                    Name = txtbox_Name.Text,
                    Price = Convert.ToDouble(txtbox_price.Text),
                    Image_Source = image.Source.ToString()
                };

                ((MainWindow)Application.Current.MainWindow).Products.Add(Addproduct);
            }

            
        }

        private void Image_add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Multiselect = false;
            openFile.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            openFile.FilterIndex = 2;

            if (openFile.ShowDialog() ==true)
            {
                image.Source = new BitmapImage(new Uri(openFile.FileName));
            }           
        }
    }
}
