using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lodingScence : MonoBehaviour
{
   public  Slider slider;
   public  Text text;
    AsyncOperation operation;
     void Start()
    {
        slider.value = 0.0f;
        StartCoroutine(enumerable());  
    }
    IEnumerator enumerable()
    {
        operation = SceneManager.LoadSceneAsync(GC.GetInstance().nextScenceName);
        operation.allowSceneActivation = false;
        yield return operation;
    }
    void Update()
    {
        if (operation.progress>=0.9f)
        {
            slider.value = 1.0f;
        }
        if (operation.progress!=slider.value)
        {
            slider.value = Mathf.Lerp(slider.value,operation.progress,Time.deltaTime*1);
            if (Mathf.Abs(slider.value-operation.progress)<0.01f)
            {
                slider.value = operation.progress;
            }
        }
        text.text = ((int)(slider.value*100)).ToString() + "%";
        if ((int)slider.value*100==100)
        {
            operation.allowSceneActivation = true;
        }
    }
}
