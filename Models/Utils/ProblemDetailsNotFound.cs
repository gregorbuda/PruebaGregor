using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utils
{
    /// <summary>
    /// Problem details for NotFound response
    /// </summary>
    public class ProblemDetailsNotFound
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
        /// <example>404</example>
        public String CodeResult { get; set; }
        /// <summary>
        /// The message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <example>NotFound, Element or search not found.</example>
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
