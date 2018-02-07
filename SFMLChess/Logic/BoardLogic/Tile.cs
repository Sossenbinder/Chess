using SFMLChess.ChessPieces;

namespace SFMLChess.Logic.BoardLogic
{
    public class Tile
    {
        private readonly ChessColor m_color;

        private readonly BoardPosition m_boardPosition;

        private ChessPiece m_chessPiece;

        public Tile(ChessColor color, int x, int y)
        {
            m_color = color;
            m_chessPiece = null;

            m_boardPosition = new BoardPosition(y, x);
        }

        public void SetChessPiece(ChessPiece chessPiece)
        {
            m_chessPiece = chessPiece;
        }

        public ChessColor GetChessColor()
        {
            return m_color;
        }

        public ChessPiece GetChessPiece()
        {
            return m_chessPiece;
        }

        public BoardPosition GetBoardPosition()
        {
            return m_boardPosition;
        }

    }
}
