using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/// <summary>
/// 挂载在商品预设物上  
/// </summary>
public class BagItemButton : MonoBehaviour {
    //当前物品
    public DateMgr.Item CurrentGoods;
    //选中物品的Id
    public static int BagGoodsId;
    //物品信息显示框
    GameObject GoodsInfo;
    // Use this for initialization
     void Start()
    {
        GoodsInfo = transform.root.Find("UITopbar/Player_BB").transform.Find("ShowInfo").gameObject;
        transform.GetComponent<Button>().onClick.AddListener(Show);
    }
    public  void  Show()
    {
                   
        GoodsInfo.transform.gameObject.SetActive(true);
        GoodsInfo.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("PicTWo/" + CurrentGoods.item_Img.ToString());
        GoodsInfo.transform.GetChild(1).GetComponent<Text>().text = CurrentGoods.item_Name;
        if (Save.ZBList1!=null&& Save.ZBList1.Exists(t => t.equipment_Type == CurrentGoods.equipment_Type))
            GoodsInfo.transform.GetChild(2).GetComponent<Text>().text = "介绍：" + CurrentGoods.description+"\n已经存在该类物品是否使用替换？";
        else
        GoodsInfo.transform.GetChild(2).GetComponent<Text>().text = "介绍："+ CurrentGoods.description;
        BagGoodsId = CurrentGoods.item_ID;
    }
}
