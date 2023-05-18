using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace IskolaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Student> students = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();

            // nevek.txt beolvasása
            StreamReader reader = new StreamReader("nevek.txt");
            while (!reader.EndOfStream)
            {
                Student student = new Student(reader.ReadLine());
                students.Add(student);
            }
            reader.Close();

            listBox.ItemsSource = students;

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                students.RemoveAt(listBox.SelectedIndex);
                listBox.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("nevekNEW.txt");
                foreach (Student student in students)
                {
                    writer.WriteLine(student);
                }
                writer.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
