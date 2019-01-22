using Monocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonocleDemoNamespace.Logic
{
    public class GFX
    {

        #region Fields

        private static SpriteBank _spriteBank = null;
        List<Atlas> Atlases;

        public static SpriteBank AllSprites
        {
            get
            {
                return _spriteBank;
            }
        }

        #endregion

        #region Singleton

        private static GFX _instance = null;

        public static GFX Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GFX();
                return _instance;
            }
        }

        private GFX()
        {
            InitStuff();
        }

        #endregion
        
        private void InitStuff()
        {
            Atlases = new List<Atlas>();
            Atlases.Add(Atlas.FromAtlas("Atlases\\testboxes", Atlas.AtlasDataFormat.CrunchXmlOrBinary));
            
            _spriteBank = new SpriteBank(Atlases[0], "spriteData\\Sprites.xml");
        }

        /// <summary>
        /// Reloads atlases from file (should not be called so often).
        /// </summary>
        public void RefreshData()
        {
            InitStuff();
        }

    }
}
