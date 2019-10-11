using IService;

namespace Food.Service
{
    public interface IServices
    {
        void RunCommand<TCommand>(TCommand command);
        TResult RunQuery<TResult>(IQuery<TResult> query);
    }
}
