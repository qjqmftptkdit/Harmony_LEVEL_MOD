using System;
using Harmony;
using System.Reflection;

namespace NULL_BABY_MOD
{
    public class Harmony_Patch
    {
        public Harmony_Patch()
        {
            try
            {
                HarmonyInstance harmonyInstance = HarmonyInstance.Create("Lobotomy.NULL.BABYMOD");

                // Damage Patch
                harmonyInstance.Patch(typeof(EquipmentModel).GetMethod("OnTakeDamage", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnTakeDamage_Patch", AccessTools.all)), null, null);

                // OverLoad Level Patch
                harmonyInstance.Patch(typeof(GameStatusUI.EnergyController).GetMethod("SetOverloadIsolateNum"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("SetOverloadIsolateNum")), null, null);
                harmonyInstance.Patch(typeof(CreatureOverloadManager).GetMethod("ActivateOverload"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("ActivateOverload")), null, null);

                // Stat Patch && PE-box Patch && Don't Effect to monster feeling
                harmonyInstance.Patch(typeof(UseSkill).GetMethod("FinishWorkSuccessfully", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("FinishWorkSuccessfully", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(UseSkill).GetMethod("GetCurrentFeelingState", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("GetCurrentFeelingState", AccessTools.all)), null, null);

                // Work Speed Patch
                harmonyInstance.Patch(typeof(UseSkill).GetMethod("InitUseSkillAction", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("InitUseSkillAction", AccessTools.all)), null);

                // BoseBase Patch
                harmonyInstance.Patch(typeof(TipherethBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Tiphereth", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(MalkutBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Malkut", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(HodBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Hod", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(NetzachBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Netcha", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(YesodBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Yesod", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(ChesedBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Chesed", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(ChokhmahBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Chokhmah", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(BinahBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Bina", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(BinahCoreScript).GetMethod("CanTakeDamage", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("CanTakeDamage_Bina", AccessTools.all)), null);

                // Clipoter Patch
                harmonyInstance.Patch(typeof(CreatureOverloadManager).GetMethod("AddOverloadGague"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("AddOverloadGague")), null, null);
                harmonyInstance.Patch(typeof(GameStatusUI.EnergyController).GetMethod("SetOverloadGauge", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("SetOverloadGauge", AccessTools.all)), null, null);
            }catch(Exception exp)
            {

            }
        }

        public static bool OnTakeDamage_Patch(EquipmentModel __instance, ref UnitModel actor, ref DamageInfo dmg)
        {
            if (actor is CreatureModel)
            {
                dmg *= 0.5f;
                __instance.script.OnTakeDamage(actor, ref dmg);
            }
            else
            {
                dmg *= 1.5f;
                __instance.script.OnTakeDamage(actor, ref dmg);
            }
            return false;
        }

        public static bool SetOverloadIsolateNum(ref int num)
        {
            num = (int)(num * 0.5);
            return true;
        }

        public static bool ActivateOverload(ref int overloadCount)
        {
            overloadCount = (int)(overloadCount * 0.5);
            return true;
        }

        public static bool FinishWorkSuccessfully(UseSkill __instance)
        {
            __instance.successCount *= 3;
            return true;
        }

        public static bool GetCurrentFeelingState(UseSkill __instance)
        {
            __instance.successCount /= 3;
            return true;
        }

        public static void InitUseSkillAction(ref UseSkill __result)
        {
            __result.workSpeed *= 3;
        }

        public static void IsCleared_Tiphereth(TipherethBossBase __instance, ref bool __result)
        {
            __result = __instance.QliphothOverloadLevel >= 7;
        }

        public static void IsCleared_Malkut(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 4;
        }

        public static void IsCleared_Hod(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 4;
        }

        public static void IsCleared_Netcha(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 4;
        }

        public static void IsCleared_Yesod(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 4;
        }

        public static void IsCleared_Chesed(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 6;
        }

        public static void IsCleared_Chokhmah(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 6;
        }

        public static void IsCleared_Bina(BinahBossBase __instance, ref bool __result)
        {
            __result = __instance.Script.Phase == BinahBoss.BinahPhase.P2;
        }

        public static void CanTakeDamage_Bina(ref bool __result)
        {
            __result = true;
        }

        public static bool AddOverloadGague(CreatureOverloadManager __instance)
        {
            int loadgauge = (int)__instance.GetType().GetField("qliphothOverloadGauge", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance);
            __instance.GetType().GetField("qliphothOverloadGauge", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(__instance, loadgauge + 2);
            return true;
        }

        public static bool SetOverloadGauge(ref int num, ref int max)
        {
            num /= 3;
            max = (max / 3 + 1);
            return true;
        }

    }
}
