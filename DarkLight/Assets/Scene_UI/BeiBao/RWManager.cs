using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RWManager : MonoBehaviour {
    public GameObject Prefab;
    public GameObject ContentK;
    public static Action<string> action;
    /// <summary>
    /// 更新任务面板
    /// </summary>
    private void Start()
    {
        action = UpdateUserTaskData;
    }
    public void RWShow() {
        Close();
        List<Task> task = TaskList.UserTask??new List<Task>();
        for (int i = 0; i < task.Count; i++)
        {
            GameObject OneTAsk = Instantiate(Prefab, ContentK.transform);
            OneTAsk.transform.GetChild(0).GetComponent<Text>().text = task[i].ID.ToString();
            OneTAsk.transform.GetChild(1).GetComponent<Text>().text = task[i].description+"\n奖励："+DateMgr.GetInstance().GetItemByID(task[i].GoodsID).item_Name + "X" + task[i].GoodsNum;
            int num1 = task[i].requiementNum;
            int num2 = TaskList.AllTask.Find((k) => k.ID == task[i].ID).requiementNum;
            OneTAsk.transform.GetChild(2).GetComponent<Text>().text = num1.ToString() + "/" + num2.ToString();
            OneTAsk.transform.GetChild(3).gameObject.SetActive(false);
            OneTAsk.GetComponent<TaskItemBtn>().task = task[i];
            OneTAsk.GetComponent<TaskItemBtn>().newOrOld = false;
        }
        if (5-task.Count>0)
        {
            List<Task> task2 = TaskList.AllTask;
            int Index = 0;
            for (int i =0 ;i< 5 - task.Count; i++)
            {
                    Index = (Index == 0 ?Index= task2.FindIndex((K) => K.rWState == RWState.B):Index);/**/
                    Task TwoTask =task2[Index]; /*task.Find((k) => k.ID == RWthisID);*/
                    GameObject OneTAsk = Instantiate(Prefab, ContentK.transform);
                    OneTAsk.transform.GetChild(0).GetComponent<Text>().text = TwoTask.ID.ToString();
                    OneTAsk.transform.GetChild(1).GetComponent<Text>().text = TwoTask.description + "\n奖励：" + DateMgr.GetInstance().GetItemByID(TwoTask.GoodsID).item_Name+"X"+ TwoTask.GoodsNum;
                    int num1 = 0;
                    int num2 = TwoTask.requiementNum;
                    OneTAsk.transform.GetChild(2).GetComponent<Text>().text = num1.ToString() + "/" + num2.ToString();
                    OneTAsk.GetComponent<TaskItemBtn>().task = TwoTask;
                    OneTAsk.GetComponent<TaskItemBtn>().newOrOld = true;
                    Index++;
            }
            Index = 0;
        }
    }
    /// <summary>
    /// 更新当前任务数据
    /// </summary>
    /// <param name="rWType"></param>
    public  void  UpdateUserTaskData(string IDorName) {//无法识别相同要求的任务
                Task task = TaskList.UserTask.Find((T) => T.requirementIDorTag == IDorName);
                if (task!=null&&task.requiementNum<TaskList.AllTask.Find((T)=>T.ID==task.ID).requiementNum)
                 task.requiementNum+=1;
        if (gameObject.activeSelf)
        {
            RWShow();
        }
    }
    void Close() {
        ContentK.transform.DestroyChildren();
    }
}

