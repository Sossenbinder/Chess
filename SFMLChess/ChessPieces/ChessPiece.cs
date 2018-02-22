using System;
using System.IO;
using System.Reflection;
using SFML.Graphics;
using SFMLChess.Logic.BoardLogic;
using SFMLChess.Logic.PlayerLogic;

namespace SFMLChess.ChessPieces
{
    public abstract class ChessPiece
    {
        protected ChessPieceType m_chessPieceType;

        protected readonly ChessColor m_color;

        protected readonly string m_resourceLocation = "SFMLChess.Graphics.ChessPieces.";

        protected Texture m_texture;

        protected bool m_didMove;

        protected History m_history;

        protected ChessPiece(ChessColor color)
        {
            m_color = color;
            m_history = new History();
        }

        protected void LoadTexture()
        {
            string resourcePath = m_resourceLocation + GetChessPieceNameFromType() + (m_color == ChessColor.Black ? "Black" : "White") + ".png";

            var textureStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);

            m_texture = new Texture(textureStream);
        }

        protected bool CheckIfBeatable(ChessPiece targetChessPiece, ChessColor selectedChessPieceColor)
        {
            if (targetChessPiece != null)
            {
                if (!targetChessPiece.GetColor().Equals(selectedChessPieceColor))
                {
                    return true;
                }                
            }
            return false;
        }

        protected string GetChessPieceNameFromType()
        {
            string chessPieceName = "";

            switch(m_chessPieceType)
            {
                case ChessPieceType.Bishop:
                    chessPieceName = "Bishop";
                    break;
                case ChessPieceType.King:
                    chessPieceName = "King";
                    break;
                case ChessPieceType.Queen:
                    chessPieceName = "Queen";
                    break;
                case ChessPieceType.Rook:
                    chessPieceName = "Rook";
                    break;
                case ChessPieceType.Knight:
                    chessPieceName = "Knight";
                    break;
                case ChessPieceType.Pawn:
                    chessPieceName = "Pawn";
                    break;
            }

            return chessPieceName;
        }

        public abstract Moveset GetMoveSetFromTile(Tile tile, Board board);

        public SpecialMove Move(Move move)
        {
            m_didMove = true;

            m_history.AddMove(move);

            return SpecialMove.None;
        }

        public Texture GetTexture()
        {
            return m_texture;
        }

        public ChessColor GetColor()
        {
            return m_color;
        }

        public bool DidMove()
        {
            return m_didMove;
        }

        public ChessPieceType GetChessPieceType()
        {
            return m_chessPieceType;
        }

        public History GetHistory()
        {
            return m_history;
        }
    }
}
