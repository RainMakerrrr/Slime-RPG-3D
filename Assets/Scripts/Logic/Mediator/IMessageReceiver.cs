namespace Logic.Mediator
{
    public interface IMessageReceiver
    {
        void Receive(int count = 0);
    }
}