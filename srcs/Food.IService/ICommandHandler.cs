namespace Food.IService
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}