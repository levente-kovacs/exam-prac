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

namespace HelsinkiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Placement> placements = new List<Placement>();

        public MainWindow()
        {
            InitializeComponent();
            // forrásállomány beolvasása
            StreamReader reader = new StreamReader("helsinki.txt");
            while (!reader.EndOfStream)
            {
                Placement placement = new Placement(reader.ReadLine());
                placements.Add(placement);
            }
            reader.Close();

            Placements_lb.ItemsSource = placements;


        }

        private void Disqualify_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Placements_lb.SelectedItem != null)
            {
                placements.Remove((Placement)Placements_lb.SelectedItem);
                Placements_lb.Items.Refresh();
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("helsinki2.txt");
                foreach (Placement placement in placements)
                {
                    writer.WriteLine(placement.ToString());
                }
                writer.Close();
                MessageBox.Show("Sikeres Mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
