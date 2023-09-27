using sqrtwpf.Services;
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

namespace sqrtwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISqrtCalculator stdMathCalc;
        private readonly ISqrtCalculator newtonsCalc;
        private ISqrtStepCalculator iterCalc;
        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // инициализация сервисов
            this.stdMathCalc = new StdMathService();
            this.newtonsCalc = new NewtonService();
            this.iterCalc = new NewtonIterationService(0);
        }

        /// <summary>
        /// CalcBtn button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            double inp;
            decimal inpDecimal;
            // trying to parse input in double and decimal
            if (!double.TryParse(InputVal.Text, out inp) || !decimal.TryParse(InputVal.Text, out inpDecimal))
            {
                MessageBox.Show("Please enter a double");
                return;
            }
            // checking if its negative
            if (inp < 0 || inpDecimal < 0) 
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }
            // if everything is ok changing the content of labels by calling these functions
            DotnetOutLabel.Content = String.Format("{0} (Using .NET 6)", stdMathCalc.Sqrt(inp));



            // performing calculation via newtons method
            CalculationResult res = newtonsCalc.Sqrt(inpDecimal);
            // change newtonsoutlabel content
            NewtonsOutLabel.Content = String.Format("{0} (Using Newton's method)", res.guess);
            // change epsilon label content
            DeltaLabel.Content = String.Format("Delta: {0}", res.delta);
            // change epsilon label content
            EpsilonLabel.Content = String.Format("Epsilon: {0}", res.epsilon);
            // change iters label content
            IterationsLabel.Content = String.Format("Iterations: {0}", res.iters);

            // reset step by step calculator
            iterCalc = new NewtonIterationService(0);
        }

        /// <summary>
        /// StepButton clock event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            decimal inpDecimal;
            // parsing InputVal textbox text to a inpDecimal variable
            if (!decimal.TryParse(InputVal.Text, out inpDecimal))
            {
                MessageBox.Show("Please enter a double");
                return;
            }
            // if number changed then start everything from beginning
            if (inpDecimal != this.iterCalc.N)
            {
                iterCalc = new NewtonIterationService(inpDecimal);
                DotnetOutLabel.Content = String.Format("{0} (Using .NET 6)", stdMathCalc.Sqrt((double)inpDecimal));
            }
            // change newtons label content
            NewtonsOutLabel.Content = String.Format("{0} (Using Newton's method)", iterCalc.Step());
            // change delta label content
            DeltaLabel.Content = String.Format("Delta: {0}", iterCalc.Delta);
            // change epsilon label content
            EpsilonLabel.Content = String.Format("Epsilon: {0}", iterCalc.Epsilon);
            // change iters label content
            IterationsLabel.Content = String.Format("Iterations: {0}", iterCalc.Iters);
        }
    }
}
