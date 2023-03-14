using System;

namespace Logic.SoftCurrency
{
    public class CoinsCounter
    {
        public event Action<int> CoinsAdded;

        public int Current { get; private set; }

        public void Add(int value)
        {
            Current += value;
            CoinsAdded?.Invoke(Current);
        }

        public void Remove(int value)
        {
            Current -= value;
            CoinsAdded?.Invoke(Current);
        }
    }
}