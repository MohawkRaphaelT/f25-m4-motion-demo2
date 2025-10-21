// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        Vector2 position;
        Vector2 velocity;
        float radius = 35;
        Color color = Color.Red;

        public void Setup()
        {
            Window.SetTitle("Motion with Vectors");
            Window.SetSize(400, 800);

            // Set up variables once game is ready
            position = new(Window.Width / 2, 100);
            
            // 
            Draw.LineSize = 1;
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Run game logic
            ApplyGravity();
            ConstrainBallToScreen();

            // Draw ball
            Draw.FillColor = color;

            float angle = Time.SecondsElapsed * MathF.Tau / 1;
            float w = MathF.Cos(angle) * radius * 2;
            float h = MathF.Sin(angle) * radius * 2;
            Draw.Ellipse(position.X, position.Y, w, h);
        }

        void ApplyGravity()
        {
            // Apply gravity to velocity
            velocity += new Vector2(0, 10) * Time.DeltaTime;
            // Apply velocity to position
            position += velocity;
        }

        void ConstrainBallToScreen()
        {
            // Is bottom of ball at or past edge of screen
            if (position.Y + radius >= Window.Height)
            {
                // Inverse Y velocity, move upwards
                velocity.Y = -velocity.Y;
                // Slow down velocity
                velocity *= 0.8f; // retain 80% of velocity
                // Place ball against bottom edge of screen
                position.Y = Window.Height - radius;
            }
        }

    }

}
