using System;
namespace pcars
{
    public interface IGameState
    {
        void Start(IAction action, PacketDecoder packet);

        void ChangeState(IAction action, PacketDecoder packet);        
    }
}
