using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DZNPC : MonoBehaviour {
    public GameObject ganTanHao;
    public GameObject DZPlan;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            ganTanHao.gameObject.SetActive(true);
            ganTanHao.GetComponent<Button>().onClick.AddListener(() => DZPlan.gameObject.SetActive(true));
            RWManager.action(gameObject.tag);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ganTanHao.gameObject.SetActive(false);
            ganTanHao.GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}
