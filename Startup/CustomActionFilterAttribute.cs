using aws_test.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace aws_test.Startup
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                IEnumerable<FieldError> errors = GetErrors(context.ModelState);
                context.Result = new BadRequestObjectResult(new BadRequestResponse(errors));
            }
            
            base.OnActionExecuting(context);
        }

        private IEnumerable<FieldError> GetErrors(ModelStateDictionary modelState) => 
            modelState
                .Where(entry => entry.Value?.ValidationState == ModelValidationState.Invalid)
                .Select(CreateFieldError);
        
        private FieldError CreateFieldError(KeyValuePair<string, ModelStateEntry?> entry)
        {
            string propertyName = entry.Key;
            IEnumerable<string> errorMessages = entry.Value?.Errors.Select(error => error.ErrorMessage) ?? new string[] {};
            return new FieldError(propertyName, errorMessages);
        }
    }
}