using UnityEngine;
using System.Collections;
/// <summary>
/// 属性
/// </summary>
public class Nature : MonoBehaviour {
    public static Nature Instance;
    public int Hp, MaxHp, Attack, Speed;
    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        AssigNature();// 给属性赋值
    }
    /// <summary>
    /// 给属性赋值  assig分配，任务，作业，功课
    /// </summary>
    void AssigNature()
    {
        Hp = Save.UserList1[0].Hp;
        //MaxHp = Save.UserList1[0].MaxHp;
        //Attack = Save.UserList1[0].Attack;
        //Speed = Save.UserList1[0].Speed;
    }
    /// <summary>
    /// 吃药的方法
    /// 使用物品后 属性改变
    /// </summary>
	public  void Eat()
    {
        Save.UserList1[0].Hp = Hp;
        //Save.UserList1[0].MaxHp = MaxHp;
        //Save.UserList1[0].Attack = Attack;
        //Save.UserList1[0].Speed = Speed;
       
    }
}
