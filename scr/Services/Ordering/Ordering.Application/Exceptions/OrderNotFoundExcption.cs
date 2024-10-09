using BuildingBlocks.Exceptions;

namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundExcption : NotFoundException
    {
        public OrderNotFoundExcption(Guid id) : base("Order", id)
        {
        }
    }
}
