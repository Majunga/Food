namespace Food.IService
{
    public interface IQueryHandler<in TQuery, out TResult>
    {
        TResult Handle(TQuery query);
    }
}
