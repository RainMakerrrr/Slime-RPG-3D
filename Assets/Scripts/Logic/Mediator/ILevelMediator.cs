namespace Logic.Mediator
{
    public interface ILevelMediator
    {
        void Send(IMessageReceiver receiver);
    }
}