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

namespace IskolaWPF
{
    public partial class MainWindow : Window
    {

        static List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();


            StreamReader reader = new StreamReader("nevek.txt");
            while (!reader.EndOfStream)
            {
                string[] dataInRow = reader.ReadLine().Split(';');
                Student student = new Student(int.Parse(dataInRow[0]), char.Parse(dataInRow[1]), dataInRow[2]);
                students.Add(student);
            }
            reader.Close();

            students_listBox.ItemsSource = students;
            students_listBox.Items.Refresh();


        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (students_listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }
            else
            {
                students.RemoveAt(students_listBox.SelectedIndex);
                students_listBox.Items.Refresh();
            }
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("nevekNEW.txt");
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.Year};{student.ClassChar};{student.Name}");
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
