using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.MainWindow;
using SFML.Graphics;
using SFML.Window;
using SFMLChess.Logic.BoardLogic;

namespace SFMLChess.MainWindow
{
    public class MainWindowController
    {
        private readonly MainWindowView m_mainWindowView;
        private readonly MainWindowModel m_mainWindowModel;

        private readonly RenderWindow m_mainWindow;

        public MainWindowController()
        {
            m_mainWindowModel = new MainWindowModel();
            m_mainWindowView = new MainWindowView(m_mainWindowModel, this);
            m_mainWindow = m_mainWindowView.InitializeWindow();

            Initialize();
        }

        private void Initialize()
        {
            SetEventHandlers();
        }

        public void RunMainWindow()
        {
            while (m_mainWindow.IsOpen)
            {
                m_mainWindow.DispatchEvents();
                m_mainWindowView.DrawWindow(m_mainWindowModel.GetGameState());
            }
        }

        private void SetEventHandlers()
        {
            m_mainWindow.Closed += HandleWindowClose;
            m_mainWindow.MouseButtonPressed += MouseButtonPressed;
            m_mainWindow.MouseButtonReleased += HandleMouseRelease;
        }

        private void HandleWindowClose(object sender, EventArgs e)
        {
            m_mainWindow.Close();
        }

        private void MouseButtonPressed(object sender, EventArgs e)
        {
            var mouseEventArgs = (MouseButtonEventArgs)e;

            if (mouseEventArgs.Button == Mouse.Button.Left)
            {

            }
        }

        private void HandleMouseRelease(object sender, EventArgs e)
        {
            var mouseEventArgs = (MouseButtonEventArgs)e;

            if (mouseEventArgs.Button == Mouse.Button.Left)
            {
                if (m_mainWindowModel.IsMouseClickInChessField(mouseEventArgs.X, mouseEventArgs.Y))
                {
                    var tile = m_mainWindowModel.GetTileForMousePos(mouseEventArgs.X, mouseEventArgs.Y);
                    m_mainWindowModel.GetGameState().GetBoard().HandleSelectTile(tile);
                }
            }
        }
    }
}
