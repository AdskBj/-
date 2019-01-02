using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC :MonoBehaviour{
    private static GC instance;
    public string nextScenceName;
    private GC() { }
    public static GC GetInstance() {

        if (instance==null)
        {
            GameObject go = new GameObject("GC");
          instance=  go.AddComponent<GC>();
        }
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }
}
