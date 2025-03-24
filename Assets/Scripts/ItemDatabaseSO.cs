using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Database")]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();         // ItemSO�� ����Ʈ�� �����Ѵ�

    // ĳ���� ���� ����
    private Dictionary<int, ItemSO> itemsByID;              // ID�� ������ ã�� ���� ĳ��
    private Dictionary<string, ItemSO> itemsByName;         // �̸����� ������ ã�� ���� ĳ��

    public void Initialize()        // �ʱ� ���� �Լ�
    {
        itemsByID = new Dictionary<int, ItemSO>();
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)             // items ����Ʈ�� ���� �Ǿ��ִ� ���� ������ Dictionary�� �Է��Ѵ�.
        {
            itemsByID[item.id] = item;
            itemsByName[item.itemName] = item;
        }
    }

    // ID�� ������ ã��
    public ItemSO GetItemByID(int id)
    {
        if (itemsByID == null)  // ĳ���� �� �Ǿ��ִٸ�
        {
            Initialize();   // �ʱ�ȭ
        }

        if (itemsByID.TryGetValue(id, out ItemSO item)) // id�� ItemSO ã�Ƽ� ����
        {
            return item;
        }

        return null;    // ������ null
    }

    // �̸����� ������ ã��
    public ItemSO GetItemByName(string name)
    {
        if (itemsByID == null)
        {
            Initialize();
        }

        if (itemsByName.TryGetValue(name, out ItemSO item))
        {
            return item;
        }

        return null;
    }

    // Ÿ������ ������ ���͸�
    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
