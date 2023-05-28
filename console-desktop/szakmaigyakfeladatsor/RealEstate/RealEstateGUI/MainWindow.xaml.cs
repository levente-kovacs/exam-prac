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

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Ad> ads = Ad.LoadFromCsv("realestates.csv");

        public MainWindow()
        {
            InitializeComponent();
            List<string> names = new List<string>();
            foreach (Ad ad in ads)
            {
                names.Add(ad.Seller.Name);
            }
            Names_lb.ItemsSource = names;
        }

        private void Names_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Names_lb.SelectedItem!= null)
            {
                int selectedIndex = Names_lb.SelectedIndex;
                SellerName_Label.Content = ads[selectedIndex].Seller.Name;
                SellerPhone_Label.Content = ads[selectedIndex].Seller.Phone;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Names_lb.SelectedItem != null)
            {
                string selectedName = Names_lb.SelectedItem.ToString();
                int adsCount = 0;
                foreach (Ad ad in ads)
                {
                    if (ad.Seller.Name == selectedName)
                    {
                        adsCount++;
                    }
                }
                AdsCount_Label.Content = adsCount;
            }

        }
    }
}
