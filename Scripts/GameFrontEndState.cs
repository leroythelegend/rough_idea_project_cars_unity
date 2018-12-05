using System;
namespace pcars
{
    public class GameFrontEndState : IGameState
    {
        public GameFrontEndState()
        {
        }

        public void Start(IAction action, PacketDecoder packet)
        {
            // Currently do nothing when in the frontend
            ChangeState(action, packet);
        }

        public void ChangeState(IAction action, PacketDecoder packet)
        {
            action.ChangeState(packet);
        }
    }
}
