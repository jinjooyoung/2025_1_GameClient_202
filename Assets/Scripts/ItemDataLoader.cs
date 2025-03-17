using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;

public class ItemDataLoader : MonoBehaviour
{
    [SerializeField]
    private string jsonFileName = "Items";      // Resources �������� ������ JSON ���� �̸�

    private List<ItemData> itemList;

    // Start is called before the first frame update
    void Start()
    {
        LoadItemData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadItemData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);       // TextAsset ���·� json ������ �ε��Ѵ�.

        if (jsonFile != null)       // ������ �������� null �� ó���� �Ѵ�.
        {
            // ���� �ؽ�Ʈ���� UTF-8�� ��ȯ ó��
            byte[] bytes = Encoding.Default.GetBytes(jsonFile.text);
            string correntText = Encoding.UTF8.GetString(bytes);

            // ��ȯ�� �ؽ�Ʈ ���
            itemList = JsonConvert.DeserializeObject<List<ItemData>>(correntText);

            Debug.Log($"�ε�� ������ �� : {itemList.Count}");

            foreach(var item in itemList)
            {
                Debug.Log($"������ : {EncodeKorean(item.itemName)}, ���� : {EncodeKorean(item.description)}");
            }
        }
        else
        {
            Debug.LogError($"JSON ������ ã�� �� �����ϴ�. : {jsonFileName}");
        }
    }

    // �ѱ� ���ڵ��� ���� ���� �Լ�
    private string EncodeKorean(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";          // �ؽ�Ʈ�� null ���̸� �Լ��� ������.
        byte[] bytes = Encoding.Default.GetBytes(text);     // string �� byte �迭�� ��ȯ�� ��
        return Encoding.UTF8.GetString(bytes);              // ���ڵ��� UTF8�� �ٲ۴�.
    }
}
