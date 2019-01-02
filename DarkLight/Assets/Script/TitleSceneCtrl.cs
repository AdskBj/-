using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class TitleSceneCtrl : MonoBehaviour {
    public Camera cam;
    public Transform transformproint;
	// Use this for initialization
	void Start () {
        cam.transform.DOMove(transformproint.position,5);
        TTUIPage.ShowPage<TitlePanel>();
	}
}
