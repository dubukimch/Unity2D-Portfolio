using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Skill")]
public class ItemSkillEft : ItemEffect
{
    public bool Skill_Master_BGM = true;
    public bool Basic_Punch_Value = true;
    public bool Basic_Kick_Value = true;
    public bool Gomu_Raple_Value = false;
    public bool Gomu_Bazooka_Value = false;
    public bool Gomu_Gatling_Value = false;
    public bool Gomu_Spear_Value = false;
    public bool Gomu_Ax_Value = false;
    public bool Gomu_Balloon_Value = false;

    public override bool ExecuteRole()
    {
        SoundManager.Instance.Skill_Master_BGM = Skill_Master_BGM;

        GameManager.Instance.Basic_Punch_Value = Basic_Punch_Value;
        GameManager.Instance.Basic_Kick_Value = Basic_Kick_Value;
        GameManager.Instance.Gomu_Raple_Value = Gomu_Raple_Value;
        GameManager.Instance.Gomu_Bazooka_Value = Gomu_Bazooka_Value;
        GameManager.Instance.Gomu_Gatling_Value = Gomu_Gatling_Value;
        GameManager.Instance.Gomu_Spear_Value = Gomu_Spear_Value;
        GameManager.Instance.Gomu_Ax_Value = Gomu_Ax_Value;
        GameManager.Instance.Gomu_Balloon_Value = Gomu_Balloon_Value;


        return true;

    }
}