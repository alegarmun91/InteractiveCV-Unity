using System;
using UnityEngine;

namespace AssetStoreOriginals._SNAPS_PrototypingAssets.About.Scripts
{
    public class Readme : ScriptableObject
    {
        public Texture2D icon;
        public float iconMaxWidth = 128f;
        public bool loadedLayout;
        public Section[] sections;
        public string title;
        public string titlesub;

        [Serializable]
        public class Section
        {
            public string heading, text, linkText, url;
        }
    }
}