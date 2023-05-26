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

namespace LabirintusGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 5; i < 21; i++)
            {
                comboB_X.Items.Add(i);
                comboB_Y.Items.Add(i);
                comboB_index.Items.Add(i-4);
            }
            comboB_X.SelectedItem = 12;
            comboB_Y.SelectedItem = 12;
            comboB_index.SelectedItem = 3;


        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            for (int i = vaszon.Children.Count-1; i >= 0; i--)
            {
                if (vaszon.Children[i] is CheckBox)
                {
                    vaszon.Children.Remove(vaszon.Children[i] as CheckBox);
                }
            }

            int row = (int)comboB_X.SelectedItem;
            int column = (int)comboB_Y.SelectedItem;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Margin = new Thickness(40+j*15, 150+i*15, 0, 0);
                    if (i == 0 || i == row - 1)
                    {
                        checkBox.IsChecked = true;
                        checkBox.IsEnabled = false;
                    }
                    if (j == 0 || j == column - 1)
                    {
                        checkBox.IsChecked = true;
                        checkBox.IsEnabled = false;
                    }
                    if ((i == 1 && j == 0) || (i == row-2 && j == column-1))
                    {
                        checkBox.IsChecked = false;
                    }
                    vaszon.Children.Add(checkBox);
                }
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter($"Lab{comboB_index.Text}.txt");

                int columnCounter = 0;
                int column = (int)comboB_Y.SelectedItem;
                for (int i = 0; i < vaszon.Children.Count; i++)
                {
                    if (vaszon.Children[i] is CheckBox)
                    {
                        columnCounter++;
                        CheckBox checkBox = (CheckBox)vaszon.Children[i];
                        if ((bool)checkBox.IsChecked)
                        {
                            writer.Write("X");
                        }
                        else
                        {
                            writer.Write(" ");
                        }
                    }
                    if (columnCounter == column)
                    {
                        writer.WriteLine();
                        columnCounter = 0;
                    }
                }
                writer.Close();
                MessageBox.Show("Az állomány mentése sikeres.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
