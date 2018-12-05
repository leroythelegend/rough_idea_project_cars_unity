using System;
namespace pcars
{
    public class GamePlayingState : IGameState
    {
        ITelemetryProcessor processor;

        public GamePlayingState(ITelemetryProcessor processor)
        {
            this.processor = processor;
        }

        public void Start(IAction action, PacketDecoder packet)
        {
            ChangeState(action, packet);

            processor.AddPacket(packet);
            processor.Process();
        }

        public void ChangeState(IAction action, PacketDecoder packet)
        {
            action.ChangeState(packet);
        }
    }
}
