using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public Text hp,mp,atk,def,spd,hit,crip,atkspd;
    public GameObject GoodsPrefab;//物品预设物
    public GameObject BG;//禁止按钮
    public GameObject ShowInfo;//显示信息
    public GameObject ZBInfo;
    public Transform Grid;//背包空格
    public GameObject[] ZhuangBei;
    public GameObject MapCamera,RWPlan;
    void Start()
    {

        for (int i = 0; i <transform.childCount; i++)
        { GameObject G = transform.GetChild(i).gameObject;
            if (G.name == "Player_TX") { G.SetActive(true);continue; };
            if (G.activeSelf) G.SetActive(false);
        }
    }
    public void RWPlanClick() {
        if (!RWPlan.activeSelf)
        {
            RWPlan.SetActive(true);
            RWPlan.GetComponent<RWManager>().RWShow();
        }
        else
            RWPlan.SetActive(false);
    }
    /// <summary>
    /// 属性按钮(需简化)
    /// </summary>
    public void SXBtnClick()
    {
        BG.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(3).GetChild(4).gameObject.GetComponent<Button>().onClick.AddListener(()=> { new Save().SaveBtnClick();});
        ShowSS();
    }
    public void SXExitBtnClick()
    {
        BG.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(3).GetChild(4).gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }
    /// <summary>
    /// 点击背包按钮
    /// </summary>
    public void BagBtnClick()
    {
        BG.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        ShowBag();
    }
    public void BagExitBtnClick()
    {
        BG.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        Transform Co = Grid.GetChild(0);
        for (int i = Co.childCount-1; i >-1 ; i--)
        {
            Transform Ch = Co.GetChild(i);
            Ch.parent = null;
            Destroy(Ch.gameObject);
        }
       // Grid.GetChild(0).DestroyChildren();//与上等同
    }
    /// <summary>
    /// 装备界面
    /// </summary>
    public void ZBBtnClick()
    {
        BG.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
        ShowZB();
    }
    public void ZBExitBtnClick()
    {
        BG.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
    }
    /// <summary>
    ///一个卸载装备的方法，卸载完成装备进入背包，ZB=null，并且
    /// </summary>
    public void ZBTipClick() {
        DateMgr.Item item = ZBItemButton.thisButton.ZB;
        Save.BuyItem(item);
        for (int i = 0; i < Save.ZBList1.Count; i++)
        {
            if (Save.ZBList1[i] == item)
            {
                UserModel user = Save.UserList1[0];
                DateMgr.Item it= Save.ZBList1[i];
                user.Hp = user.Hp -  it.hp;
                user.Mp = user.Mp -  it.mp;
                user.Atk = user.Atk -  it.atk;
                user.Def = user.Def -  it.def;
                user.Spd = user.Spd -  it.spd;
                user.Hit = user.Hit -  it.hit;
                user.CriPercent = user.CriPercent -  it.criPercent;
                user.AtkSpd = user.AtkSpd -  it.atkSpd;
                Save.ZBList1.RemoveAt(i);
            }
                

        }
        ZBItemButton.thisButton.ZB = null;
        ZBInfo.gameObject.SetActive(false);
        ShowZB();
    }
    /// <summary>
    /// 一个退出装备弹窗的按钮
    /// </summary>
    public void ZBTipExitBtnClick() {
        ZBInfo.gameObject.SetActive(false);
    }
    /// <summary>
    /// 显示背包数据
    /// </summary>
    public void ShowBag()
    {
        //遍历物品信息
        foreach (GoodsModel item in Save.GoodsList1)
        {
            if (item.Num != 0)//物品数量不等于零时
            {
                GameObject go = Instantiate(GoodsPrefab, Grid.Find("Content"));
                //显示物体的图片及数量
                DateMgr.Item I = DateMgr.GetInstance().GetItemByID(item.Id);
                go.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<UnityEngine.Sprite>("PicTWo/" + I.item_Img.ToString());
                go.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = item.Num + "";
                go.transform.GetChild(0).GetComponent<BagItemButton>().CurrentGoods = I;
            }
        }

    }
    /// <summary>
    /// 刷新装备界面
    /// </summary>
    public void ShowZB()
    {
        foreach (var item in ZhuangBei)
        {
            DateMgr.Item mgr= Save.ZBList1.Find((i) => i.equipment_Type == (DateMgr.Equipment_Type)System.Enum.Parse(typeof(DateMgr.Equipment_Type), item.name));
            if (mgr != null)
            {
                item.GetComponent<Image>().sprite = Resources.Load<Sprite>("PicTWo/" + mgr.item_Img.ToString());
                item.GetComponent<ZBItemButton>().ZB = mgr;
            }
            else
            {
                item.GetComponent<Image>().sprite = null;
                item.GetComponent<ZBItemButton>().ZB = null;
            }
        }
    }
    /// <summary>
    /// 刷新属性界面
    /// </summary>
    public void ShowSS()
    {
        UserModel userModel = Save.UserList1[0];
        hp.text =userModel.Hp.ToString();
        mp.text = userModel.Mp.ToString();
        atk.text = userModel.Atk.ToString();
        def.text = userModel.Def.ToString();
        spd.text = userModel.Spd.ToString();
        hit.text = userModel.Hit.ToString();
        crip.text = userModel.CriPercent.ToString();
        atkspd.text = userModel.AtkSpd.ToString();
    }
    /// <summary>
    ///提示框的返回按钮
    /// </summary>
    public void BBShowInfo_BackBtnClick()
    {
       ShowInfo.SetActive(false);
    }
    /// <summary>
    /// 提示框中的使用物品按钮方法(未测试具体状况未知)
    /// </summary>
   public void BBShowInfo_UseGoods() 
    {
        int id = BagItemButton.BagGoodsId;
        DateMgr.Item it = DateMgr.GetInstance().GetItemByID(id);
        //使用物品  类型
        GoodsType type = (GoodsType)System.Enum.Parse(typeof(GoodsType),it.item_Type);
        UserModel user = Save.UserList1[0];
        DateMgr.Item itemK=null;
        if (Save.ZBList1!=null)
        {
            itemK = Save.ZBList1.Find((t) => t.equipment_Type == it.equipment_Type);//找到装备栏中类型相同的装备
        }
        switch (type)
        {
            case GoodsType.Potion:
                user.Hp += it.hp;
                user.Mp += it.mp;
                break;
            default:
                if (itemK != null)
                    Add1(itemK, user, it, id);
                else
                    Add2(user,it,id);
                break;
        }
        BBCloses();
        //刷新背包界面数据
        ShowInfo.SetActive(false);
        ShowBag();
        
    }
    void Add1(DateMgr.Item itemK,UserModel user, DateMgr.Item it,int id) {
        user.Hp = user.Hp - itemK.hp + it.hp;
        user.Mp = user.Mp - itemK.mp + it.mp;
        user.Atk = user.Atk - itemK.atk + it.atk;
        user.Def = user.Def - itemK.def + it.def;
        user.Spd = user.Spd - itemK.spd + it.spd;
        user.Hit = user.Hit - itemK.hit + it.hit;
        user.CriPercent = user.CriPercent - itemK.criPercent + it.criPercent;
        user.AtkSpd = user.AtkSpd - itemK.atkSpd + it.atkSpd;
        Save.BuyItem(itemK);
        itemK = it;
        Save.GoodsList1.Find((i) => i.Id == id).Num -= 1;
    }
    void Add2( UserModel user, DateMgr.Item it, int id) {
        user.Hp += it.hp;
        user.Mp += it.mp;
        user.Atk += it.atk;
        user.Def += it.def;
        user.Spd += it.spd;
        user.Hit +=  it.hit;
        user.CriPercent += it.criPercent;
        user.AtkSpd += it.atkSpd;
        Save.ZBList1.Add(it);
        Save.GoodsList1.Find((i) => i.Id == id).Num -= 1;
    }
    /// <summary>
    /// 背包清空
    /// </summary>
    void BBCloses() {
        Grid.GetChild(0).DestroyChildren();
    }
    /// <summary>
    /// 地图控制
    /// </summary>
    public void AddMapSize() {
        if (MapCamera.GetComponent<Camera>().orthographicSize<6)
        {
            MapCamera.GetComponent<Camera>().orthographicSize += 0.1f;
        }
        
    }
    public void AbateMapSize() {
        if (MapCamera.GetComponent<Camera>().orthographicSize >= 4)
        {
            MapCamera.GetComponent<Camera>().orthographicSize -= 0.1f;
        }
    }
}
enum GoodsType {Potion,Weapon,Armor,Shoes,Shield,Accessory };
