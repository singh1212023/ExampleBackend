namespace RoleBasedAuthenticateProject.Models
{
    public class ApiLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiLoggingMiddleware> _logger;
        private readonly sdirectdbContext _dbContext; // Replace YourDbContext with your actual Entity Framework DbContext

        public ApiLoggingMiddleware(RequestDelegate next, ILogger<ApiLoggingMiddleware> logger, sdirectdbContext dbContext)
        {
            _next = next;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task Invoke(HttpContext context)
        {
            string apiName = context.Request.Path; // Use any logic to determine the API name
            string ipAddress = context.Connection.RemoteIpAddress?.ToString();

            // Save the data to the database
            await SaveApiLog(apiName, ipAddress);

            // Call the next middleware in the pipeline
            await _next(context);
        }

        private async Task SaveApiLog(string apiName, string ipAddress)
        {
            try
            {
                // Create a new entry in the ApiLogs table
                var data =  _dbContext.SatyamMiddleWares.FirstOrDefault(i => i.MiddleWareName == apiName);
                if (data != null) 
                {
                   

                }else
                {
                    _dbContext.SatyamMiddleWares.Add(data);
                    await _dbContext.SaveChangesAsync();
                }
                         
                
               

                // Add the entry to the DbContext and save changes to the database
                

            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during database operations
                _logger.LogError(ex, "Error while saving API log to the database.");
            }
        }
    }
}
