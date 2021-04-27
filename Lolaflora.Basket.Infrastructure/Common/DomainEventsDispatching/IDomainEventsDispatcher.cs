using System.Threading.Tasks;

namespace Lolaflora.Baskets.Infrastructure.Common.DomainEventsDispatching
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}