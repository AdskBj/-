using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texiao : MonoBehaviour {
    public GameObject ECs;
    void EC()
    { Instantiate(ECs,transform.position, Quaternion.identity); }
}
