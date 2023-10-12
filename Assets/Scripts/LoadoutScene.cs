using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadoutScene : MonoBehaviour
{
    private void Start()
    {
        SetPlayerEquipment();
    }

    //---------------------------------------------------------------------------------------------

    public void NextLevel()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    //---------------------------------------------------------------------------------------------

    public static void SetPlayerEquipment()
    {
        TextMeshProUGUI weaponStats = GameObject.Find("itemEquippedWeapon").GetComponentInChildren<TextMeshProUGUI>();
        weaponStats.text = string.Format("Attack damage: {0}\nDefense: {1}\nDodge: {2}\nLife Steal: {3}\n", Player.weapon.AD, Player.weapon.defense, Player.weapon.dodge, Player.weapon.lifeSteal);

        TextMeshProUGUI armorStats = GameObject.Find("itemEquippedArmor").GetComponentInChildren<TextMeshProUGUI>();
        armorStats.text = string.Format("Attack damage: {0}\nDefense: {1}\nDodge: {2}\nLife Steal: {3}\n", Player.armor.AD, Player.armor.defense, Player.armor.dodge, Player.armor.lifeSteal);

        TextMeshProUGUI ringStats = GameObject.Find("itemEquippedRing").GetComponentInChildren<TextMeshProUGUI>();
        ringStats.text = string.Format("Attack damage: {0}\nDefense: {1}\nDodge: {2}\nLife Steal: {3}\n", Player.ring.AD, Player.ring.defense, Player.ring.dodge, Player.ring.lifeSteal);
    }
}
