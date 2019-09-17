﻿using System;
using System.Reflection;
using System.Collections.Generic;
using Harmony;

namespace NULL_HARD_MOD
{
    public class Harmony_Patch
    {
        public Harmony_Patch()
        {
            try
            {
                HarmonyInstance harmonyInstance = HarmonyInstance.Create("Lobotomy.NULL.HARDMOD");

                // Unknown Patch
                harmonyInstance.Patch(typeof(CreatureSelect.CreatureSelectUnit).GetMethod("GetName", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("GetName_Patch", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(CreatureSelect.CreatureSelectUnit).GetMethod("GetText", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("GetText_Patch", AccessTools.all)), null, null);

                // Damage Patch
                harmonyInstance.Patch(typeof(EquipmentModel).GetMethod("OnTakeDamage", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnTakeDamage_Patch", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(WorkerModel).GetMethod("TakeDamageWithoutEffect", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("TakeDamageWithoutEffect_Patch", AccessTools.all)), null, null);

                // Speed Patch
                harmonyInstance.Patch(typeof(PlaySpeedSettingUI).GetMethod("OnPause"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnPause")), null, null);
                harmonyInstance.Patch(typeof(PlaySpeedSettingUI).GetMethod("OnClickPause"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnClickPause")), null, null);

                // OverLoad Level Patch
                harmonyInstance.Patch(typeof(GameStatusUI.EnergyController).GetMethod("SetOverloadIsolateNum"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("SetOverloadIsolateNum")), null, null);
                harmonyInstance.Patch(typeof(CreatureOverloadManager).GetMethod("ActivateOverload"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("ActivateOverload")), null, null);

                // Over Over Clip
                harmonyInstance.Patch(typeof(CreatureManager).GetMethod("OnFixedUpdate"), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnFixedUpdate_Creature")), null, null);

                // ZAYIN
                harmonyInstance.Patch(typeof(OneBadManyGood).GetMethod("OnFinishWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnFinishWork_OneBadManyGood", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(Wellcheers).GetMethod("OnReleaseWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnReleaseWork_Wellcheers", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(Fairy).GetMethod("OnFinishWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnFinishWork_Fairy", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(Bald).GetMethod("OnEnterRoom", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnEnterRoom_Bald", AccessTools.all)), null, null);

                // TECH
                harmonyInstance.Patch(typeof(SpiderMom).GetMethod("OnFinishWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnFinishWork_SpiderMom", AccessTools.all)), null, null);

                harmonyInstance.Patch(typeof(StraitJacket).GetMethod("OnWorkCoolTimeEnd", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnWorkCoolTimeEnd_StraitJacket", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(Cosmos).GetMethod("OnReleaseWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnReleaseWork_Cosmos", AccessTools.all)), null, null);

                harmonyInstance.Patch(typeof(ShyThing).GetMethod("OnEnterRoom", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnEnterRoom_ShyThing", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(BloodBath).GetMethod("OnEnterRoom", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnEnterRoom_BloodBath", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(BloodBath).GetMethod("OnFinishWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnFinishWork_BloodBath", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(OldLady).GetMethod("OnEnterRoom", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnEnterRoom_OldLady", AccessTools.all)), null, null);

                harmonyInstance.Patch(typeof(Baku).GetMethod("OnReleaseWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnReleaseWork_Baku", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(BakuSheepSkill).GetMethod("CheckUnit", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("CheckUnit_Baku", AccessTools.all)), null, null);
                harmonyInstance.Patch(typeof(Ppodae).GetMethod("OnReleaseWork", AccessTools.all), new HarmonyMethod(typeof(Harmony_Patch).GetMethod("OnReleaseWork_Ppodae", AccessTools.all)), null, null);

                harmonyInstance.Patch(typeof(MalkutBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Malkut", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(HodBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Hod", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(NetzachBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Netcha", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(YesodBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Yesod", AccessTools.all)), null);
                harmonyInstance.Patch(typeof(TipherethBossBase).GetMethod("IsCleared", AccessTools.all), null, new HarmonyMethod(typeof(Harmony_Patch).GetMethod("IsCleared_Tiphereth", AccessTools.all)), null);
            }
            catch(Exception exp)
            {

            }
        }

        public static bool GetName_Patch(string __result)
        {
            __result = "Unknown";
            return false;
        }

        public static bool GetText_Patch(string __result)
        {
            __result = "Unknown";
            return false;
        }

        public static bool OnTakeDamage_Patch(EquipmentModel __instance, ref UnitModel actor, ref DamageInfo dmg)
        {
            if (actor is CreatureModel)
            {
                dmg *= 1.5f;
                __instance.script.OnTakeDamage(actor, ref dmg);
            }
            else
            {
                __instance.script.OnTakeDamage(actor, ref dmg);
            }
            return false;
        }

        public static bool TakeDamageWithoutEffect_Patch(ref UnitModel actor, ref DamageInfo dmg)
        {
            dmg *= 0.4f;
            return true;
        }

        public static bool OnPause()
        {
            return false;
        }

        public static bool OnClickPause()
        {
            return false;
        }

        public static bool SetOverloadIsolateNum(ref int num)
        {
            num *= 2;
            return true;
        }

        public static bool OnFixedUpdate_Creature()
        {
            int time = (int)GlobalHistory.instance.GetCurrentTime();
            if (time != 0 && time % 60 == 0)
            {
                WhiteNightSpace.DeathAngelPlaySpeedBlockUI UI = new WhiteNightSpace.DeathAngelPlaySpeedBlockUI();
                UI.MakeSound("creature/deathangel/Lucifer_Bell0");

                int Day = PlayerModel.instance.GetDay()+1;
                if (Day <= 20)
                {
                    CreatureOverloadManager.instance.ActivateOverload(1, 0, 60, false, true, false, new long[0]);
                }
                else if (Day > 20 && Day <= 35)
                {
                    CreatureOverloadManager.instance.ActivateOverload(2, 0, 60, false, true, false, new long[0]);
                }
                else
                {
                    CreatureOverloadManager.instance.ActivateOverload(3, 0, 60, false, true, false, new long[0]);
                }

                GlobalGameManager.instance.playTime += 1;
            }
            return true;
        }

        public static bool ActivateOverload(ref int overloadCount)
        {
            overloadCount *= 2;
            return true;
        }

        public static bool OnFinishWork_OneBadManyGood(ref UseSkill skill)
        {
            if (skill.skillTypeInfo.rwbpType == RwbpType.W)
            {
                if (skill.agent.temperanceLevel == 1 || skill.agent.prudenceLevel <= 2)
                {
                    skill.agent.mental = 0;
                    skill.agent.Panic();
                    return false;
                }
            }
            return true;
        }

        public static bool OnReleaseWork_Wellcheers(ref UseSkill skill)
        {
            int skillLevel = 0;
            if (skill.skillTypeInfo.rwbpType == RwbpType.R) // 용기
            {
                skillLevel = skill.agent.fortitudeLevel;
            }
            else if (skill.skillTypeInfo.rwbpType == RwbpType.W)
            {
                skillLevel = skill.agent.prudenceLevel;
            }
            else if (skill.skillTypeInfo.rwbpType == RwbpType.B)
            {
                skillLevel = skill.agent.temperanceLevel;
            }
            else
            {
                skillLevel = skill.agent.justiceLevel;
            }

            bool Check1 = skillLevel >= skill.agent.fortitudeLevel;
            bool Check2 = skillLevel >= skill.agent.prudenceLevel;
            bool Check3 = skillLevel >= skill.agent.temperanceLevel;
            bool Check4 = skillLevel >= skill.agent.justiceLevel;

            if (Check1 && Check2 && Check3 && Check4)
            {
                return true;
            }
            else
            {
                skill.agent.Die();
                return true;
            }
        }

        public static bool OnFinishWork_Fairy(ref UseSkill skill)
        {
            CreatureFeelingState currentFeelingState = skill.GetCurrentFeelingState();
            if (currentFeelingState == CreatureFeelingState.GOOD)
            {
                skill.agent.Die();
            }
            return true;
        }

        public static bool OnEnterRoom_Bald(ref UseSkill skill)
        {
            skill.agent.mental *= 0.4f;
            return true;
        }

        public static bool OnFinishWork_SpiderMom(ref UseSkill skill)
        {
            CreatureFeelingState currentFeelingState = skill.GetCurrentFeelingState();
            if (currentFeelingState == CreatureFeelingState.BAD)
            {
                skill.agent.Die();
                return true;
            }

            skill.agent.hp -= (60 - (skill.agent.temperanceLevel * 10));
            if (skill.agent.hp <= 0)
            {
                skill.agent.Die();
                return true;
            }
            return true;
        }

        public static bool OnWorkCoolTimeEnd_StraitJacket(StraitJacket __instance, ref CreatureFeelingState oldState)
        {
            if (oldState == CreatureFeelingState.NORM)
            {
                __instance.model.SubQliphothCounter();
            }
            return true;
        }

        public static bool OnReleaseWork_Cosmos(Cosmos __instance, ref UseSkill skill)
        {
            CreatureFeelingState currentFeelingState = skill.GetCurrentFeelingState();
            if (currentFeelingState == CreatureFeelingState.NORM)
            {
                __instance.model.SubQliphothCounter();
            }
            else if (currentFeelingState == CreatureFeelingState.BAD)
            {
                __instance.model.SubQliphothCounter();
                __instance.model.SubQliphothCounter();
            }

            if (skill.agent.fortitudeLevel >= 3)
            {
                __instance.model.SubQliphothCounter();
            }
            return true;
        }

        public static bool OnEnterRoom_ShyThing(ShyThing __instance, ref UseSkill skill)
        {
            int faceType = __instance.animScript.GetFaceType() + 1;
            if (skill.agent.level <= faceType)
            {
                skill.agent.Die();
                return false;
            }

            return true;
        }

        public static bool OnEnterRoom_BloodBath(ref UseSkill skill)
        {
            int fortitudeLevel = skill.agent.fortitudeLevel;
            int temperanceLevel = skill.agent.temperanceLevel;
            if (fortitudeLevel > temperanceLevel)
            {
                skill.agent.Die();
                return false;
            }
            return true;
        }

        public static bool OnFinishWork_BloodBath(ref UseSkill skill)
        {
            CreatureFeelingState currentFeelingState = skill.GetCurrentFeelingState();
            if (currentFeelingState == CreatureFeelingState.BAD)
            {
                skill.agent.Die();
                return false;
            }
            return true;
        }

        public static bool OnEnterRoom_OldLady(OldLady __instance, ref UseSkill skill)
        {
            if (skill.skillTypeInfo.rwbpType == RwbpType.P)
            {
                skill.agent.mental = 0;
                skill.agent.Panic();
                return false;
            }
            else if ((4 - __instance.model.qliphothCounter) >= skill.agent.temperanceLevel)
            {
                skill.agent.mental = 0;
                skill.agent.Panic();
                return false;
            }
            return true;
        }

        public static bool OnReleaseWork_Baku(Baku __instance, ref UseSkill skill)
        {
            CreatureFeelingState currentFeelingState = skill.GetCurrentFeelingState();
            if (currentFeelingState == CreatureFeelingState.NORM)
            {
                if (__instance.Prob(50))
                {
                    __instance.model.SubQliphothCounter();
                }
            }

            return true;
        }

        public static bool CheckUnit_Baku(ref UnitModel unit)
        {
            WorkerModel workerModel = unit as WorkerModel;
            workerModel.mental = 0f;
            workerModel.Panic();
            return false;
        }

        public static bool OnReleaseWork_Ppodae(Ppodae __instance, ref UseSkill skill)
        {
            if (skill.skillTypeInfo.rwbpType != RwbpType.R)
            {
                skill.agent.Die();
            }
            CreatureFeelingState currentFeelingState = skill.GetCurrentFeelingState();
            if (currentFeelingState == CreatureFeelingState.NORM)
            {
                if (__instance.Prob(50))
                {
                    __instance.model.SubQliphothCounter();
                }
            }
            return true;
        }

        public static void IsCleared_Malkut(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 7;
        }

        public static void IsCleared_Hod(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 7;
        }

        public static void IsCleared_Netcha(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 7;
        }

        public static void IsCleared_Yesod(ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && CreatureOverloadManager.instance.GetQliphothOverloadLevel() >= 7;
        }

        public static void IsCleared_Tiphereth(TipherethBossBase __instance, ref bool __result)
        {
            float energy = EnergyModel.instance.GetEnergy();
            float needEnery = StageTypeInfo.instnace.GetEnergyNeed(PlayerModel.instance.GetDay());
            __result = energy >= needEnery && __instance.QliphothOverloadLevel >= 10;
        }

    }
}