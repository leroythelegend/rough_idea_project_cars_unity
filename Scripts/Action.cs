using System;
namespace pcars
{
    public class Action : IAction
    {
        IGameState frontEnd;
        IGameState playing;
        IGameState menu;
        IGameState currentState;

        public Action()
        {
            frontEnd = new GameFrontEndState();
            playing = new GamePlayingState();
            menu = new GameMenuState();

            currentState = frontEnd;
        }

        public void Start(PacketDecoder packet)
        {
            currentState.Start(this, packet);
        }


        public void ChangeState(PacketDecoder packet)
        {
            if (packet.GetType().Name == "GameStateDataDecoder") {

                var gameState = (GameStateDataDecoder)packet;

                switch (gameState.gameState.GameState())
                {
                    case GameStates.GAME_INGAME_PLAYING:
                        currentState = playing;
                        break;
                    case GameStates.GAME_INGAME_INMENU_TIME_TICKING:
                        currentState = menu;
                        break;
                    case GameStates.GAME_FRONT_END:
                        currentState = frontEnd;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
