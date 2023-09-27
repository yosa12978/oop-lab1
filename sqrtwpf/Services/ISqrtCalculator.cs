using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrtwpf.Services
{
    /// <summary>
    /// record of calculation result
    /// </summary>
    /// <param name="guess">guess</param>
    /// <param name="epsilon">epsilon</param>
    /// <param name="delta">delta</param>
    /// <param name="iters">iters</param>
    public record CalculationResult(decimal guess, decimal epsilon, decimal delta, decimal iters);
    /// <summary>
    /// Square root calculator interface
    /// </summary>
    public interface ISqrtCalculator
    {
        /// <summary>
        /// square root prototype that must return a double
        /// </summary>
        /// <param name="n">input number</param>
        /// <returns>square root of n</returns>
        double Sqrt(double n);
        /// <summary>
        /// square root prototype that must return a decimal
        /// </summary>
        /// <param name="n">input number</param>
        /// <returns>square root of n</returns>
        CalculationResult Sqrt(decimal n);
    }
}
