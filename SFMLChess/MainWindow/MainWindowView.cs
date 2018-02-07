using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFMLChess.Logic;
using SFMLChess.Logic.BoardLogic;
using SFMLChess.MainWindow;

namespace SFMLChess.MainWindow
{
    public class MainWindowView
    {
        private const float TILESIZE = 60;

        private readonly MainWindowModel m_mainWindowModel;
        private readonly MainWindowController m_mainWindowController;

        private RenderWindow m_window;

        public MainWindowView(MainWindowModel mainWindowModel, MainWindowController mainWindowController)
        {
            m_mainWindowController = mainWindowController;
            m_mainWindowModel = mainWindowModel;
        }

        public RenderWindow InitializeWindow()
        {
            m_window = new RenderWindow(new VideoMode(MainWindowMetaData.WIDTH, MainWindowMetaData.HEIGHT), MainWindowMetaData.TITLE);
            m_window.SetFramerateLimit(MainWindowMetaData.FRAMERATE_LIMIT);

            return m_window;
        }

        public void DrawWindow(GameState gameState)
        {
            m_window.Clear(MainWindowMetaData.BACKGROUNDCOLOR);

            DrawGameField(gameState);

            m_window.Display();
        }

        private void DrawGameField(GameState gameState)
        {

            DrawGameFieldTiles(gameState);
            DrawGameFieldBorder();

            if (gameState.IsInitialized())
            {
                DrawGameFieldChessPieces(gameState);
            }
        }

        private void DrawGameFieldBorder()
        {
            // + 4 for Border size etc.
            const float lineLength = 8 * TILESIZE + 4;
            var topLeft = MainWindowMetaData.CHESSBOARDTOPLEFT;

            var topLeftPoint = new Vector2f(topLeft.X, topLeft.Y);
            var topRightPoint = new Vector2f(topLeft.X + lineLength, topLeft.Y);
            var bottomLeftPoint = new Vector2f(topLeft.X, topLeft.Y + lineLength);
            var bottomRightPoint = new Vector2f(topLeft.X + lineLength, topLeft.Y + lineLength);

            //leftBorder
            Vertex[] border = new Vertex[2] {
                new Vertex(topLeftPoint, MainWindowMetaData.CHESSBOARDLINECOLOR),
                new Vertex(bottomLeftPoint, MainWindowMetaData.CHESSBOARDLINECOLOR)
            };
            m_window.Draw(border, PrimitiveType.Lines);

            //topBorder
            border[1] = new Vertex(topRightPoint, MainWindowMetaData.CHESSBOARDLINECOLOR);
            m_window.Draw(border, PrimitiveType.Lines);

            //rightBorder
            border[0] = new Vertex(bottomRightPoint, MainWindowMetaData.CHESSBOARDLINECOLOR);
            m_window.Draw(border, PrimitiveType.Lines);

            //bottomBorder
            border[1] = new Vertex(bottomLeftPoint, MainWindowMetaData.CHESSBOARDLINECOLOR);
            m_window.Draw(border, PrimitiveType.Lines);
        }

        private void DrawGameFieldTiles(GameState gameState)
        {
            var board = gameState.GetBoard();

            var topLeft = MainWindowMetaData.CHESSBOARDTOPLEFT;
            topLeft.Y++;

            var rectSize = new Vector2f(64, 64);

            for (var i = 0; i < 8; ++i)
            {
                for (var j = 0; j < 8; ++j)
                {
                    var position = new Vector2f(topLeft.X + j * TILESIZE, topLeft.Y + i * TILESIZE);

                    var rect = new RectangleShape(rectSize)
                    {
                        Position = position,
                        FillColor = (board.GetBoardColorForSpecificTile(i, j) == ChessColor.Black)
                            ? MainWindowMetaData.CHESSBOARDTILECOLOR
                            : Color.White
                    };


                    m_window.Draw(rect);
                }
            }

        }

        private void DrawGameFieldChessPieces(GameState gameState)
        {
            Board board = gameState.GetBoard();

            var topLeft = MainWindowMetaData.CHESSBOARDTOPLEFT;

            for (var i = 0; i < 8; ++i)
            {
                for (var j = 0; j < 8; ++j)
                {
                    var chessPieceSprite = new Sprite
                    {
                        Texture = board.GetChessPieceForSpecificTile(i, j)?.LoadTexture(),
                        Position = new Vector2f(topLeft.X + j * TILESIZE, topLeft.Y + i * TILESIZE)
                    };

                    m_window.Draw(chessPieceSprite);
                }
            }
        }
    }
}
