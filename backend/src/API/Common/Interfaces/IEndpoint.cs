namespace API.Common.Extensions
{
    public interface IEndpoint
    {
        void AddRoute(IEndpointRouteBuilder app);
    }
}