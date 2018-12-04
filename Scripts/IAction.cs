using System;

namespace pcars
{
    public interface IAction
    {
        void Record();
        void Display();

        void Process(PacketDecoder packet);


        void ChangeState(IGameState state);
    }
}
