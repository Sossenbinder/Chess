using SFMLChess.Logic.BoardLogic;
using SFMLChess.Logic.PlayerLogic;

namespace SFMLChess.Logic
{
    public class GameState
    {
        private bool m_isInitialized = true;

        private readonly Board m_board;

        private Player m_blackPlayer;

        private Player m_whitePlayer;

        public GameState()
        {
            m_blackPlayer = new Player();
            m_whitePlayer = new Player();
            m_board = new Board(m_blackPlayer.m_graveyard, m_blackPlayer.m_history, m_whitePlayer.m_graveyard, m_whitePlayer.m_history);
        }

        public void InitializeGameState()
        {
            m_board.ResetBoard();
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
