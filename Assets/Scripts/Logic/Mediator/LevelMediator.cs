namespace Logic.Mediator
{
    public class LevelMediator : ILevelMediator
    {
        private IMessageReceiver _player;
        private IMessageReceiver _monsterSpawner;

        public void Send(IMessageReceiver receiver)
        {
            if (receiver == _player)
                _monsterSpawner.Receive();
            else if (receiver == _monsterSpawner)
                _monsterSpawner.Receive();
        }
    }
}