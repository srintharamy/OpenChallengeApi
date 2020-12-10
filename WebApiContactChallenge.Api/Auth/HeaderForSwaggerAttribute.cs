using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApiContactChallenge.Api.Auth
{
    public class HeaderForSwaggerAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = AuthenticationMiddleware.FakeAuthorization,
                In = ParameterLocation.Header,
                Description = "Just enter your email"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "FakePassword",
                In = ParameterLocation.Header,
                Description = "Enter '1234'",
                Required = true
            });
        }
    }
}