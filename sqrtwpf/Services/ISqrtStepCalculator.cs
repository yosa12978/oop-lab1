using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqrtwpf.Services
{
    /// <summary>
    /// step by step square root calculator interface
    /// </summary>
    public interface ISqrtStepCalculator
    {
        /// <summary>
        /// epsilon getter
        /// </summary>
        decimal Epsilon { get; }
        /// <summary>
        /// iters getter
        /// </summary>
        decimal Iters { get; }
        /// <summary>
        /// delta getter
        /// </summary>
        decimal Delta { get; }
        /// <summary>
        /// properety of a number that we deal with
        /// </summary>
        decimal N { get; set; }
        /// <summary>
        /// method that must perform single step
        /// </summary>
        /// <returns>a result of a step</returns>
        decimal Step();
    }
}
