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

namespace BaseConverter
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

        /// <summary>
        /// Событие нажатия на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            int n;
            int basis;
            // trying to parse inputs
            if (!int.TryParse(InputTextBox.Text, out n) || !int.TryParse(BaseTextBox.Text, out basis))
            {
                // if err occurs display messagebox
                MessageBox.Show("You must enter an integer");
                return;
            }
            //checking if basis within 2 and 62
            if (basis < 2 || basis > 62)
            {
                // if its not show messagebox
                MessageBox.Show("Base must be between 2 and 62 included");
                return;
            }
            // if everything is fine change label content
            OutputLabel.Content = String.Format("Output: {0}", ToBase(n, basis));
        }

        /// <summary>
        /// Функция перевода числа в произвольное основание от 2 до 62 включительно
        /// </summary>
        /// <param name="number">число которое будет преобразовываться</param>
        /// <param name="basis">основание</param>
        /// <returns>преобразованное число в виде строки</returns>
        static string ToBase(int number, int basis)
        {
            // alphabet
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int n = number;
            var sb = new StringBuilder();
            // here i'm just using a standard algorithm for this situation
            while (n > 0)
            {
                int temp = n % basis;
                sb.Append(alphabet[temp]);
                n /= basis;
            }
            // returning reversed string
            return new string(sb.ToString().Reverse().ToArray());
        }
    }
}
