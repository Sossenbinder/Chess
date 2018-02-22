using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(ChessColor color)
            : base(color)
        {
            m_chessPieceType = ChessPieceType.Bishop;
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var validMovePositions = new List<BoardPosition>();
            var selectedChessPieceColor = tile.GetChessPiece().GetColor();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            while (x > 0 && y > 0)
            {
                --x;
                --y;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        validMovePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                validMovePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x > 0 && y < 7)
            {
                --x;
                ++y;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        validMovePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                validMovePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x < 7 && y < 7)
            {
                ++x;
                ++y;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        validMovePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                validMovePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x < 7 && y > 0)
            {
                ++x;
                --y;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        validMovePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                validMovePositions.Add(new BoardPosition(x, y));
            }

            return new Moveset(validMovePositions);
        }
    }
}
