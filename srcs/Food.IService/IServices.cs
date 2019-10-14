namespace Food.IService
{
    public interface IServices
    {
        void RunCommand<TCommand>(TCommand command);
        TResult RunQuery<TResult>(IQuery<TResult> query);
    }
}
