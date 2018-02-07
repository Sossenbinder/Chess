using SFMLChess.Logic;

namespace SFMLChess.MainWindow
{
    public class MainWindowModel
    {
        private GameState m_gameState;

        public MainWindowModel()
        {
            m_gameState = new GameState();
        }

        public GameState GetGameState()
        {
            return m_gameState;
        }

        public void InitializeGameState()
        {
            m_gameState.InitializeGameState();
        }
    }
}
