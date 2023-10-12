using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData ped)
    {
        // Behaviour depending on current scene
        string currentScene = SceneManager.GetActiveScene().name;

        // Loot scene, delete and get replaced
        if(currentScene == "LootScene")
        {
            Player.inventory.Remove(item);
            Player.inventory.Add(LootScene.itemChosen);
            SceneManager.LoadScene("LoadoutScene");
        }
        // Loadout scene, equip item
        else
        {
            switch (item.itemType)
            {
                case Item.ItemType.WEAPON:
                    Item previousWeapon = Player.weapon;
                    Player.weapon = item;
                    Player.inventory.Remove(item);
                    Player.inventory.Add(previousWeapon);
                    break;
                case Item.ItemType.ARMOR:
                    Item previousArmor = Player.armor;
                    Player.armor = item;
                    Player.inventory.Remove(item);
                    Player.inventory.Add(previousArmor);
                    break;
                case Item.ItemType.RING:
                    Item previousRing = Player.ring;
                    Player.ring = item;
                    Player.inventory.Remove(item);
                    Player.inventory.Add(previousRing);
                    break;
            }

            // Refresh inventory
            GameObject.Find("Inventory").GetComponent<UIInventory>().RefreshInventory();
            LoadoutScene.SetPlayerEquipment();
        }

    }


    // Data ///////////////////////////////////////////////////////////////////////////////////////
    public Item item { get; set; }
}
