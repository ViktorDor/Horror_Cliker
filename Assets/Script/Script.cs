using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Script : MonoBehaviour
{
    int lose_coll = 0;
    int is_click = 0;
    public AudioSource[] Appearance;
    public GameObject[] break_glasses;
    public GameObject bulb;
    public AudioSource break_bulb;
    public AudioSource On_off;
    public AudioSource DefaultScreamer;
    public AudioSource Fast_heartbeat;
    public AudioSource End_screamer;
    public GameObject camera_off;
    public GameObject demon;
    public GameObject button_green;
    public GameObject button_red;
    public GameObject game_text;
    public TextMeshPro text_coll;
    public GameObject Start_txt;
    public GameObject Start_canvas;
    public AudioSource Win;
    public GameObject win_text;
    public GameObject win_canvas;
    public GameObject loadBTN;
    public UnityEngine.UI.Slider slider;
    public GameObject start_load;
    public Scene Next_scene;
    [SerializeField] int rek_int = 0;
    bool button_clicked = false;

    public Animator redButtonAnimator;

    public Animator greenButtonAnimator;
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
                start_load.gameObject.SetActive(false);
                break;
            }
        }
    }
    public void Click_start_button()
    {
        int loadINT = PlayerPrefs.GetInt("SavedInteger");
        Debug.Log("Ваш рекорд: " + loadINT);
        StartCoroutine(ExampleCoroutine());
        StartCoroutine(Anims());
    }
    public void Click_red()
    {
        redButtonAnimator.SetTrigger("Click");
        lose_coll++;
        print("You miss click!");
        redButtonAnimator.SetTrigger("NotClick");
    }

    public void Click_green()
    {
        greenButtonAnimator.SetTrigger("Click");
        is_click++;
        text_coll.text = is_click.ToString();
        button_clicked = true;
        print("You click");
        greenButtonAnimator.SetTrigger("NotClick");
    }
    
    public void loadBTN_click()
    {
        SceneManager.LoadSceneAsync(2);
    }
    IEnumerator Anim_kill()
    {
        yield return new WaitForSeconds(3);
        camera_off.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
        bulb.gameObject.SetActive(true);
        break_glasses[0].gameObject.SetActive(false);
        break_glasses[1].gameObject.SetActive(false);
        break_glasses[2].gameObject.SetActive(false);
        break_glasses[3].gameObject.SetActive(false);
        game_text.gameObject.SetActive(false);
        StopCoroutine(ExampleCoroutine());
        yield return new WaitForSeconds(0.3f);
        camera_off.gameObject.SetActive(false);
        Start_txt.gameObject.SetActive(true);
        Start_canvas.gameObject.SetActive(true);
        rek_int = is_click;
        PlayerPrefs.SetInt("SavedInteger", rek_int);
        PlayerPrefs.Save();
        
    }
    IEnumerator Anims() {
        int coll_anim = 0;
        while(true)
        {
            if(lose_coll == 1 & coll_anim < 1)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glasses[0].gameObject.SetActive(true);
                }
                if(lose_coll == 2 & coll_anim < 2)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glasses[1].gameObject.SetActive(true);
                }
                if(lose_coll == 3  & coll_anim < 3)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glasses[2].gameObject.SetActive(true);
                    DefaultScreamer.Play();
                }
                if(lose_coll == 4  & coll_anim < 4)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glasses[3].gameObject.SetActive(true);
                }

                if(lose_coll == 5  & coll_anim < 5)
                {
                    coll_anim++;
                    On_off.Play();
                    bulb.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.3f);
                    bulb.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.3f);
                    bulb.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.3f);
                    bulb.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.3f);
                    break_bulb.Play();
                    bulb.gameObject.SetActive(false);
                }
                if(lose_coll == 6  & coll_anim < 6)
                {
                    coll_anim++;
                    camera_off.gameObject.SetActive(true);
                    demon.gameObject.SetActive(true);
                    demon.transform.position = new Vector3(-4.5f, 0.5f, -27);
                    camera_off.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.3f);
                    Appearance[0].Play();
                }
                if(lose_coll == 8  & coll_anim < 7)
                {
                    coll_anim++;
                    camera_off.gameObject.SetActive(true);
                    demon.transform.position = new Vector3(3, 0.5f, -23);
                    yield return new WaitForSeconds(0.3f);
                    camera_off.gameObject.SetActive(false);
                    Appearance[1].Play();
                }
                if(lose_coll == 9  & coll_anim < 8)
                {
                    coll_anim++;
                    Fast_heartbeat.Play();
                    camera_off.gameObject.SetActive(true);
                    demon.transform.position = new Vector3(-2.6f, 0.5f, -17);
                    yield return new WaitForSeconds(0.3f);
                    camera_off.gameObject.SetActive(false);
                    Appearance[2].Play();
                }
                if(lose_coll == 10  & coll_anim < 9)
                {
                    coll_anim++;
                    Fast_heartbeat.Stop();
                    End_screamer.Play();
                    demon.transform.position = new Vector3(0, 1, -1.8f);
                    print("Kill_anim1 play");
                    StartCoroutine(Anim_kill());
                    coll_anim = 0;
                    lose_coll = 0;
                    is_click = 0;
                    break;
                }
                if(is_click == 15 & coll_anim < 10)
                {
                    StopAllCoroutines();
                    game_text.gameObject.SetActive(false);
                    coll_anim = 10;
                    win_canvas.SetActive(true);
                    demon.gameObject.SetActive(false);
                    bulb.gameObject.SetActive(true);
                    break_glasses[0].gameObject.SetActive(false);
                    break_glasses[1].gameObject.SetActive(false);
                    break_glasses[2].gameObject.SetActive(false);
                    break_glasses[3].gameObject.SetActive(false);
                    loadBTN.gameObject.SetActive(true);
                    Win.Play();
                    win_text.gameObject.SetActive(true);
                }
                yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    IEnumerator ExampleCoroutine()
    {
        int i = 0;
        while(i < 50)
        {
            button_clicked = false;
            button_green.gameObject.SetActive(false);
            button_red.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            int rand_int_button = Random.Range(0,2);
            float rand_int_sleep = Random.Range(0.5f,1f);
            if(rand_int_button == 0)
            {
                button_red.gameObject.SetActive(true);
            }
            if(rand_int_button == 1)
            {
                button_green.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1);
            if(rand_int_button == 1){
                if(!button_clicked)
                {
                    lose_coll++;
                }
            }
            if(lose_coll == 10)
            {
                break;
            }
        }
    }
}

