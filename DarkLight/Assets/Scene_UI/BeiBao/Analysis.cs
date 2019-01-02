using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
/// <summary>
/// 解析数据
/// </summary>
public class Analysis : MonoBehaviour {

	void Awake () {
        // 用户数据解析
        UserAnalysis();
        // 物品数据解析
        GoodsAnalysis();
        ZBAnalysis();
        RareZBAnalysis();
        TaskAnalysis();
        UserTaskAnalysis();

    }
    /// <summary>
    /// 用户数据解析
    /// </summary>
	void UserAnalysis()
    {
        TextAsset u = Resources.Load("Setting/UserJson") as TextAsset;
        if (!u)
        {
            return;
        }
        Save.UserList1 = JsonConvert.DeserializeObject<List<UserModel>>(u.text);
        print(u.text);
    }

    /// <summary>
    /// 物品数据解析
    /// </summary>
    void GoodsAnalysis()
    {
        TextAsset g = Resources.Load("Setting/GoodsList") as TextAsset;
        if (!g)
        {
            return;
        }
        Save.GoodsList1= JsonConvert.DeserializeObject<List<GoodsModel>>(g.text);
        print(g.text);
    }
    void ZBAnalysis()
    {
        TextAsset g = Resources.Load("Setting/ZBList") as TextAsset;
        if (!g||g.ToString()=="")
        {
            return;
        }
        Save.ZBList1 = JsonConvert.DeserializeObject<List<DateMgr.Item>>(g.text);
        print(g.text);
    }
    void RareZBAnalysis()
    {
        TextAsset g = Resources.Load("Setting/RareZBList") as TextAsset;
        if (!g || g.ToString() == "")
        {
            return;
        }
        RareWeapon.RareWeaponList = JsonConvert.DeserializeObject<List<PeiFang>>(g.text);
        print(g.text);
    }
    void TaskAnalysis()
    {
        TextAsset g = Resources.Load("Setting/TaskList") as TextAsset;
        if (!g||g.ToString() == "")
        {
            return;
        }
        TaskList.AllTask = JsonConvert.DeserializeObject<List<Task>>(g.text);
        print(g.text);
    }
    void UserTaskAnalysis()
    {
        TextAsset g = Resources.Load("Setting/UserTaskList") as TextAsset;
        if (!g||g.ToString() == "")
        {
            return;
        }
        TaskList.UserTask = JsonConvert.DeserializeObject<List<Task>>(g.text);
        print(g.text);
    }
}
