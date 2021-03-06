﻿using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFMLChess.Logic;
using SFMLChess.Logic.BoardLogic;
using SFMLChess.MainWindow;
using System.Collections.Generic;

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
                    DrawValidMovePositions(gameState.GetBoard().GetValidMovePositions());
                }

                DrawGameFieldChessPieces();
            }

            DrawGameFieldBorder();
        }

        private void DrawGameFieldBorder()
        {
            var topLeftPoint = MainWindowMetaData.CHESSBOARDTOPLEFT;
            var bottomRightPoint = MainWindowMetaData.CHESSBOARDBOTTOMRIGHT;

            DrawBorder(topLeftPoint, bottomRightPoint, MainWindowMetaData.CHESSBOARDLINECOLOR);
        }

        private void DrawGameFieldTiles()
        {
            var rectSize = new Vector2f(MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTILESIZE);

            for (var x = 0; x < 8; ++x)
            {
                for (var y = 0; y < 8; ++y)
                {
                    var position = new Vector2f(MainWindowMetaData.CHESSBOARDTOPLEFT.X + x * MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTOPLEFT.Y + y * MainWindowMetaData.CHESSBOARDTILESIZE);

                    var rect = new RectangleShape(rectSize)
                    {
                        Position = position,
                        FillColor = ResolveChessColor(m_mainWindowModel.GetBoardColorForTile(x, y))
                    };

                    m_window.Draw(rect);
                }
            }
        }

        private void DrawGameFieldChessPieces()
        {
            var topLeft = MainWindowMetaData.CHESSBOARDTOPLEFT;

            for (var x = 0; x < 8; ++x)
            {
                for (var y = 0; y < 8; ++y)
                {
                    var chessPieceSprite = new Sprite
                    {
                        Texture = m_mainWindowModel.GetTextureForTile(x, y),
                        Position = new Vector2f(topLeft.X + x * MainWindowMetaData.CHESSBOARDTILESIZE, topLeft.Y + y * MainWindowMetaData.CHESSBOARDTILESIZE)
                    };

                    m_window.Draw(chessPieceSprite);
                }
            }
        }

        private void DrawSelectedTile(Tile tile)
        {
            var rectSize = new Vector2f(MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTILESIZE);

            var selectedPosition = new Vector2f(MainWindowMetaData.CHESSBOARDTOPLEFT.X + tile.GetBoardPosition().X * MainWindowMetaData.CHESSBOARDTILESIZE,
                MainWindowMetaData.CHESSBOARDTOPLEFT.Y + tile.GetBoardPosition().Y * MainWindowMetaData.CHESSBOARDTILESIZE);

            var selectedRect = new RectangleShape(rectSize)
            {
                Position = selectedPosition,
                FillColor = ResolveChessColor(tile.GetChessColor())
            };

            DrawBorder(new Vector2f(selectedPosition.X, selectedPosition.Y - 1),
                new Vector2f(selectedPosition.X + rectSize.X + 1, selectedPosition.Y + rectSize.Y),
                MainWindowMetaData.CHESSBOARDLINECOLOR);

            m_window.Draw(selectedRect);
        }

        private void DrawValidMovePositions(List<BoardPosition> validMovePositions)
        {
            var rectSize = new Vector2f(MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTILESIZE);

            foreach(BoardPosition pos in validMovePositions)
            {
                var position = new Vector2f(MainWindowMetaData.CHESSBOARDTOPLEFT.X + pos.X * MainWindowMetaData.CHESSBOARDTILESIZE, MainWindowMetaData.CHESSBOARDTOPLEFT.Y + pos.Y * MainWindowMetaData.CHESSBOARDTILESIZE);

                var rect = new RectangleShape(rectSize)
                {
                    Position = position,
                    FillColor = ResolveChessColor(pos.Beatable ? ChessColor.Beatable : ChessColor.ValidMove)
                };

                m_window.Draw(rect);
            }
        }

        //HELPER FUNCTIONS

        private void DrawBorder(Vector2f topLeft, Vector2f bottomRight, Color borderColor)
        {
            var topLeftPoint = new Vector2f(topLeft.X, topLeft.Y);
            var topRightPoint = new Vector2f(bottomRight.X, topLeft.Y);
            var bottomLeftPoint = new Vector2f(topLeftPoint.X, bottomRight.Y);
            var bottomRightPoint = new Vector2f(bottomRight.X, bottomRight.Y);

            //leftBorder
            Vertex[] border = {
                new Vertex(topLeftPoint, borderColor),
                new Vertex(bottomLeftPoint, borderColor)
            };
            m_window.Draw(border, PrimitiveType.Lines);

            //topBorder
            border[1] = new Vertex(topRightPoint, borderColor);
            m_window.Draw(border, PrimitiveType.Lines);

            //rightBorder
            border[0] = new Vertex(bottomRightPoint, borderColor);
            m_window.Draw(border, PrimitiveType.Lines);

            //bottomBorder
            border[1] = new Vertex(bottomLeftPoint, borderColor);
            m_window.Draw(border, PrimitiveType.Lines);
        }

        private Color ResolveChessColor(ChessColor gameColor)
        {
            switch (gameColor)
            {
                case ChessColor.Black:
                    return MainWindowMetaData.CHESSBOARDTILECOLOR;
                case ChessColor.White:
                    return Color.White;
                case ChessColor.Selected:
                    return new Color(172, 143, 0);
                case ChessColor.ValidMove:
                    return Color.Cyan;
                case ChessColor.Beatable:
                    return Color.Red;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameColor), gameColor, null);
            }
        }
    }
}
