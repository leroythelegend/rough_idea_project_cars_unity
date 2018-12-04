using System;
namespace pcars
{
    public interface IGameState
    {
        void Record(IAction action);
        void Display(IAction action);

        void Process(IAction action, PacketDecoder packet);

        void ChangeState(IAction action, IGameState state);        
    }
}
