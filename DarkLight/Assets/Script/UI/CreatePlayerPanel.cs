using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CreatePlayerPanel : TTUIPage {

     GameObject[] hero;  //your hero
    string[] xing;
    string[] ming;
    [HideInInspector]
    public int indexHero = 0;  //index select hero

    private GameObject[] heroInstance; //use to keep hero gameobject when Instantiate

    // Use this for initialization
   

    public Button buttonPre, buttonnext, buttonRandom, buttonOK;
    public InputField inputFieldName;
    public CreatePlayerPanel() : base(UIType.Normal,UIMode.DoNothing,UICollider.None) {
        uiPath="UIPrefab/CreatePlayerPanel";
    }
    public override void Awake(GameObject go)
    {
        buttonPre = transform.Find("prev").GetComponent<Button>();
        buttonnext = transform.Find("next").GetComponent<Button>();
        buttonRandom = transform.Find("ButtonRandom").GetComponent<Button>();
        buttonOK = transform.Find("youname").GetComponent<Button>();
        inputFieldName= transform.Find("InputField").GetComponent<InputField>();

        buttonnext.onClick.AddListener(OnClicknext);
        buttonPre.onClick.AddListener(OnClickprev);
        buttonOK.onClick.AddListener(OnClikButtonOk);
        buttonRandom.onClick.AddListener(()=> { OnClickGetRandomName();buttonRandom.transform.DORotate(Vector3.forward * 180, 0.5f); });
        hero = Resources.LoadAll<GameObject>("Player/HeroPreview");//遍历Resources中所有同类型的文件，并放入一个数组中
        heroInstance = new GameObject[hero.Length]; //add array size equal hero size
        indexHero = 0; //set default selected hero
        SpawnHero(); //spawn hero to display current selected


        //check if hero is less than 1 , button next and prev will disappear
        if (hero.Length <= 1)
        {
            buttonnext.gameObject.SetActive(false);
            buttonPre.gameObject.SetActive(false);
        }

    }
    //Check show only selected character
    public void OnClickGetRandomName() {
        inputFieldName.text= (xing[Random.Range(0, xing.Length)] + ming[Random.Range(0, ming.Length)]).ToString();
    }
    public  void OnClicknext() {
        indexHero++;
        if (indexHero>=hero.Length)
        {
            indexHero = 0;
        }
        UpdateHero(indexHero);
    }
    public  void OnClickprev()
    {
        indexHero--;
        if (indexHero <0)
        {
            indexHero = hero.Length-1;
        }
        UpdateHero(indexHero);
    }
    public void OnClikButtonOk() {
        PlayerPrefs.SetString("pName",inputFieldName.text);
        PlayerPrefs.SetInt("pSelect",indexHero);

        SceneManager.LoadScene("Dreamdev Village");

    }
    public void UpdateHero(int _indexHero)
    {
        for (int i = 0; i < hero.Length; i++)
        {
            //Show only select character
            if (i == _indexHero)
            {
                heroInstance[i].SetActive(true);
            }
            else
            {
                //Hide Other Character
                heroInstance[i].SetActive(false);
            }
        }
    }

    //Spawn all hero
    public void SpawnHero()
    {
        for (int i = 0; i < hero.Length; i++)
        {
            heroInstance[i] = (GameObject)GameObject.Instantiate(hero[i], transform.position, transform.rotation);
        }

        UpdateHero(indexHero);
    }
}
