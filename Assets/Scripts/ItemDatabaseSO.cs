using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Database")]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();         // ItemSO를 리스트로 관리한다

    // 캐싱을 위한 사전
    private Dictionary<int, ItemSO> itemsByID;              // ID로 아이템 찾기 위한 캐싱
    private Dictionary<string, ItemSO> itemsByName;         // 이름으로 아이템 찾기 위한 캐싱

    public void Initialize()        // 초기 설정 함수
    {
        itemsByID = new Dictionary<int, ItemSO>();
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)             // items 리스트에 선언 되어있는 것을 가지고 Dictionary에 입력한다.
        {
            itemsByID[item.id] = item;
            itemsByName[item.itemName] = item;
        }
    }

    // ID로 아이템 찾기
    public ItemSO GetItemByID(int id)
    {
        if (itemsByID == null)  // 캐싱이 안 되어있다면
        {
            Initialize();   // 초기화
        }

        if (itemsByID.TryGetValue(id, out ItemSO item)) // id로 ItemSO 찾아서 리턴
        {
            return item;
        }

        return null;    // 없으면 null
    }

    // 이름으로 아이템 찾기
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

    // 타입으로 아이템 필터링
    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
