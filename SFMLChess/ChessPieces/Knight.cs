using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Knight : ChessPiece
    {

        public Knight(ChessColor color)
            : base(color)
        {
            m_chessPieceType = ChessPieceType.Knight;
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var validMovePositions = new List<BoardPosition>();
            var selectedChessPieceColor = tile.GetChessPiece().GetColor();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            //Up left
            if (x - 1 >= 0 && y - 2 >= 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 1, y - 2);
                
                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y - 2, true));
                }
                else if(chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y - 2));
                }
            }

            //Up right
            if (x + 1 < 8 && y - 2 >= 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 1, y - 2);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y - 2, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y - 2));
                }
            }

            //Left up
            if (x - 2 >= 0 && y - 1 >= 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 2, y - 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 2, y - 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 2, y - 1));
                }
            }

            //Left down
            if (x - 2 >= 0 && y + 1 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 2, y + 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 2, y + 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 2, y + 1));
                }
            }

            //Down left
            if (x - 1 >= 0 && y + 2 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x - 1, y + 2);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y + 2, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x - 1, y + 2));
                }
            }

            //Down right
            if (x + 1 < 8 && y + 2 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 1, y + 2);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y + 2, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 1, y + 2));
                }
            }

            //Right up
            if (x + 2 < 8 && y - 1 >= 0)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 2, y - 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 2, y - 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 2, y - 1));
                }
            }

            //Right down
            if (x + 2 < 8 && y + 1 < 8)
            {
                var chessPiece = board.GetChessPieceForSpecificTile(x + 2, y + 1);

                if (chessPiece != null && !chessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    validMovePositions.Add(new BoardPosition(x + 2, y + 1, true));
                }
                else if (chessPiece == null)
                {
                    validMovePositions.Add(new BoardPosition(x + 2, y + 1));
                }
            }

            return new Moveset(validMovePositions);
        }
    }
}
