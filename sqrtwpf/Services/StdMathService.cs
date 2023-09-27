using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrtwpf.Services
{
    /// <summary>
    /// ISqrtCalculator implementation for System.Math.Sqrt method
    /// </summary>
    public class StdMathService : ISqrtCalculator
    {
        /// <summary>
        /// StdMathService constructor
        /// </summary>
        public StdMathService() 
        {
        
        }
        /// <summary>
        /// calculates sqrt of n using Math.Sqrt method
        /// </summary>
        /// <param name="n">input number</param>
        /// <returns>sqrt of n in double</returns>
        public double Sqrt(double n) => Math.Sqrt(n);

        /// <summary>
        /// calculates sqrt of n using Math.Sqrt method
        /// </summary>
        /// <param name="n">input number</param>
        /// <returns>nothing because not implemented</returns>
        /// <exception cref="NotImplementedException">i just dont need it in this case</exception>
        public CalculationResult Sqrt(decimal n) =>
            throw new NotImplementedException();
    }
}
