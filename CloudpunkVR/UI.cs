using UnityEngine;
using MelonLoader;

namespace CloudpunkVR
{
    public class UI : MonoBehaviour
    {
        private Camera uiCamera;
        private Canvas uiCanvas;
        private RenderTexture uiTexture;

        public void OnSetup()
        {
            createGuiCamera();
        }

        public void OnUpdate()
        {
            ensureGuiCanvas();
        }

        private void createGuiCamera()
        {
            uiTexture = new RenderTexture(new RenderTextureDescriptor(Screen.width, Screen.height));
            GameObject uiCameraObject = new GameObject("uiCameraObject");
            DontDestroyOnLoad(uiCameraObject);
            uiCamera = uiCameraObject.AddComponent<Camera>();
            uiCamera.orthographic = true;
            uiCamera.targetTexture = uiTexture;
            uiCamera.depth = 1;
            uiCamera.useOcclusionCulling = false;
            // This enables transparency on the GUI
            // I tried "Depth" for the clear flags, but
            // it had weird/unexpected results and Color
            // just works...
            uiCamera.clearFlags = CameraClearFlags.Color;
            // Required to actually capture only the GUI layer
            uiCamera.cullingMask = (1 << LayerMask.NameToLayer("UI"));
            uiCamera.farClipPlane = 1.1f;
            uiCamera.nearClipPlane = 0.9f;
            uiCamera.enabled = true;
            if (uiTexture == null)
            {
                MelonLogger.Msg("UI Texture not created.");
            }
            if (uiCamera == null)
            {
                MelonLogger.Msg("UI Camera not created.");
            }
            MelonLogger.Msg("createGuiCamera");
        }

        private bool ensureGuiCanvas()
        {
            if (uiCanvas != null)
            {
                return true;
            }
            foreach (var canvas in GameObject.FindObjectsOfType<Canvas>())
            {
                if (canvas.name == "Canvas-UI")
                {
                    MelonLogger.Msg("Canvas UI found!");
                    uiCanvas = canvas;
                    onGuiCanvasFound();
                    return true;
                }
            }
            MelonLogger.Msg("Canvas UI not found yet.");
            return false;
        }

        private void onGuiCanvasFound()
        {
            MelonLogger.Msg(uiCanvas.ToString());
            MelonLogger.Msg(uiCamera.ToString());  // this is null
            MelonLogger.Msg(uiTexture.ToString());
            uiCanvas.worldCamera = uiCamera;
            uiCanvas.renderMode = RenderMode.WorldSpace;
            uiCamera.gameObject.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, -1);
            uiCamera.orthographicSize = Screen.height * 0.5f;
        }
    }
}
