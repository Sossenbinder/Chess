using System;
using System.IO;
using System.Reflection;
using SFML.Graphics;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.ChessPieces
{
    public abstract class ChessPiece
    {
        protected string m_chessPieceName;

        protected readonly ChessColor m_color;

        protected readonly string m_resourceLocation = "SFMLChess.Graphics.ChessPieces.";

        protected Texture m_texture;

        protected bool m_didMove;

        protected ChessPiece(ChessColor color)
        {
            m_color = color;
        }

        protected void LoadTexture()
        {
            string resourcePath = m_resourceLocation + m_chessPieceName + (m_color == ChessColor.Black ? "Black" : "White") + ".png";

            var textureStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);

            m_texture = new Texture(textureStream);
        }

        public abstract Moveset GetMoveSetFromTile(Tile tile);

        public Texture GetTexture()
        {
            return m_texture;
        }
    }
}
