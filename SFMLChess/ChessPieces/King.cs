using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class King : ChessPiece
    {
        public King(ChessColor color)
            : base(color)
        {
            m_chessPieceType = ChessPieceType.King;
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var validMovePositions = new List<BoardPosition>();
            var selectedChessPieceColor = tile.GetChessPiece().GetColor();

            var x = boardPosition.X;
            var y = boardPosition.Y;
            
            //Left up
            if(x - 1 > 0 && y - 1 > 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 1, y - 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y - 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y - 1));
                }
            }

            //Left
            if (x - 1 > 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 1, y);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y));
                }
            }

            //Left down
            if (x - 1 > 0 && y + 1 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 1, y + 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y + 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y + 1));
                }
            }

            //Down
            if (y + 1 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x, y + 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x, y + 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x, y + 1));
                }
            }

            //Right down
            if (x + 1 < 8 && y + 1 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 1, y + 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y + 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y + 1));
                }
            }

            //Right
            if (x + 1 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 1, y);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y));
                }
            }

            //Right up
            if (x + 1 < 8 && y - 1 > 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 1, y - 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y - 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y - 1));
                }
            }

            //Up
            if (y - 1 > 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x, y - 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x, y - 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x, y - 1));
                }
            }

            return new Moveset(validMovePositions);
        }
    }
}
