using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private ItemDataSO itemData;

    private InventoryItem itemToAdd;
    private InventoryBase playerInventory;

    private void Awake()
    {
        itemToAdd = new InventoryItem(itemData);
    }

    private void OnValidate()
    {
        if (itemData == null)
            return;

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemData.itemIcon;
        gameObject.name = "Item - " + itemData.itemName;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerInventory = other.GetComponent<InventoryBase>();

        if (playerInventory != null && playerInventory.CanAddItem())
        {
            playerInventory.AddItem(itemToAdd);
            Destroy(gameObject);
        }
    }
}
