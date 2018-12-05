using System;
namespace pcars
{
    public class GamePlayingState : IGameState
    {
        public GamePlayingState()
        {
        }

        public void Start(IAction action, PacketDecoder packet)
        {
            ChangeState(action, packet);
            // record or live feed while playing
        }

        public void ChangeState(IAction action, PacketDecoder packet)
        {
            action.ChangeState(packet);
        }
    }
}
