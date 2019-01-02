using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class UILogin : TTUIPage
{
    public UILogin() : base(UIType.Normal,UIMode.HideOther, UICollider.None)
    {
        uiPath = "UIPrefab/login";
    }
    public override void Awake(GameObject go)
    {
        this.transform.Find("zhuce").GetComponent<Button>().onClick.AddListener(OnClickZhuce);
        this.transform.Find("denglu").GetComponent<Button>().onClick.AddListener(OnClickSkillGo);
    }

    private void OnClickSkillGo()
    {

    }

    private void OnClickZhuce()
    {
    }
}
