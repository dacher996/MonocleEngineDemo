using MonocleDemoNamespace.Logic;
using Microsoft.Xna.Framework;
using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonocleDemoNamespace.GameEntities.Abstract
{
    public class SolidWall: Entity
    {
        Sprite Sprite; // Entity sprite

        public SolidWall()
        {
            Add(Sprite = GFX.AllSprites.Create("wall"));
            Collider = new Hitbox(32, 32, -16, -16);
            Tag = GAccess.WallTag;
        }

        public SolidWall(Vector2 pos) : this()
        {
            Position = pos;
        }

    }
}
