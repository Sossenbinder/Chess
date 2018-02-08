using System.Runtime.Remoting.Messaging;
using SFML.Graphics;
using SFMLChess.Logic;
using SFMLChess.Logic.BoardLogic;

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

        public Texture GetTextureForTile(int x, int y)
        {
            var board = m_gameState.GetBoard();
            var chessPiece = board.GetChessPieceForSpecificTile(x, y);
            
            return chessPiece?.GetTexture();
        }

        public ChessColor GetBoardColorForTile(int x, int y)
        {
            var board = m_gameState.GetBoard();
            return board.GetBoardColorForSpecificTile(x, y);
        }

        public Tile GetTileForMousePos(int x, int y)
        {
            var tileXIndex = (x - (int)MainWindowMetaData.CHESSBOARDTOPLEFT.X) / MainWindowMetaData.CHESSBOARDTILESIZE;
            var tileYIndex = (y - (int)MainWindowMetaData.CHESSBOARDTOPLEFT.Y) / MainWindowMetaData.CHESSBOARDTILESIZE;

            return m_gameState.GetBoard().GetTileAtPos(tileXIndex, tileYIndex);
        }

        public bool IsMouseClickInChessField(int x, int y)
        {
            var topLeft = MainWindowMetaData.CHESSBOARDTOPLEFT;
            var bottomRight = MainWindowMetaData.CHESSBOARDBOTTOMRIGHT;

            if (x <= bottomRight.X && x >= topLeft.X && y <= bottomRight.Y && y >= topLeft.Y)
            {
                return true;
            }

            return false;
        }
    }
}
