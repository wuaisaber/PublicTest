using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour {
    private List<ShopItemData1> m_ShopItemDatas = new List<ShopItemData1>();

    public UIGrid m_Gride;
    public GameObject m_ItemGo;

    public int selectId;
	void Start () {
        
        ShowItems();
	}

    public void ShowItems() {
        m_ShopItemDatas = ShopDataManager.Instance.GetShopItemDatas();
        int childCount = m_Gride.transform.childCount; // 1   

        for (int i = 0; i < m_ShopItemDatas.Count; i++)//  4
        {
            GameObject go = null; // i = 1
            if (i < childCount)
            {
                go = m_Gride.transform.GetChild(i).gameObject;
            }
            else
            {
                go = GameObject.Instantiate(m_ItemGo) as GameObject;
                go.transform.parent = m_Gride.transform;
                go.transform.localScale = Vector3.one;
            }
            go.SetActive(true);
            go.name = m_ShopItemDatas[i].m_data.ID.ToString();
            GameObject childIcon = go.transform.Find("ItemIcon").gameObject;
            if (childIcon)
            {
                UISprite icon = childIcon.GetComponent<UISprite>();
                icon.spriteName = m_ShopItemDatas[i].m_data.Icon;
            }
            GameObject childFlag = go.transform.Find("flag").gameObject;
            if (childFlag)
            {
                childFlag.SetActive(m_ShopItemDatas[i].isSell);
            }
            
        }
        //子物体数量  ：5    数据 ：4
        for (int i = m_ShopItemDatas.Count; i < childCount; i++)
        {
            GameObject go = m_Gride.transform.GetChild(i).gameObject;
            go.SetActive(false);
        }

        m_Gride.Reposition();
    }

    public void Click(GameObject go)
    {

        Debug.Log("点击了按钮:" + go.name);
        //left_icon.spriteName = go.name;
        //left_nameLabel.text = "";
        selectId = System.Int32.Parse(go.name);
    }

    public void ClickBuy() { 
        //TODO Manage更新数据
        //todo刷新显示数据
        ShowItems();
    }

	void Update () {
	
	}
}

//public class ShopItem2 { 
    
//}

public class ShopItemInfo
{
    public UISprite icon;
    public UILabel nameLabel;
    public UILabel infoLabel;
    public UILabel priceLabel;

    public GameObject leftPanel;
    public ItemData data;
    //初始化，传进来左边界面GameObject，根据这个GO来查找相应组件
    public void Init(GameObject left)
    {

        leftPanel = left;

        Transform icon_go = left.transform.Find("icon");
        if (icon_go)
        {
            icon = icon_go.GetComponent<UISprite>();
        }

        Transform nameLabel_go = left.transform.Find("ItemNameLbl");
        if (nameLabel_go)
        {
            nameLabel = nameLabel_go.GetComponent<UILabel>();
        }
    }

    //得到组件之后根据传进来的数据进行刷新界面
    public void ShowInfo(int id)
    {
        //data = DataManager.s_ItemDataManager.GetData(id);
        data = InventoryItemDataManager.Instance.GetItemDataById(id);
        if (data == null)
        {

        }
        icon.spriteName = data.Icon;
        nameLabel.text = data.Name;
    }

}