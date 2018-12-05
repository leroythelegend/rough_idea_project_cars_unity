using System;
namespace pcars
{
    public class GameMenuState : IGameState 
    {
        public GameMenuState()
        {
        }

        public void Start(IAction action, PacketDecoder packet)
        {
            ChangeState(action, packet);

            // do something with recorded data
        }

        public void ChangeState(IAction action, PacketDecoder packet)
        {
            action.ChangeState(packet);
        }
    }
}
