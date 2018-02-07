using SFMLChess.ChessPieces;

namespace SFMLChess.Logic.BoardLogic
{
    public class Tile
    {
        private readonly ChessColor m_color;

        private ChessPiece m_chessPiece;

        public Tile(ChessColor color)
        {
            m_color = color;
            m_chessPiece = null;
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

    }
}
