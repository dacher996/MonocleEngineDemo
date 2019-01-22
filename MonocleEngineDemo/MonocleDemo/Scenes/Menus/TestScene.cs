using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonocleDemoNamespace.Scenes.Menus
{
    public class TestScene: Scene
    {

        public override void Begin()
        {
            base.Begin();

            var renderer = new EverythingRenderer();
            Add(renderer);


        }

    }
}
