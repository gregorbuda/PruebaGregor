using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Utils
{
    /// <summary>
    /// Class that handle a customize message for any model problem, how can be into the parameters of the url or validation by DataAnnotations Library. 
    /// </summary>
    /// <returns></returns>
    public class CustomBadRequest : ApiResponse<Boolean?>
    {
        /// <summary>
        /// Constructor of the CustomBadRequest class
        /// </summary>
        /// <param name="response context"></param>
        public CustomBadRequest(ActionContext context)
        {
            //Initialize the properties of the class
            this.Success = false;
            //This
            this.Message = ConstructErrorMessages(context);
            this.CodeResult = 400.ToString();
            this.Data = null;
        }

        /// <summary>
        /// Method that handle and sort all the possible errors 
        /// </summary>
        /// <param name="response context"></param>
        private String ConstructErrorMessages(ActionContext context)
        {
            String ErrorMessage = "";

            //Review possible errors
            foreach (var keyModelStatePair in context.ModelState)
            {
                //the variable key is the name of the field that containt the error
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    foreach (var error in errors)
                    {
                        if (error.ErrorMessage.Contains(key))
                        {
                            //if in the body of the error contain the name of the field, show the error without the field
                            ErrorMessage = error.ErrorMessage.Remove(error.ErrorMessage.Length - 1) + ", " + ErrorMessage;
                        }
                        else
                        {
                            //if in the body of the error doesnt contain the name of the field, show the error with the field
                            ErrorMessage = key + ": " + error.ErrorMessage.Remove(error.ErrorMessage.Length - 1) + ", " + ErrorMessage;
                        }

                    }
                }
            }

            //The Differente errors in a variable
            ErrorMessage = ErrorMessage.Remove(ErrorMessage.Length - 2);
            return ErrorMessage;
        }
    }
}
