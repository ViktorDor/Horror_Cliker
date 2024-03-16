using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Loadscript : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        int i = 0;
        while(i < 25)
        {
            slider.value = slider.value + 0.2f;
            yield return new WaitForSeconds(0.2f);
            if(slider.value == 5)
            {
                SceneManager.LoadSceneAsync(1);
                break;
            }
        }
    }
}
