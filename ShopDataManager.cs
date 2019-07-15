using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopDataManager
{
    private static ShopDataManager _Instance;
    public static ShopDataManager Instance
    {
        get
        {
            if (_Instance == null) {
                _Instance = new ShopDataManager();
            }
            return _Instance;
        }
    }
    private List<ShopItemData1> m_ShopItemDataList = new List<ShopItemData1>();
    public List<ShopItemData1> GetShopItemDatas()
    {
        m_ShopItemDataList.Clear();

        ShopItemData1 shopData1 = new ShopItemData1();
        ItemData data = DataManager.s_ItemDataManager.GetData(10001);
        shopData1.m_data = data;
        shopData1.isSell = false;
        m_ShopItemDataList.Add(shopData1);

        ShopItemData1 shopData2 = new ShopItemData1();
        data = DataManager.s_ItemDataManager.GetData(10002);
        shopData2.m_data = data;
        shopData2.isSell = false;
        m_ShopItemDataList.Add(shopData2);

        ShopItemData1 shopData3 = new ShopItemData1();
        data = DataManager.s_ItemDataManager.GetData(10003);
        shopData3.m_data = data;
        shopData3.isSell = false;
        m_ShopItemDataList.Add(shopData3);

        ShopItemData1 shopData4 = new ShopItemData1();
        data = DataManager.s_ItemDataManager.GetData(10004);
        shopData4.m_data = data;
        shopData4.isSell = false;
        m_ShopItemDataList.Add(shopData4);

        return m_ShopItemDataList;
    }

    public ShopItemData GetDataById() {
        //todo 根据id获取相应数据
        return null;
    }

    public List<ShopItemData1> BuyItemById(int id) {
       //TODO 处理id的物品
        return m_ShopItemDataList;
    }
}

public class ShopItemData1 {
    public ItemData m_data;
    public bool isSell;
}