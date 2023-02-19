using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class ExceptionGlobalFilter: ExceptionFilterAttribute
    {
        private readonly ISeriLog seriLog;
        public ExceptionGlobalFilter(ISeriLog seriLog)
        {
            seriLog = seriLog;
            this.seriLog = seriLog;
        }
        public override void OnException(ExceptionContext context)
        {
            seriLog.Log(context.Exception.Message);
            base.OnException(context);
        }
    }
}
