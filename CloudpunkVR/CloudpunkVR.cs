using MelonLoader;

namespace CloudpunkVR
{
    public class CloudpunkVR : MelonMod
    {
        private UI ui;

        public override void OnApplicationStart()
        {
            ui = new UI();
            ui.OnSetup();
        }

        public override void OnUpdate()
        {
            ui.OnUpdate();
        }
    }
}
