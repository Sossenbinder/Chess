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
            m_chessPieceType = ChessPieceType.Pawn;
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var validMovePositions = new List<BoardPosition>();
            var selectedChessPieceColor = tile.GetChessPiece().GetColor();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            if (m_color == ChessColor.Black)
            {
                if (y + 1 < 8)
                {
                    var chessPiece = board.GetChessPieceForSpecificTile(x, y + 1);

                    if (chessPiece == null)
                    {
                        validMovePositions.Add(new BoardPosition(x, y + 1));
                    }
                }

                if(!m_didMove && y + 2 < 8)
                {
                    var chessPiece = board.GetChessPieceForSpecificTile(x, y + 2);

                    if (chessPiece == null)
                    {
                        validMovePositions.Add(new BoardPosition(x, y + 2));
                    }
                }
            }
            else
            {
                if (y - 1 > 0)
                {
                    var chessPiece = board.GetChessPieceForSpecificTile(x, y - 1);

                    if (chessPiece == null)
                    {
                        validMovePositions.Add(new BoardPosition(x, y - 1));
                    }
                }

                if (!m_didMove && y - 2 > 0)
                {
                    var chessPiece = board.GetChessPieceForSpecificTile(x, y - 2);

                    if (chessPiece == null)
                    {
                        validMovePositions.Add(new BoardPosition(x, y - 2));
                    }
                }
            }

            var specialMove = CheckForBeatablePieces(boardPosition, selectedChessPieceColor, board, validMovePositions);

            return new Moveset(validMovePositions, specialMove);
        }

        private SpecialMove CheckForBeatablePieces(BoardPosition selectedBoardPosition, ChessColor selectedChessPieceColor, Board board, List<BoardPosition> possiblePositions)
        {
            var specialMove = SpecialMove.None;

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

            //En passant
            leftChessPiece = board.GetChessPieceForSpecificTile(x - 1, selectedBoardPosition.Y);
            rightChessPiece = board.GetChessPieceForSpecificTile(x + 1, selectedBoardPosition.Y);

            if (leftChessPiece != null && !leftChessPiece.GetColor().Equals(selectedChessPieceColor) && leftChessPiece.GetChessPieceType().Equals(ChessPieceType.Pawn))
            {
                var history = leftChessPiece.GetHistory().GetMoveList();

                if(history == null || history.Count == 0)
                {
                    return specialMove;
                }

                var oldPos = history[0].GetPreviousPosition();
                var newPos = history[0].GetNewPosition();

                if (history.Count == 1 && newPos.Y == oldPos.Y + (m_color == ChessColor.White ? 2 : -2))
                {
                    possiblePositions.Add(new BoardPosition(x - 1, y, true));
                    specialMove = SpecialMove.EnPassant;
                }
            }

            if (rightChessPiece != null && !rightChessPiece.GetColor().Equals(selectedChessPieceColor))
            {
                var history = rightChessPiece.GetHistory().GetMoveList();

                if (history == null || history.Count == 0)
                {
                    return specialMove;
                }

                var oldPos = history[0].GetPreviousPosition();
                var newPos = history[0].GetNewPosition();

                if (history.Count == 1 && newPos.Y == oldPos.Y + (m_color == ChessColor.White ? 2 : -2))
                {
                    possiblePositions.Add(new BoardPosition(x + 1, y, true));
                    specialMove = SpecialMove.EnPassant;
                }
            }

            return specialMove;
        }
    }
}
