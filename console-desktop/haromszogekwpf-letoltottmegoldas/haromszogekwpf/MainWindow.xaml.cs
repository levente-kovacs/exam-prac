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
using System.IO;

namespace haromszogekwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Haromszog> haromszogek = new List<Haromszog>();
        public MainWindow()
        {
            InitializeComponent();

            StreamReader reader = new StreamReader("haromszogek.csv");
            while(!reader.EndOfStream)
            {
                haromszogek.Add(new Haromszog(reader.ReadLine()));
            }
            reader.Close();

            datagrid.ItemsSource = haromszogek;
            datagrid.Items.Refresh();

            
        }

        private void hozzadad_Click(object sender, RoutedEventArgs e)
        {
            int aOldal = int.Parse(a_oldal.Text);
            int bOldal = int.Parse(b_oldal.Text);
            int cOldal = int.Parse(c_oldal.Text);
            if (aOldal < bOldal && bOldal < cOldal)
            {
                haromszogek.Add(new Haromszog(aOldal, bOldal, cOldal));
                datagrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek!");
            }
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("haromszogek2.csv");
            foreach (var item in haromszogek)
            {
                writer.WriteLine($"{item.a} {item.b} {item.c}");
            }
            writer.Close();
            MessageBox.Show("A mentés sikeresen megtörtént!");

        }
    }
}
