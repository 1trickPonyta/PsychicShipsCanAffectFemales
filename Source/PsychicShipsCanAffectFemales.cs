using Verse;
using RimWorld;
using HarmonyLib;

namespace PsychicShipsCanAffectFemales
{
    [StaticConstructorOnStartup]
    static class PsychicShipsCanAffectFemales
    {
        const string PACKAGE_ID = "psychicshipscanaffectfemales.1trickPonyta";

        static PsychicShipsCanAffectFemales()
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();
#if DEBUG
            Log.Message("[Psychic Ships Can Affect Females] Patch applied.");
#endif
        }
    }

    [HarmonyPatch(typeof(CompCauseGameCondition_PsychicEmanation))]
    [HarmonyPatch("Initialize")]
    class Patch
    {
        static AccessTools.FieldRef<CompCauseGameCondition_PsychicEmanation, Gender> genderRef = 
            AccessTools.FieldRefAccess<CompCauseGameCondition_PsychicEmanation, Gender>("gender");

        static void Postfix(CompCauseGameCondition_PsychicEmanation __instance)
        {
            genderRef(__instance) = Rand.Bool ? Gender.Male : Gender.Female;
        }
    }
}
