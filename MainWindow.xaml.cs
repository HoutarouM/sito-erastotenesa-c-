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

namespace SitoErastotenesa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindFirstNumbers(object sender, RoutedEventArgs e)
        {
            res_text_block.Text = "";

            if (int.TryParse(num_text.Text, out int n) && n > 1)
            {
                bool[] nums = SieveOfEratosthenes(n);

                // print first numbers
                for (int i = 1; i < n; i++)
                {
                    if (nums[i] == true)
                    {
                        String text = res_text_block.Text;
                        res_text_block.Text = text + " " + i.ToString();
                    }
                }
            }

            // TODO: else message box
        }

        private bool[] SieveOfEratosthenes(int n)
        {
            bool[] values = new bool[n];

            // fill array true values
            for(int i = 0; i < n; i++)
            {
                values[i] = true;
            }

            // SieveOfEratosthenes
            for(int i = 2; i < Math.Sqrt(n); i++)
            {
                if (values[i] == true)
                {
                    for(int j = i * i; j < n; j += i)
                    {
                        values[j] = false; 
                    }
                }
            }

            return values;
        }
    }
}
