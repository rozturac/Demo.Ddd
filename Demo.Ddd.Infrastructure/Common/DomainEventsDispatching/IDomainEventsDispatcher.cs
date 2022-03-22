using System.Threading.Tasks;

namespace Demo.Ddd.Infrastructure.Common.DomainEventsDispatching
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}