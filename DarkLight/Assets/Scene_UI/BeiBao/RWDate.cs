using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务类型A：买东西B：打怪C：NPC名字
/// </summary>
public enum RWType { A, B, C };
/// <summary>
/// 任务完成状态A：完成 B：未完成 C：已接受 D：放弃
/// </summary>
public enum RWState { A, B, C,D };
public class Task
{
    public int ID;
    public string description;
    public string requirementIDorTag;/*条件ID或标签*/
    public int requiementNum;
    public RWState rWState;
    public int GoodsID;
    public int GoodsNum;
}
public class TaskList {
    public static List<Task> AllTask = new List<Task>();
    public static List<Task> UserTask = new List<Task>();
}