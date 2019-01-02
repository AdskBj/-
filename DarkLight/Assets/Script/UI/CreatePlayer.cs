using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class CreatePlayer : MonoBehaviour {
	// Use this for initialization
	void Start () {
        TTUIPage.ShowPage<CreatePlayerPanel>();
	}
}
