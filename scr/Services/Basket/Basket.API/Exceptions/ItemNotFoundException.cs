using BuildingBlocks.Exceptions;

namespace Basket.API.Exceptions
{
    public class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException(Guid Id) : base ("Item", Id)
        {
        }
    }
}
