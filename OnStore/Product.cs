using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnStore
{
    public class Product:INotifyPropertyChanged
    {
       private string name;

       public string Name
       {
           get { return name; }
           set { name = value; 
                OnPropertyRaised(); 
           }
       }

       private double price;

       public double Price
       {
           get { return price; }
           set { price = value; OnPropertyRaised(); }
        }

        private string image_source;


        public string Image_Source
        {
            get { return image_source; }
            set { image_source = value; OnPropertyRaised(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
