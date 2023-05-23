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

namespace haromszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Triangle> triangles = new List<Triangle>();

        public MainWindow()
        {
            InitializeComponent();

            // forrásállomány beolvasása
            StreamReader reader = new StreamReader("haromszogek.csv");
            while (!reader.EndOfStream)
            {
                Triangle triangle = new Triangle(reader.ReadLine());
                triangles.Add(triangle);
            }
            reader.Close();

            Triangles_datagrid.ItemsSource = triangles;
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(A_box.Text) < int.Parse(B_box.Text) && int.Parse(B_box.Text) < int.Parse(C_box.Text))
            {
                triangles.Add(new Triangle($"{A_box.Text} {B_box.Text} {C_box.Text}"));
                Triangles_datagrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek!");
            }
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("haromszogek2.csv");
                foreach (Triangle triangle in triangles)
                {
                    writer.WriteLine(triangle.ToString());
                }
                writer.Close();
                MessageBox.Show("A mentés sikeresen megtörtént!");
            }
            catch
            {
                MessageBox.Show("Hiba!");
            }

        }
    }
}
