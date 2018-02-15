using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(ChessColor color)
            : base(color)
        {
            m_chessPieceName = "Pawn";
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var possiblePositions = new List<BoardPosition>();
            var selectedChessPieceColor = tile.GetChessPiece().GetColor();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            if (m_color == ChessColor.Black)
            {
                if(y + 1 < 8)
                {
                    possiblePositions.Add(new BoardPosition(x, y + 1));
                }

                if(!m_didMove && y + 2 < 8)
                {
                    possiblePositions.Add(new BoardPosition(x, y + 2));
                }
            }
            else
            {
                if (y - 1 > 0)
                {
                    possiblePositions.Add(new BoardPosition(x, y - 1));
                }

                if (!m_didMove && y - 2 > 0)
                {
                    possiblePositions.Add(new BoardPosition(x, y - 2));
                }
            }

            CheckForBeatablePieces(boardPosition, selectedChessPieceColor, board, possiblePositions);

            return new Moveset(possiblePositions);
        }

        private void CheckForBeatablePieces(BoardPosition selectedBoardPosition, ChessColor selectedChessPieceColor, Board board, List<BoardPosition> possiblePositions)
        {
            var x = selectedBoardPosition.X;
            var y = selectedBoardPosition.Y - (m_color == ChessColor.White ? 1 : - 1);

            var leftChessPiece = board.GetChessPieceForSpecificTile(x - 1, y);
            var rightChessPiece = board.GetChessPieceForSpecificTile(x + 1, y);

            if (leftChessPiece != null && !leftChessPiece.GetColor().Equals(selectedChessPieceColor))
            {
                possiblePositions.Add(new BoardPosition(x - 1, y, true));
            }

            if (rightChessPiece != null && !rightChessPiece.GetColor().Equals(selectedChessPieceColor))
            {
                possiblePositions.Add(new BoardPosition(x + 1, y, true));
            }
        }
    }
}
