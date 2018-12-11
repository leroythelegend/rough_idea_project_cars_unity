using System;
namespace pcars
{
    public class GameMenuState : IGameState 
    {
        readonly ITelemetryProcessor processor;

        public GameMenuState(ITelemetryProcessor processor)
        {
            this.processor = processor;
        }

        public void Start(IAction action, PacketDecoder packet)
        {
            ChangeState(action, packet);

            processor.Process();
        }

        public void ChangeState(IAction action, PacketDecoder packet)
        {
            action.ChangeState(packet);
        }
    }
}
