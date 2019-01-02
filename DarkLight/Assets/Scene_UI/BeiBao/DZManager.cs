using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DZManager : MonoBehaviour {
    public Dropdown dropdown;
    public Image ima1, ima2,Zd;
    public Text text1, text2;
    public GameObject TipPlan;
            PeiFang peiFang; 
    public  void ShowDZ() {
        if (dropdown.value == 0)
            return;
        peiFang= RareWeapon.RareWeaponList[dropdown.value-1];
        ima1.sprite = Resources.Load<Sprite>("PicTWo/"+DateMgr.GetInstance().GetItemByID(peiFang.EtcID1).item_Img.ToString());
        ima2.sprite = Resources.Load<Sprite>("PicTWo/" + DateMgr.GetInstance().GetItemByID(peiFang.EtcID2).item_Img.ToString());
        GoodsModel a = Save.GoodsList1.Find((i) => peiFang.EtcID1 == i.Id)??new GoodsModel();
        GoodsModel b = Save.GoodsList1.Find((i) => peiFang.EtcID2 == i.Id)??new GoodsModel();
        text1.text = a.Num + "/" + peiFang.Etc1Num;
        text2.text = b.Num + "/" + peiFang.Etc2Num;

        if (a.Num >= peiFang.Etc1Num && b.Num >= peiFang.Etc2Num)
            Zd.gameObject.SetActive(false);
        else
            Zd.gameObject.SetActive(true);
    }
    public  void DZBtnClick() {
        TipPlan.gameObject.SetActive(true);
        TipPlan.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "确定要锻造“史诗-" + DateMgr.GetInstance().GetItemByID(peiFang.WeaponID).item_Name+"”吗？";
        TipPlan.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite =Resources.Load<Sprite>("PicTWo/"+ DateMgr.GetInstance().GetItemByID(peiFang.WeaponID).item_Img);
    }
    public  void DZExitCilck() {
        ima1.sprite = null;
        ima2.sprite = null;
        text1.text = "0/0";
        text2.text = "0/0";
        dropdown.value = 0;
        Zd.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void UseBtnCilck() {
        GoodsModel a = Save.GoodsList1.Find((i) => peiFang.EtcID1 == i.Id);
        GoodsModel b = Save.GoodsList1.Find((i) => peiFang.EtcID2 == i.Id);
        a.Num -= peiFang.Etc1Num;
        b.Num -= peiFang.Etc2Num;
        Save.BuyItem(DateMgr.GetInstance().GetItemByID(peiFang.WeaponID));
        ShowDZ();
        TipPlan.transform.GetChild(1).gameObject.SetActive(false);
        TipPlan.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void ExitClick() {
        TipPlan.transform.GetChild(1).gameObject.SetActive(true);
        TipPlan.transform.GetChild(2).gameObject.SetActive(false);
        TipPlan.gameObject.SetActive(false);
    }
}
