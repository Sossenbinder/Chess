using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.Logic
{
    public class GameState
    {
        private bool m_isInitialized = true;

        private readonly Board m_board;

        public GameState()
        {
            m_board = new Board();
        }

        public void InitializeGameState()
        {
            
        }

        public Board GetBoard()
        {
            return m_board;
        }

        public bool IsInitialized()
        {
            return m_isInitialized;
        }
    }
}
