using SFMLChess.ChessPieces;

namespace SFMLChess.Logic.BoardLogic
{
    public class Tile
    {
        private readonly ChessColor m_color;

        private readonly BoardPosition m_boardPosition;

        private ChessPiece m_chessPiece;

        private bool m_selected;

        private bool m_moveable;

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
            if (m_selected)
            {
                return ChessColor.Selected;
            }

            if (m_moveable)
            {
                return ChessColor.Possible;
            }

            return m_color;
        }

        public ChessPiece GetChessPiece()
        {
            return m_chessPiece;
        }

        public Moveset GetChessPieceMoveSet(Board board)
        {
            return m_chessPiece.GetMoveSetFromTile(this);
        }

        public BoardPosition GetBoardPosition()
        {
            return m_boardPosition;
        }

        public void SetSelectionState(bool selected)
        {
            m_selected = selected;
        }

        public void SetMoveableState(bool moveable)
        {
            m_moveable = moveable;
        }
    }
}
