using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utils
{
    /// <summary>
    /// Problem details for Internal Server Error response
    /// </summary>
    public class ProblemDetailsInternalServerError
    {
        /// <summary>
        /// Indicates that the call response is inccorrect.
        /// </summary>
        /// <value>
        /// The code result.
        /// </value>
        /// <example>False</example>
        public bool Success { get; set; }
        /// <summary>
        /// The code result.
        /// </summary>
        /// <value>
        /// The code result.
        /// </value>
        /// <example>500</example>
        public String CodeResult { get; set; }
        /// <summary>
        /// The message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <example>Internal Server Error.</example>
        public String Message { get; set; }
        /// <summary>
        /// In this case it is always null, because there is no data to display.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public String Data { get; set; }
    }
}
