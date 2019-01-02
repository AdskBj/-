using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItemBtn : MonoBehaviour {

    public Task task;//当前任务
    public bool newOrOld;//标记该任务是未接受的任务还是接受过了
    RWManager rWManager;
     void Start()
    {
        Transform tran1 = transform.GetChild(4),tran2= transform.GetChild(3);
        rWManager = transform.root.GetChild(0).Find("Player_RW").GetComponent<RWManager>();
        if (!newOrOld)
        {
            tran2.gameObject.SetActive(false);
            if (task.requiementNum == TaskList.AllTask.Find((t) => t.ID == task.ID).requiementNum)
            {
                tran1.GetChild(0).GetComponent<Text>().text = "完成";
                tran1.GetComponent<Button>().onClick.AddListener(TaskPlanBtnClick2);
            }
            else
                tran1.GetComponent<Button>().onClick.AddListener(TaskPlanBtnClick3);
        }
        else
        {
            tran2.GetComponent<Button>().onClick.AddListener(TaskPlanBtnClick1);
            tran1.GetComponent<Button>().onClick.AddListener(TaskPlanBtnClick3);
        }

    }
    /// <summary>
    /// 任务面板按钮响应
    /// </summary>
    public void TaskPlanBtnClick1()//接受
    {
        Task task2 = new Task();
        task2.ID = task.ID;
        task2.description = task.description;
        task2.requirementIDorTag = task.requirementIDorTag;
        task2.requiementNum = 0;
        task2.GoodsID = task.GoodsID;
        task2.GoodsNum = task.GoodsNum;
        task2.rWState = task.rWState;
        TaskList.UserTask.Add(task2);
        TaskList.AllTask.Find((T)=>T.ID==task.ID).rWState=RWState.C;
        rWManager.RWShow();
    }
    public void TaskPlanBtnClick2()//完成
    {
        Save.BuyItem(DateMgr.GetInstance().GetItemByID(task.GoodsID));
        Save.GoodsList1.Find((G)=>G.Id==task.GoodsID).Num+=(task.GoodsNum-1);
        TaskList.AllTask.Find((T) => T.ID == task.ID).rWState = RWState.A;
        TaskList.UserTask.RemoveAt(TaskList.UserTask.FindIndex((T)=>T.ID==task.ID));
        //刷新
        rWManager.RWShow();
    }
    public void TaskPlanBtnClick3()//放弃
    {
        TaskList.AllTask.Find((T) => T.ID == task.ID).rWState = RWState.D;
        TaskList.UserTask.RemoveAt(TaskList.UserTask.FindIndex((T) => T.ID == task.ID));
        //刷新
        rWManager.RWShow();
    }
}
