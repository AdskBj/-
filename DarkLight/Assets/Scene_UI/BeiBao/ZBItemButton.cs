using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/// <summary>
/// 挂载在商品预设物上  
/// </summary>
public class ZBItemButton : MonoBehaviour {
    //当前物品
    public DateMgr.Item ZB;
    //物品信息显示框
    GameObject ZBInfo;
    public static ZBItemButton thisButton;
    // Use this for initialization
     void Start()
    {
        ZBInfo = transform.root.Find("UITopbar/Player_ZB").transform.Find("ZBInfo").gameObject;
        transform.GetComponent<Button>().onClick.AddListener(Show);
    }
    public  void  Show()
    {
        if (ZB!=null)
        {
            ZBInfo.transform.gameObject.SetActive(true);
            ZBInfo.transform.GetChild(0).GetComponent<Text>().text = ZB.item_Name;
            ZBInfo.transform.GetChild(1).GetComponent<Text>().text = "介绍：" + ZB.description;
            Vector3 vector;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle((ZBInfo.transform.root) as RectTransform,Input.mousePosition,GameObject.Find("Main Camera").GetComponent<Camera>(),out vector))
            {
                ZBInfo.transform.position = vector;
            }
            thisButton = this;
        }
       
    }

}
