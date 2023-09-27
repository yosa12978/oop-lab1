using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrtwpf.Services
{
    /// <summary>
    /// ISqrtIterCalc interface implementation for NewtonsMethod
    /// </summary>
    public class NewtonIterationService : ISqrtStepCalculator
    {
        /// <summary>
        /// is we set something to this property we reset every other values
        /// also we can get current "root" number
        /// </summary>
        public decimal N { 
            get 
            { 
                return n; 
            }
            set
            {
                n = value;
                root = n;
                guess = n / 2;
                delta = decimal.MaxValue;
                epsilon = (decimal)(1 / Math.Pow(10, 28));
                iters = 0;
            }
        }
        /// <summary>
        /// epsilon getter
        /// </summary>
        public decimal Epsilon { get => this.epsilon; }
        /// <summary>
        /// delta getter
        /// </summary>
        public decimal Delta { get => this.delta; }
        /// <summary>
        /// iters getter
        /// </summary>
        public decimal Iters { get => this.iters; }
        private decimal n { get; set; }
        private decimal guess;
        private decimal root;
        private decimal epsilon = (decimal)(1 / Math.Pow(10, 28));
        private decimal delta = decimal.MaxValue;
        private int iters = 0;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="n">number that sqrt we should calculate</param>
        public NewtonIterationService(decimal n) 
        {
            this.N = n;
        }

        /// <summary>
        /// this function performs a single step
        /// until delta <= epsilon
        /// if it is then it just returns sqrt stored in guess variable
        /// </summary>
        /// <returns>sqrt on current step</returns>
        public decimal Step()
        {
            if (delta <= epsilon)
                return guess;
            root = 0.5m * (guess + (n / guess));
            delta = Math.Abs(root - guess);
            guess = root;
            iters++;
            return guess;
        }
    }
    /// <summary>
    /// ISqrtCalculator implementation for newton method
    /// </summary>
    public class NewtonService : ISqrtCalculator
    {
        /// <summary>
        /// NewtonService constructor
        /// </summary>
        public NewtonService()
        {

        }

        /// <summary>
        /// calculates sqrt of n using Math.Sqrt method
        /// </summary>
        /// <param name="n">input number</param>
        /// <returns>nothing because not implemented</returns>
        /// <exception cref="NotImplementedException">i just dont need it in this case</exception>
        public double Sqrt(double n) =>
            throw new NotImplementedException();

        /// <summary>
        /// method does same thing as previous but n is decimal and it also returns sqrt in decimal
        /// </summary>
        /// <param name="n">input number</param>
        /// <returns>sqrt of n in decimal</returns>
        public CalculationResult Sqrt(decimal n)
        {
            int iters = 0;
            decimal delta = decimal.MaxValue;
            decimal epsilon = (decimal)(1 / Math.Pow(10, 28));
            decimal guess = n / 2;
            while (delta > epsilon)
            {
                decimal root = 0.5m * (guess + (n / guess));
                delta = Math.Abs(root - guess);
                guess = root;
                iters++;
            }
            return new CalculationResult(guess, epsilon, delta, iters);
        }
    }
}
