﻿namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/Baskets/{UserName}", async (string UserName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(UserName));

                var response = result.Adapt<DeleteBasketResponse>();

                return Results.Ok(response);
            })
                .WithName("DeleteProduct")
                .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product");
        }
    }
}
