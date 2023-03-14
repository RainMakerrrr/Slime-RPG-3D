namespace Logic.Mediator
{
    public interface ILevelMediator
    {
        void Send(IMessageReceiver receiver, int count = 0);
    }
}