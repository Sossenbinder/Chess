using System;
using System.IO;
using System.Reflection;
using SFML.Graphics;

namespace SFMLChess.ChessPieces
{
    public class ChessPiece
    {
        protected string m_chessPieceName;
        protected readonly ChessColor m_color;
        protected readonly string m_resourceLocation = "SFMLChess.Graphics.ChessPieces.";

        public ChessPiece(ChessColor color)
        {
            m_color = color;
        }

        public Texture LoadTexture()
        {
            string resourcePath = m_resourceLocation + m_chessPieceName + (m_color == ChessColor.Black ? "Black" : "White") + ".png";

            var textureStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);

            return new Texture(textureStream);
        }
    }
}
