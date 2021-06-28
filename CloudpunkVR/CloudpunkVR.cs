using MelonLoader;

namespace CloudpunkVR
{
    public class CloudpunkVR : MelonMod
    {
        public override void OnUpdate()
        {
            MelonLogger.Msg("OnUpdate");
            //if (Input.GetKeyDown(KeyCode.T))
            //{
            //    MelonModLogger.Msg("You just pressed T");
            //}
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("OnSceneWasLoaded");
            MelonLogger.Msg(sceneName);
        }
    }
}
