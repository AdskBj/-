using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using UnityEditor;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GoodsPrefab;//物品预设物
    public ToggleGroup toggelGroup;
    public GameObject Shop;//背包显示
    public GameObject ShowInfo;//显示信息
    public Transform Grid;//背包空格
    public GameObject[] GridArray;
    public int[] itemid;
    /// <summary>
    /// 显示商店数据
    /// </summary>
    public void ShowShop()//刷新商店界面
    {
        //遍历物品信息
        int j = 0;
        DateMgr dateMgr = DateMgr.GetInstance();
       
        foreach (int items in itemid)
        {
                DateMgr.Item item = DateMgr.GetInstance().GetItemByID(items);
                GameObject go = Instantiate(GoodsPrefab, Grid.Find("Content"));
                UnityEngine.Sprite S = Resources.Load("PicTWo/" + item.item_Img.ToString(), typeof(UnityEngine.Sprite)) as UnityEngine.Sprite;
                ItemButton IB = go.transform.GetChild(0).GetComponent<ItemButton>();
                go.transform.GetChild(1).GetComponent<Image>().sprite = S;
                go.transform.GetChild(2).GetComponent<Text>().text = item.description + "\n售价:" + item.price;
                go.transform.GetChild(3).GetComponent<Toggle>().group = toggelGroup;
                IB.Sprite = S;
                IB.CurrentGoods = item;
                j++;
        }
    }
    /// <summary>
    ///提示框的返回按钮
    /// </summary>
    public void ShowInfo_BackBtnClick()
    {
        ShowInfo.transform.GetChild(0).gameObject.SetActive(true);
        ShowInfo.transform.GetChild(3).gameObject.SetActive(true);
        ShowInfo.transform.GetChild(4).gameObject.SetActive(true);
        ShowInfo.transform.GetChild(5).gameObject.SetActive(false);
        ShowInfo.SetActive(false);
    }
    //当前使用的物品
   public void ShowInfo_BuyBtnGoods()//绑定至购买按钮
    {
        if (Save.UserList1[0].Gold >= DateMgr.GetInstance().GetItemByID(ItemButton.CurrentGoodsId).price)
        {
            Save.BuyItem(DateMgr.GetInstance().GetItemByID(ItemButton.CurrentGoodsId));
            Save.UserList1[0].Gold -= DateMgr.GetInstance().GetItemByID(ItemButton.CurrentGoodsId).price;
            ShowInfo.transform.GetChild(0).gameObject.SetActive(false);
            ShowInfo.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Tip";
            ShowInfo.transform.GetChild(2).gameObject.GetComponent<Text>().text = "购买成功！！！";
            ShowInfo.transform.GetChild(3).gameObject.SetActive(false);
            ShowInfo.transform.GetChild(4).gameObject.SetActive(false);
            ShowInfo.transform.GetChild(5).gameObject.SetActive(true);
            RWManager.action(ItemButton.CurrentGoodsId.ToString());
        }
        else
        {
            ShowInfo.transform.GetChild(0).gameObject.SetActive(false);
            ShowInfo.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Tip";
            ShowInfo.transform.GetChild(2).gameObject.GetComponent<Text>().text = "购买失败！！！";
            ShowInfo.transform.GetChild(3).gameObject.SetActive(false);
            ShowInfo.transform.GetChild(4).gameObject.SetActive(false);
            ShowInfo.transform.GetChild(5).gameObject.SetActive(true);

        }
    }
}
public enum tagStr { Weapon_Npc, Potion_Npc,Null }