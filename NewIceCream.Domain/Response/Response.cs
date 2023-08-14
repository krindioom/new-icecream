using NewIceCream.Domain.Enums;

namespace NewIceCream.Domain.Response;

public class Response<T>
{
    public T? Data { get; set; }

    public StatusCode StatusCode { get; set; }

    public string? Description { get; set; }
}

