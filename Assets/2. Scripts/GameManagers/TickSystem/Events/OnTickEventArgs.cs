using System;

namespace GameManagers.TickSystem.Events
{
    public class OnTickEventArgs : EventArgs
    {
        public int Tick;

        public OnTickEventArgs(int tick)
        {
            throw new NotImplementedException();
        }
    }
}