using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(ChessColor color) 
            : base(color)
        {
            m_chessPieceName = "Rook";
            LoadTexture();
        }

        public override Moveset GetMoveSetFromTile(Tile tile, Board board)
        {
            var boardPosition = tile.GetBoardPosition();
            var selectedChessPieceColor = tile.GetChessPiece().GetColor();
            var possiblePositions = new List<BoardPosition>();

            var x = boardPosition.X;
            var y = boardPosition.Y;

            while (x > 0)
            {
                --x;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        possiblePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (y > 0)
            {
                --y;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        possiblePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (x < 7)
            {
                ++x;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        possiblePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                possiblePositions.Add(new BoardPosition(x, y));
            }

            x = boardPosition.X;
            y = boardPosition.Y;

            while (y < 7)
            {
                ++y;

                var chessPiece = board.GetChessPieceForSpecificTile(x, y);

                if (chessPiece != null)
                {
                    if (!chessPiece.GetColor().Equals(selectedChessPieceColor))
                    {
                        possiblePositions.Add(new BoardPosition(x, y, true));
                    }
                    break;
                }

                possiblePositions.Add(new BoardPosition(x, y));
            }

            return new Moveset(possiblePositions);
        }
    }
}
