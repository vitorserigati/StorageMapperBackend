using FastEndpoints;

namespace StorageMapper.Presentation.Endpoints;

internal sealed class LoginEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("api/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Task.Delay(10);
    }
}
