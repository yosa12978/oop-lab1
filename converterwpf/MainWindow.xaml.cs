using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace converterwpf
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

        // Обработчик события Button_Click для текстового поля
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double result;
            // парсим значение текстбокса
            if(!double.TryParse(textBox1.Text, out result))
            {
                // если появляется не получается то издаем характерный звук и показываем messagebox
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("This is not a floating point number. Use your default system float separator.");
                return;
            }
            // если всё хорошо то показываем messagebox с сообщением об успехе
            MessageBox.Show($"Everything is ok result={result}");
        }
    }
}
