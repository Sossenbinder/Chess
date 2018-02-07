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
            DrawGameFieldTiles();

            if (gameState.IsInitialized())
            {
                var tile = gameState.GetBoard().GetSelectedTile();
                if (tile != null)
                {
                    DrawSelectedTile(tile);
                }

                DrawGameFieldChessPieces();
            }

            DrawGameFieldBorder();
        }

        private void DrawGameFieldBorder()
        {
            var topLeftPoint = MainWindowMetaData.CHESSBOARDTOPLEFT;
            var topRightPoint = new Vector2f(topLeftPoint.X + MainWindowMetaData.CHESSBOARDBORDERLENGTH, topLeftPoint.Y);
            var bottomLeftPoint = new Vector2f(topLeftPoint.X, topLeftPoint.Y + MainWindowMetaData.CHESSBOARDBORDERLENGTH);
            var bottomRightPoint = MainWindowMetaData.CHESSBOARDBOTTOMRIGHT;

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

        private void DrawGameFieldTiles()
        {
            var rectSize = new Vector2f(MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTILESIZE);

            for (var i = 0; i < 8; ++i)
            {
                for (var j = 0; j < 8; ++j)
                {
                    var position = new Vector2f(MainWindowMetaData.CHESSBOARDTOPLEFT.X + j * MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTOPLEFT.Y + i * MainWindowMetaData.CHESSBOARDTILESIZE);

                    var rect = new RectangleShape(rectSize)
                    {
                        Position = position,
                        FillColor = (m_mainWindowModel.GetBoardColorForTile(i, j) == ChessColor.Black)
                            ? MainWindowMetaData.CHESSBOARDTILECOLOR
                            : Color.White
                    };


                    m_window.Draw(rect);
                }
            }

        }

        private void DrawGameFieldChessPieces()
        {
            var topLeft = MainWindowMetaData.CHESSBOARDTOPLEFT;

            for (var i = 0; i < 8; ++i)
            {
                for (var j = 0; j < 8; ++j)
                {
                    var chessPieceSprite = new Sprite
                    {
                        Texture = m_mainWindowModel.GetTextureForTile(i, j),
                        Position = new Vector2f(topLeft.X + j * MainWindowMetaData.CHESSBOARDTILESIZE, topLeft.Y + i * MainWindowMetaData.CHESSBOARDTILESIZE)
                    };

                    m_window.Draw(chessPieceSprite);
                }
            }
        }

        private void DrawSelectedTile(Tile tile)
        {
            var rectSize = new Vector2f(MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTILESIZE);

            var position = new Vector2f(MainWindowMetaData.CHESSBOARDTOPLEFT.X + tile.GetBoardPosition().X * MainWindowMetaData.CHESSBOARDTILESIZE,
                MainWindowMetaData.CHESSBOARDTOPLEFT.Y + tile.GetBoardPosition().Y * MainWindowMetaData.CHESSBOARDTILESIZE);

            var rect = new RectangleShape(rectSize)
            {
                Position = position,
                FillColor = Color.Yellow
            };

            m_window.Draw(rect);
        }
    }
}
