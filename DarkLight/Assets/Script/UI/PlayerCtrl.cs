using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    RaycastHit hit;
    public  GameObject Player;
    CharacterController pkk;
    Rigidbody rigidbodys;
    Vector3 mubiao;
	void Start () {
        pkk = Player.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray;
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground")))
            {   
                //Instantiate(GameSetting.Instance.mousefxAttack, hit.point, Quaternion.identity);

            }
        }
        Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.LookRotation(hit.point - Player.transform.position), 0.5f);
        if (Vector3.Distance(Player.transform.position, hit.point) > 0.1f)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, hit.point, 0.01f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RWManager.action("F");
            RWManager.action("K");
        }
    }
}
