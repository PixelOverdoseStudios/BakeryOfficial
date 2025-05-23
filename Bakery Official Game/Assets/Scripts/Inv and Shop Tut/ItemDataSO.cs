using UnityEngine;

[CreateAssetMenu(menuName ="Item Data/Material Item", fileName = "Material Data")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;
    public int maxStackSize = 1;
}

public enum ItemType
{
    Material,
    Weapon,
    Armor,
    Trinket
}
