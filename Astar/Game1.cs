using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DataStructures.Graphs.Pathfinding;
using DataStructures.Graphs;
using MonoGame.Extended;
using System.Linq;
using System;

namespace Astar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        bool thingy = false;
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
            grid = new Grid(new Rectangle(0, 0, 800, 480), new Point(16, 9));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        TimeSpan elapsedTime = TimeSpan.Zero;
        TimeSpan interval = TimeSpan.FromSeconds(0.5);
        int thing = 0;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime >= interval)
            { 
                elapsedTime = TimeSpan.Zero;
                thing = 1;
            }

            if (!keyboardState.IsKeyDown(Keys.LeftControl))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    foreach (var vertex in from vertex in grid.Graph.Vertices
                                           where vertex.Value.Value.Contains(mouseState.Position)
                                           select vertex)
                    {
                        start = vertex.Value;
                    }
                }
                else if (mouseState.RightButton == ButtonState.Pressed)
                {
                    foreach (var vertex in from vertex in grid.Graph.Vertices
                                           where vertex.Value.Value.Contains(mouseState.Position)
                                           select vertex)
                    {
                        end = vertex.Value;
                    }
                }
            }
            else
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    foreach (var vertex in from vertex in grid.Graph.Vertices
                                           where vertex.Value.Value.Contains(mouseState.Position)
                                           select vertex)
                    {
                        grid.AddObstacle(vertex.Value);
                    }
                }
                else if (mouseState.RightButton == ButtonState.Pressed)
                {
                    foreach (var vertex in from vertex in grid.Graph.Vertices
                                           where vertex.Value.Value.Contains(mouseState.Position)
                                           select vertex)
                    {
                        grid.RemoveObstacle(vertex.Value);
                    }
                }
            }
            if (keyboardState.IsKeyDown(Keys.Space) && start != null && end != null)
            {
                thingy = true;
            }
            if (keyboardState.IsKeyUp(Keys.Space))
            {
                if(thingy && start != null && end != null)
                {
                    grid.AStarPathFind(start, end);
                }
                thingy = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            if(start != null)
                spriteBatch.FillRectangle(start.Value, Color.Beige * 0.5f);
            if(end != null)
                spriteBatch.FillRectangle(end.Value, Color.Beige * 0.5f);
            grid.Draw(spriteBatch, thing);
            thing = 0;
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
