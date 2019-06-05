using VRGIN.Core;
using Harmony;
using System.Reflection;

namespace HoneySelectVR
{
    class VoiceShim
    {
        public static void Inject()
        {
            var harmony = HarmonyInstance.Create("com.zerothangel.HoneySelectVR.PosAudioFix");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(Manager.Voice))]
        [HarmonyPatch("Play")]
        class Play
        {
            public static void Prefix(ref bool force2D)
            {
                var impersonating = !VR.Interpreter.IsEveryoneHeaded;
                if (impersonating)
                {
                    force2D = false;
                }
            }
        }
    }
}
