using MelonLoader;
using UnityEngine;

namespace CloudpunkVR
{
    public class CloudpunkVR : MelonMod
    {
        private Camera guiCamera;
        private Canvas guiCanvas;

        public override void OnUpdate()
        {
            ensureGuiCanvas();
        }

        private bool ensureGuiCanvas()
        {
            if (guiCanvas != null)
            {
                return true;
            }
            foreach (var canvas in GameObject.FindObjectsOfType<Canvas>())
            {
                if (canvas.name == "Canvas-UI")
                {
                    guiCanvas = canvas;
                    MelonLogger.Msg("Canvas UI found!");
                    return true;
                
                }
            }
            MelonLogger.Msg("Canvas UI not found yet.");
            return false;
        }
    }
}
