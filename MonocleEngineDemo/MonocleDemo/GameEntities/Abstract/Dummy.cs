using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonocleDemoNamespace.Logic;
using Microsoft.Xna.Framework;
using Monocle;

namespace MonocleDemoNamespace.GameEntities.Abstract
{
    public class Dummy: Entity
    {
        Sprite Sprite;

        public Dummy()
        {
            Add(Sprite = GFX.AllSprites.Create("player"));
            Collider = new Hitbox(32, 32, -16, -16);
        }

        public void Move(Vector2 add)
        {
            if (add.X != 0 || add.Y != 0)
            {
                Sprite.Play("move", false);

                // Move maximum in a direction until hitting a wall

                if (CollideCheck(GAccess.WallTag, new Vector2(X + add.X, Y)))
                {
                    while (!CollideCheck(GAccess.WallTag, new Vector2(X + Calc.Sign(add).X, Y)))
                        X += Calc.Sign(add).X;
                }
                else
                    X += add.X* 60f * Engine.DeltaTime;

                if (CollideCheck(GAccess.WallTag, new Vector2(X, Y + add.Y)))
                {
                    while (!CollideCheck(GAccess.WallTag, new Vector2(X, Y + Calc.Sign(add).Y)))
                        Y += Calc.Sign(add).Y;
                }
                else
                    Y += add.Y* 60f * Engine.DeltaTime;
            }
        }

    }
}
