using Microsoft.AspNetCore.Mvc.Filters;
namespace API.Filters
{
    public class ExceptionGlobalFilter: ExceptionFilterAttribute
    {
        private readonly ISeriLog seriLog;
        public ExceptionGlobalFilter(ISeriLog seriLog)
        {
            this.seriLog = seriLog;
        }
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            seriLog.Log(context.Exception.Message);
            base.OnException(context);
        }
    }
}
