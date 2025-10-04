using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DataStructures.Graphs.Pathfinding;
using DataStructures.Graphs;
using MonoGame.Extended;
using System.Linq;

namespace Astar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        Node<Rectangle> start;
        Node<Rectangle> end;
        Grid grid;
        protected override void Initialize()
        {
            grid = new Grid(new Rectangle(0, 0, 800, 480), new Point(4, 4));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (var vertex in from vertex in grid.Graph.Vertices
                                       where vertex.Value.Value.Contains(mouseState.Position)
                                       select vertex)
                {
                    start = vertex.Value;
                }
            }
            else if(mouseState.RightButton == ButtonState.Pressed)
            {
                foreach (var vertex in from vertex in grid.Graph.Vertices
                                       where vertex.Value.Value.Contains(mouseState.Position)
                                       select vertex)
                {
                    end = vertex.Value;
                }
            }
            KeyboardState keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.Space) && start != null && end != null)
            {
                grid.AStarPathFind(start, end);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();


            grid.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
