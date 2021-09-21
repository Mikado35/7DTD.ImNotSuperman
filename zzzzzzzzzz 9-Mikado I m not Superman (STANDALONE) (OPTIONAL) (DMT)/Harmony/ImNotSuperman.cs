using System.Reflection;
using HarmonyLib;
using DMT;
using UnityEngine;


namespace Harmony_Mikado_Core_ImNotSuperman
{
    public class ImNotSupermanDMT
    {
        public class Init : IHarmony
        {
            public void Start()
            {
                Debug.Log((object)("Mikado Loading Patch : " + this.GetType().ToString()));
                new Harmony(this.GetType().ToString()).PatchAll(Assembly.GetExecutingAssembly());
            }
        }

        [HarmonyPatch(typeof(EntityVehicle))]
        [HarmonyPatch("GetActivationCommands")]
        private class PatchEntityVehicleGetActivationCommands
        {
            private static void Postfix(EntityVehicle __instance, EntityActivationCommand[] __result)
            {
                if (__instance.EntityClass.entityClassName.ToLower().Contains("bicycle") )
                    return;
                for (int index = 0; index < __result.Length; ++index)
                {
                    if (__result[index].text == "take")
                        __result[index].enabled = false;
                }
            }
        }
    }

}
