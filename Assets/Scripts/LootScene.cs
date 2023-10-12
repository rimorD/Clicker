using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LootScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerPrefs.GetInt("Level", 1);
        left = Item.GenerateRandom(level, Item.ItemType.WEAPON);
        center = Item.GenerateRandom(level, Item.ItemType.ARMOR);
        right = Item.GenerateRandom(level, Item.ItemType.RING);

        arsc.PlayOneShot(open);

        ShowStats();
    }

    //---------------------------------------------------------------------------------------------

    public void ShowStats()
    {
        // Left (weapon)
        weaponAD.text = string.Format("{0} -> {1}", Player.weapon.AD, left.AD);
        weaponAD.color = Player.weapon.AD >= left.AD ? Color.red : Color.green;

        weaponDef.text = string.Format("{0} -> {1}", Player.weapon.defense, left.defense);
        weaponDef.color = Player.weapon.defense >= left.defense ? Color.red : Color.green;

        weaponDge.text = string.Format("{0} -> {1}", Player.weapon.dodge, left.dodge);
        weaponDge.color = Player.weapon.dodge >= left.dodge ? Color.red : Color.green;

        weaponLS.text = string.Format("{0} -> {1}", Player.weapon.lifeSteal, left.lifeSteal);
        weaponLS.color = Player.weapon.lifeSteal >= left.lifeSteal ? Color.red : Color.green;

        // Center (armor)
        armorAD.text = string.Format("{0} -> {1}", Player.armor.AD, center.AD);
        armorAD.color = Player.armor.AD >= center.AD ? Color.red : Color.green;

        armorDef.text = string.Format("{0} -> {1}", Player.armor.defense, center.defense);
        armorDef.color = Player.armor.defense >= center.defense ? Color.red : Color.green;

        armorDge.text = string.Format("{0} -> {1}", Player.armor.dodge, center.dodge);
        armorDge.color = Player.armor.dodge >= center.dodge ? Color.red : Color.green;

        armorLS.text = string.Format("{0} -> {1}", Player.armor.lifeSteal, center.lifeSteal);
        armorLS.color = Player.armor.lifeSteal >= center.lifeSteal ? Color.red : Color.green;

        // Right (ring)
        ringAD.text = string.Format("{0} -> {1}", Player.ring.AD, right.AD);
        ringAD.color = Player.ring.AD >= right.AD ? Color.red : Color.green;

        ringDef.text = string.Format("{0} -> {1}", Player.ring.defense, right.defense);
        ringDef.color = Player.ring.defense >= right.defense ? Color.red : Color.green;

        ringDge.text = string.Format("{0} -> {1}", Player.ring.dodge, right.dodge);
        ringDge.color = Player.ring.dodge >= right.dodge ? Color.red : Color.green;

        ringLS.text = string.Format("{0} -> {1}", Player.ring.lifeSteal, right.lifeSteal);
        ringLS.color = Player.ring.lifeSteal >= right.lifeSteal ? Color.red : Color.green;
    }

    // --------------------------------------------------------------------------------------------

    public void PickLeft()
    {
        // If less than 6 items, add directly and move on
        if (Player.inventory.Count < 6)
        {
            Player.inventory.Add(left);
            SceneManager.LoadScene("LoadoutScene");
        }
        // Otherwise we have to delete something
        else
        {
            ShowInventoryForReplacement(left);
        }
    }

    // --------------------------------------------------------------------------------------------

    public void PickCenter()
    {
        // If less than 6 items, add directly and move on
        if (Player.inventory.Count < 6)
        {
            Player.inventory.Add(center);
            SceneManager.LoadScene("LoadoutScene");
        }
        // Otherwise we have to delete something
        else
        {
            ShowInventoryForReplacement(center);
        }
    }

    // --------------------------------------------------------------------------------------------

    public void PickRight()
    {
        // If less than 6 items, add directly and move on
        if (Player.inventory.Count < 6)
        {
            Player.inventory.Add(right);
            SceneManager.LoadScene("LoadoutScene");
        }
        // Otherwise we have to delete something
        else
        {
            ShowInventoryForReplacement(right);
        }
    }

    // --------------------------------------------------------------------------------------------

    public void ShowInventoryForReplacement(Item chosen)
    {
        itemChosen = chosen;
        inventoryPanel.gameObject.SetActive(true);
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    private Item left;
    private Item center;
    private Item right;

    // UI and sound
    [SerializeField]RectTransform inventoryPanel;
    [SerializeField]AudioSource arsc;
    [SerializeField] AudioClip open;

    // Replace data
    public static Item itemChosen;

    // Stat blocks
    public TextMeshProUGUI weaponAD;
    public TextMeshProUGUI weaponDef;
    public TextMeshProUGUI weaponDge;
    public TextMeshProUGUI weaponLS;

    public TextMeshProUGUI armorAD;
    public TextMeshProUGUI armorDef;
    public TextMeshProUGUI armorDge;
    public TextMeshProUGUI armorLS;

    public TextMeshProUGUI ringAD;
    public TextMeshProUGUI ringDef;
    public TextMeshProUGUI ringDge;
    public TextMeshProUGUI ringLS;
}
