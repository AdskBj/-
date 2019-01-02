using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DateMgr {
    public enum Equipment_Type
    {
        Null = 0, Head_Gear = 1, Armor = 2, Shoes = 3, Accessory = 4, Left_Hand = 5, Right_Hand = 6, Two_Hand = 7
    }


    public List<Item> item_equipment_set = new List<Item>();
    public List<int> item_Weapon_set = new List<int>();
    public List<int> item_Potion_set = new List<int>();

    private static DateMgr instance;

    private DateMgr() {
        TextAsset ta = Resources.Load("Data/ITemData") as TextAsset;
        item_equipment_set = JsonConvert.DeserializeObject<List<Item>>(ta.text);
        for (int i = 0; i < item_equipment_set.Count; i++)
        {
            Item item = item_equipment_set[i];
            string type = item.item_Type.ToString();
            if (type != "Potion"&&type != "Etc" && item.item_Name != "金币")
            {
                if (item.price != 0)
                    item_Weapon_set.Add(item.item_ID);
            }
            else {
                if (type=="Potion")
                {
                    item_Potion_set.Add(item.item_ID);
                }
            }
        }
    }
    public Item GetItemByID(int _ID) {
        return item_equipment_set.Find((Item item) => {
             if (item.item_ID == _ID)
                 return true;
             else
                 return false;
         });

    }
    public static DateMgr GetInstance() {
        if (instance != null)
        {
            return instance;
        }
        else
        {
            return instance = new DateMgr();
        }
    }
    [System.Serializable]
    public class Item
    {
        public string item_Name = "Item Name";
        public string item_Type = "Item Type";
        [Multiline]
        public string description = "Description Here";
        public int item_ID;
        public string item_Img;//图片名
        public string item_Effect;//特效名
        public string item_Sfx;//音效名
        public Equipment_Type equipment_Type;
        public int price;
        public int hp, mp, atk, def, spd, hit;
        public float criPercent, atkSpd, atkRange, moveSpd;
    }
   
}
