using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        itemSlotChosen = itemSlotContainer.Find("itemSlotChosen");

        RefreshInventory();

        // Show chosen item (only in loot scene)
        if (itemSlotChosen != null)
        {
            itemSlotChosen.gameObject.SetActive(true);
            SetImageAndStats(itemSlotChosen.GetComponent<RectTransform>(), LootScene.itemChosen);
        }
    }

    //---------------------------------------------------------------------------------------------

    public void RefreshInventory()
    {
        int x = 0;
        int y = 0;

        // Clean inventory before refresh
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("UIItem"))
        {
            Destroy(go);
        }

        foreach (Item item in Player.inventory)
        {
            RectTransform itemSlotRecttransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRecttransform.gameObject.SetActive(true);
            itemSlotRecttransform.anchoredPosition = new Vector2((x * itemSlotCellSizex) + itemSlotOffsetx, (y * itemSlotCellSizey * -1) + itemSlotOffsety);
            x++;
            if(x > inventoryColumns - 1)
            {
                x = 0;
                y++;
            }

            SetImageAndStats(itemSlotRecttransform, item);

            // Set item in UIItem class
            UIItem uiItem = itemSlotRecttransform.GetComponent<UIItem>();
            uiItem.item = item;

            // Set tag for easy removal
            itemSlotRecttransform.tag = "UIItem";
        }
    }

    //---------------------------------------------------------------------------------------------
    private void SetImageAndStats(RectTransform itemSlot, Item item)
    {
        // Set image according to type
        Image img = itemSlot.Find("image").GetComponent<Image>();

        switch (item.itemType)
        {
            case Item.ItemType.ARMOR:
                img.sprite = belt;
                break;
            case Item.ItemType.RING:
                img.sprite = ring;
                break;
            // Nothing to do, weapon is the default sprite
            case Item.ItemType.WEAPON:
            default: 
                break;
        }

        // Set stats
        TextMeshProUGUI textBox = itemSlot.Find("stats").GetComponent<TextMeshProUGUI>();
        textBox.text = string.Format("Attack damage: {0}\nDefense: {1}\nDodge: {2}\nLife Steal: {3}\n", item.AD, item.defense, item.dodge, item.lifeSteal);
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform itemSlotChosen;

    [SerializeField]private Sprite belt;
    [SerializeField]private Sprite ring;

    public int inventoryColumns;
    public float itemSlotCellSizex;
    public float itemSlotCellSizey;
    public float itemSlotOffsetx;
    public float itemSlotOffsety;
}
