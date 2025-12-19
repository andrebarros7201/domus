using Microsoft.AspNetCore.Mvc;

namespace Domus.API.ServiceResult;

public class ServiceResult<T> {
    public ServiceResultStatus Status { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int? NumberPages { get; set; } // Used for pagination

    public static ServiceResult<T> Ok(T data, int? numberPages = null) {
        return new ServiceResult<T> { Data = data, Status = ServiceResultStatus.Ok, NumberPages = numberPages };
    }

    public static ServiceResult<T> Created(string message, T? data = default) {
        return new ServiceResult<T> { Data = data, Status = ServiceResultStatus.Created, Message = message };
    }

    public static ServiceResult<T> Error(string message, ServiceResultStatus status) {
        return new ServiceResult<T> { Message = message, Status = status };
    }

    public static IActionResult ServiceResultResponse(ServiceResult<T> result) {
        return result.Status switch {
            ServiceResultStatus.Ok => result.NumberPages != null
             ? new OkObjectResult(new { data = result.Data, numberPages = result.NumberPages })
             : new OkObjectResult(result.Data),
            ServiceResultStatus.Created => result.Data != null
             ? new ObjectResult(new { data = result.Data, message = result.Message }) { StatusCode = 201 }
             : new ObjectResult(new { message = result.Message }) { StatusCode = 201 },
            ServiceResultStatus.BadRequest => new BadRequestObjectResult(new { message = result.Message }),
            ServiceResultStatus.NotFound => new NotFoundObjectResult(new { message = result.Message }),
            ServiceResultStatus.Conflict => new ConflictObjectResult(new { message = result.Message }),
            ServiceResultStatus.Unauthorized => new UnauthorizedObjectResult(new { message = result.Message }),
            ServiceResultStatus.Forbidden => new ObjectResult(new { message = result.Message }) { StatusCode = 403 },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}