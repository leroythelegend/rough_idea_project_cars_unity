using System;

namespace pcars
{
    public interface IAction
    {
        void Start(PacketDecoder packet);


        void ChangeState(PacketDecoder packet);
    }
}
