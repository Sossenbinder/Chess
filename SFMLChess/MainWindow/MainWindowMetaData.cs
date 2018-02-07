using SFML.Graphics;
using SFML.System;

namespace SFMLChess.MainWindow
{
    public static class MainWindowMetaData
    {
        public static readonly uint HEIGHT = 800;
        public static readonly uint WIDTH = 1024;

        public static readonly string TITLE = "Chess";

        public static readonly uint FRAMERATE_LIMIT = 60;

        public static readonly Color BACKGROUNDCOLOR = Color.White;

        public static readonly Color CHESSBOARDLINECOLOR = Color.Black;

        public static readonly Color CHESSBOARDTILECOLOR = new Color(128, 128, 128);

        public static readonly Vector2f CHESSBOARDTOPLEFT = new Vector2f(20, 20);
    }
}