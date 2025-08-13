using System.Net.Mime;
using System.Net;
using System.Text.Json;
using HealthCare.Helper;
using EmailService;

namespace HealthCare
{ 
    public class ExceptionMiddleware
    {
        private readonly ILoggerManager _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(ILoggerManager logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IEmailSender emailSender)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                var message = new Message(new string[] { "----@edu.fit.ba" }, "Exception handler", ex.ToString());
                emailSender.SendEmail(message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new CustomResponse(context.Response.StatusCode, ex.Message, "Internal Server Error");
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
