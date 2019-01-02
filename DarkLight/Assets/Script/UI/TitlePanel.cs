using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitlePanel : TTUIPage {
    public Image imageTitle;
    public Image imageWhite;
    public Button ButtonLoad;
    public Button ButtonNew;
    public TitlePanel() : base(UIType.Normal,UIMode.DoNothing,UICollider.None) {

        uiPath = "UIPrefab/TitlePanle";
    }
    public override void Awake(GameObject go)
    {
        imageTitle = transform.Find("ImageTitle").GetComponent<Image>();
        //imageAnyKey = transform.Find("ImageAnyKey").GetComponent<Image>();
        imageWhite = transform.Find("ImageWhite").GetComponent<Image>();
        ButtonLoad= transform.Find("loadname").GetComponent<Button>();
        ButtonNew = transform.Find("newname").GetComponent<Button>();
        


        ButtonNew.onClick.AddListener(()=> { SceneManager.LoadScene("Loading"); GC.GetInstance().nextScenceName = "NewHero"; });
        ButtonLoad.onClick.AddListener(() => { SceneManager.LoadScene("Loading"); GC.GetInstance().nextScenceName = "游戏主界面名"; });
        imageTitle.color = new Color(1,1,1,0);
        //imageTitle.gameObject.SetActive(false);
        //imageAnyKey.gameObject.SetActive(false);
        imageWhite.DOFade(0, 2f).SetDelay(0.2f);
        imageTitle.DOFade(1, 1).SetDelay(4);
        //imageAnyKey.DOFade(0, 1).SetLoops(-1).SetDelay(5).OnStart(()=>imageAnyKey.gameObject.SetActive(true));
        ButtonLoad.GetComponent<Image>().DOFade(1, 1).SetDelay(5).OnStart(() => ButtonLoad.gameObject.SetActive(true));
        ButtonNew.GetComponent<Image>().DOFade(1, 1).SetDelay(5).OnStart(() => ButtonNew.gameObject.SetActive(true));
        if (!PlayerPrefs.HasKey("SaveDate"))
        {
            ButtonLoad.interactable = false;
            transform.Find("loadname").GetComponent<Image>().sprite =Resources.Load("Pic/loadgame")as Sprite;
        }
}

}
