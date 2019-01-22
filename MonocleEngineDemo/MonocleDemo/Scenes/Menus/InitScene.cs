using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monocle;
using MonocleDemoNamespace.GameEntities.Abstract;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonocleDemoNamespace.Scenes.Menus
{
    public class InitScene: Scene
    {
        Camera camera; // Camera handler (so that we can modify it's paramteres when needed, like zoom)
        Dummy dum; // Dummy
        int dummyMove = 4; // Dummy movement speed

        public InitScene() : base()
        {}

        public override void Begin()
        {
            base.Begin();

            // Add the EverythingRenderer object so it will actually display the contents of the scene
            EverythingRenderer er = new EverythingRenderer();
            Add(er);

            // Setup the camera
            camera = new Camera(640, 360);
            camera.CenterOrigin();
            camera.Zoom = 1.5f;
            er.Camera = camera; // Attach the new camera to the EverythingRenderer

            // Create the dummy
            dum = new Dummy();
            Vector2 screenHalf = (new Vector2(Engine.Width, Engine.Height))/2;
            dum.Position = screenHalf;
            Add(dum);

            // Create walls (mainly to limit the movement of the dummy and to test collisions)
            CreateWallBorder();
            AdditionalWalls();
        }

        private void CreateWallBorder()
        {
            for (int i = 16; i < Engine.Width; i += 32)
            {
                SolidWall sw = new SolidWall(new Vector2(i, 0));
                Add(sw);
                sw = new SolidWall(new Vector2(i, Engine.Height - 16));
                Add(sw);
            }

            for (int i = 0; i < Engine.Height; i += 32)
            {
                SolidWall sw = new SolidWall(new Vector2(-16, i));
                Add(sw);
                sw = new SolidWall(new Vector2(Engine.Width - 16, i));
                Add(sw);
            }


        }

        private void AdditionalWalls()
        {
            // Above and bellow the player
            for (int i = 0; i < 3; i++)
            {
                Vector2 pos = new Vector2(dum.X, dum.Y - 32 * (i + 2));
                Vector2 pos2 = new Vector2(dum.X, dum.Y + 32 * (i + 2));
                SolidWall sw = new SolidWall(pos);
                SolidWall sw2 = new SolidWall(pos2);
                Add(sw);
                Add(sw2);
            }

            // Left and right to the player
            for (int i = 0; i < 5; i++)
            {
                Vector2 pos = new Vector2(dum.X - 32 * (i + 3), dum.Y);
                Vector2 pos2 = new Vector2(dum.X + 32 * (i + 3), dum.Y);
                SolidWall sw = new SolidWall(pos);
                SolidWall sw2 = new SolidWall(pos2);
                Add(sw);
                Add(sw2);
            }

        }

        public override void Update()
        {
            base.Update();
            
            int nx = dummyMove * MInput.Keyboard.AxisCheck(Keys.Left, Keys.Right);
            int ny = dummyMove * MInput.Keyboard.AxisCheck(Keys.Up, Keys.Down);

            dum.Move( new Vector2(nx, ny));

            // This is a direct transition to test scene
            if (MInput.Keyboard.Check(Keys.LeftShift,Keys.RightShift) && MInput.Keyboard.Check(Keys.Add))
                Engine.Scene = new TestScene();
        }

        public override void AfterUpdate()
        {
            base.AfterUpdate();
            Vector2 tresh = new Vector2(120, 90); // Padding (horizontal,vertical)
            Vector2 npos = new Vector2(dum.X - Engine.ViewWidth / 4, dum.Y - Engine.ViewHeight / 4);

            // Clamp camera position
            if (npos.X > Engine.Width / 2 + tresh.X)
                npos.X = Math.Min(npos.X, Engine.Width / 2 + tresh.X);
            else if (npos.X < Engine.Width / 2 - tresh.X)
                npos.X = Math.Max(npos.X, tresh.X / 2);

            if (npos.Y > Engine.Height / 2 + tresh.Y)
                npos.Y = Math.Min(npos.Y, Engine.Height / 2 + tresh.Y);
            else if (npos.Y < Engine.Height / 2 - tresh.Y)
                npos.Y = Math.Max(npos.Y, tresh.Y / 2);

            camera.Position = npos;
        }


    }
}
