using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemlistk : MonoBehaviour {
    public GameObject gantanhao;
    tagStr TagStr;
    public GameObject ShopInfo;//商店
	// Use this for initialization
	void Start () {
           DateMgr.GetInstance();
        if (gameObject.tag=="Untagged")
            gameObject.tag = gameObject.name;//添加标签，将将要添加的标签提前设置为和当前NPC名字相同
    }
    /// <summary>
    /// 显示提示按钮，关闭
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            TagStr = (tagStr)Enum.Parse(typeof(tagStr),gameObject.name);
            gantanhao.gameObject.SetActive(true);
            gantanhao.GetComponent<Button>().onClick.AddListener(OpenShop);
            RWManager.action(gameObject.tag);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TagStr = tagStr.Null;
            gantanhao.gameObject.SetActive(false);
            gantanhao.GetComponent<Button>().onClick.RemoveAllListeners();
            //初始化
            ShopInfo.transform.GetComponent<UIManager>().itemid = null;
            ShopInfo.transform.GetChild(0).GetChild(0).DestroyChildren();
            key = true;
            K = 0;
            for (int i = 0; i < ShopInfo.transform.parent.childCount; i++)
            {
                if (ShopInfo.transform.parent.GetChild(i).gameObject.activeSelf)
                {
                    ShopInfo.transform.parent.GetChild(i).gameObject.SetActive(false);
                }
                
            }
        }
    }
    int K = 0;
    bool key = true;
    void OpenShop() {
        if (K % 2 == 0)
        {
            ShopInfo.SetActive(true);
            if (key) {  //可以写为委托
                switch (TagStr)
                {
                    case tagStr.Weapon_Npc:
                        ShopInfo.GetComponent<UIManager>().itemid = DateMgr.GetInstance().item_Weapon_set.ToArray();
                        break;
                    case tagStr.Potion_Npc:
                        ShopInfo.GetComponent<UIManager>().itemid = DateMgr.GetInstance().item_Potion_set.ToArray();
                        break;
                };
                key = false;
                ShopInfo.GetComponent<UIManager>().ShowShop();
            };
        }
        else
            for (int i = 0; i < ShopInfo.transform.parent.childCount; i++)//写法有点麻烦
            {
                if (ShopInfo.transform.parent.GetChild(i).gameObject.activeSelf)
                {
                    ShopInfo.transform.parent.GetChild(i).gameObject.SetActive(false);
                }

            }
        K++;
    }
    //触发事件响应后所必须要执行的委托的方法
    public void ShowTip(bool self,List<int> goodsList) {

        //按钮.gameObject.setActive（self）;
        if (self)
        {
            //对按钮添加加监听事件，打开商店界面，并且对商店列表赋值
            //如果用UI框架时，就将goodlist作为参数传入，格式为TTUIPage.ShowPage<ShopPanel>（goodList）
        }
        else {
            //关闭商店，或用TTUIPage.ClosPage<ShowPanel>()
            //此时应先将按钮上添加的监听事件删除避免下次调用委托时重复添加
        }

    }
}
