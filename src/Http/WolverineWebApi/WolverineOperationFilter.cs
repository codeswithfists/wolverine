using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Wolverine.Http;

namespace WolverineWebApi;

#region sample_WolverineOperationFilter

// This class is NOT distributed in any kind of Nuget today, but feel very free
// to copy this code into your own as it is at least tested through Wolverine's
// CI test suite
public class WolverineOperationFilter : IOperationFilter // IOperationFilter is from Swashbuckle itself
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.ActionDescriptor is WolverineActionDescriptor action)
        {
            operation.OperationId = action.Chain.OperationId;

            if (!string.IsNullOrEmpty(action.Chain.EndpointSummary))
            {
                operation.Summary = action.Chain.EndpointSummary;
            }

            if (!string.IsNullOrEmpty(action.Chain.EndpointDescription))
            {
                operation.Description = action.Chain.EndpointDescription;
            }
        }
    }
}

#endregion