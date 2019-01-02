using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 挂载在商品预设物上  
/// </summary>
public class ItemButton : MonoBehaviour {
    //当前物品的图片
    public UnityEngine.Sprite Sprite;
    //当前物品
    public DateMgr.Item CurrentGoods;
    //选中物品的Id
    public static int CurrentGoodsId;
    //物品信息显示框
    public   GameObject GoodsInfo;
    GameObject XinXi;
    // Use this for initialization
     void Start()
    {
        GoodsInfo = transform.root.Find("Shoop").transform.Find("ShowInfo").gameObject;
        XinXi = transform.root.Find("Shoop").transform.Find("XinXi").gameObject;
        transform.GetComponent<Button>().onClick.AddListener(Show);
    }
    public  void  Show()
    {
        if (!GoodsInfo.activeSelf)
        {
            GoodsInfo.gameObject.SetActive(true);
            GoodsInfo.transform.GetChild(0).GetComponent<Image>().sprite = Sprite;
            GoodsInfo.transform.GetChild(1).GetComponent<Text>().text = CurrentGoods.item_Name;
            GoodsInfo.transform.GetChild(2).GetComponent<Text>().text = "购买需要" + CurrentGoods.price + "金币。/n确定吗？";
            CurrentGoodsId = CurrentGoods.item_ID;
        }
        
    }
    public void ShowXinXi() {
        if (!GoodsInfo.activeSelf)
        {
            XinXi.gameObject.SetActive(true);
            XinXi.transform.GetChild(0).GetComponent<Text>().text = CurrentGoods.item_Name;
            XinXi.transform.GetChild(1).GetComponent<Text>().text = "简介：" + CurrentGoods.description + "\n售价：" + CurrentGoods.price;
        }
    }

}
