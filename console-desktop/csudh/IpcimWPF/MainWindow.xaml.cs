using System;
using System.Collections.Generic;
using System.IO;
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

namespace IpcimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<IpAddress> IpAddresses = new List<IpAddress>();

        public MainWindow()
        {
            InitializeComponent();
            // filebeolvasás
            StreamReader reader = new StreamReader("csudh.txt");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                IpAddress IpAddress = new IpAddress(reader.ReadLine());
                IpAddresses.Add(IpAddress);
            }
            reader.Close();

            ip_dg.ItemsSource = IpAddresses;
        }

        private void input_btn_Click(object sender, RoutedEventArgs e)
        {
            if (domain_tb.Text == "" || ip_tb.Text == "")
            {
                MessageBox.Show("Nem történt adatmegadás.");
                return;
            }
            IpAddress ipAddress = new IpAddress(domain_tb.Text, ip_tb.Text);
            IpAddresses.Add(ipAddress);
            ip_dg.Items.Refresh();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("domainek.txt");
                foreach (IpAddress ip in IpAddresses)
                {
                    writer.WriteLine(ip.ToString());
                }
                writer.Close();
                MessageBox.Show("Sikeres Mentés!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
