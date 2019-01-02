using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEditor;

public class UserModel {
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public float Spd;
    public int Hit;
    public float CriPercent;
    public float AtkSpd;
    public int Gold;
}
public class GoodsModel //背包信息
{
    public int Id;
    public int Num;//数量
}
public  class Save
{
    private static List<UserModel> UserList = new List<UserModel>();
    private static List<GoodsModel> GoodsList=new List<GoodsModel>();
    private static List<DateMgr.Item> ZBList = new List<DateMgr.Item>();
    public static List<UserModel> UserList1
    {
        get
        {
            return UserList;
        }

        set
        {
            UserList = value;
        }
    }
    public static List<GoodsModel> GoodsList1
    {
        get
        {
            return GoodsList;
        }

        set
        {
            GoodsList = value;
        }
    }
    public static List<DateMgr.Item> ZBList1
    {
        get
        {
            return ZBList;
        }

        set
        {
            ZBList = value;
        }
    }

    /// <summary>
    /// 点击保存按钮
    /// </summary>
    public void SaveBtnClick()//暂时绑定至点击设置按钮后弹出页面
    {
        using (StreamWriter sw = (new FileInfo(Application.dataPath+"/Resources/Setting/UserJson.json")).CreateText()) {
            string json = JsonConvert.SerializeObject(UserList1);//保存用户信息
            sw.Write(json);
        }
        AssetDatabase.Refresh();
        using (StreamWriter sw = (new FileInfo(Application.dataPath + "/Resources/Setting/GoodsList.json")).CreateText())
        {
            string json = JsonConvert.SerializeObject(GoodsList1);//保存背包信息
            sw.Write(json);
        }
        AssetDatabase.Refresh();
        using (StreamWriter sw = (new FileInfo(Application.dataPath + "/Resources/Setting/ZBList.json")).CreateText())
        {
            string json = JsonConvert.SerializeObject(ZBList1);//保存背包信息
            sw.Write(json);
        }
        AssetDatabase.Refresh();
        using (StreamWriter sw = (new FileInfo(Application.dataPath + "/Resources/Setting/TaskList.json")).CreateText())
        {
            string json = JsonConvert.SerializeObject(TaskList.AllTask);//保存背包信息
            sw.Write(json);
        }
        AssetDatabase.Refresh();
        using (StreamWriter sw = (new FileInfo(Application.dataPath + "/Resources/Setting/UserTaskList.json")).CreateText())
        {
            string json = JsonConvert.SerializeObject(TaskList.UserTask);//保存背包信息
            sw.Write(json);
        }
        AssetDatabase.Refresh();
        Debug.Log("保存成功");
    }

    public static void BuyItem(DateMgr.Item _Item) {//购买物品

        if (GoodsList1==null)
        {
            GoodsList1 = new List<GoodsModel>();
        }
       GoodsModel gm = GoodsList1.Find(x=>x.Id==_Item.item_ID);
        if (gm != null)
            gm.Num += 1;
        else
            GoodsList1.Add(new GoodsModel() {Id=_Item.item_ID,Num=1 });


}
}

