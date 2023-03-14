namespace Logic.Mediator
{
    public class LevelMediator : ILevelMediator
    {
        private readonly IMessageReceiver _player;
        private readonly IMessageReceiver _monsterSpawner;

        public LevelMediator(IMessageReceiver player, IMessageReceiver monsterSpawner)
        {
            _player = player;
            _monsterSpawner = monsterSpawner;
        }

        public void Send(IMessageReceiver receiver, int count = 0)
        {
            if (receiver == _player)
                _monsterSpawner.Receive(count);
            else if (receiver == _monsterSpawner)
                _player.Receive(count);
        }
    }
}