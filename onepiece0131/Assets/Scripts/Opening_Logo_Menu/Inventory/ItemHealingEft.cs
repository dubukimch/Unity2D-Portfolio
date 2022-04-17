using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{

    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        GameManager.Instance.Player_Hp += (float)healingPoint/10;
        return true;

    }
}
