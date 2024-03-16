using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Script2 : MonoBehaviour
{
    int lose_coll = 0;
    int is_click = 0;
    public GameObject bulb;
    public AudioSource break_bulb;
    public GameObject break_glass1;
    public GameObject break_glass2;
    public GameObject break_glass3;
    public GameObject break_glass4;
    public AudioSource DefaultScreamer;
    public AudioSource Appearance1;
    public AudioSource Appearance2;
    public AudioSource Appearance3;
    public AudioSource Fast_heartbeat;
    public AudioSource End_screamer;
    public AudioSource On_off;
    public GameObject camera_off;
    public GameObject demon;
    public GameObject button_green;
    public GameObject button_red;
    public GameObject button_green2;
    public GameObject button_red2;
    public TextMeshPro text_coll;
    bool button_clicked = false;
    bool button_clicked2 = false;
    // Start is called before the first frame update
    public void Click_start_button2()
    {
        StartCoroutine(ExampleCoroutine2());
        StartCoroutine(Anims2());
    }
    public void Click_red_2()
    {
        lose_coll++;
        print("You miss click!");
    }

    public void Click_green_2()
    {
        button_clicked = true;
        print("You click");
    }
    public void Click_red_two()
    {
        lose_coll++;
        print("You miss click!");
    }

    public void Click_green_two()
    {
        button_clicked2 = true;
        print("You click");
    }

    IEnumerator Anims2() {
        int coll_anim = 0;
        while(true)
        {
            if(lose_coll == 1 & coll_anim < 1)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glass1.gameObject.SetActive(true);
                }
                if(lose_coll == 2 & coll_anim < 2)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glass2.gameObject.SetActive(true);
                }
                if(lose_coll == 3  & coll_anim < 3)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glass3.gameObject.SetActive(true);
                    DefaultScreamer.Play();
                }
                if(lose_coll == 4  & coll_anim < 4)
                {
                    coll_anim++;
                    break_bulb.Play();
                    break_glass4.gameObject.SetActive(true);
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
                    Appearance1.Play();
                }
                if(lose_coll == 8  & coll_anim < 7)
                {
                    coll_anim++;
                    camera_off.gameObject.SetActive(true);
                    demon.transform.position = new Vector3(3, 0.5f, -23);
                    yield return new WaitForSeconds(0.3f);
                    camera_off.gameObject.SetActive(false);
                    Appearance2.Play();
                }
                if(lose_coll == 9  & coll_anim < 8)
                {
                    coll_anim++;
                    Fast_heartbeat.Play();
                    camera_off.gameObject.SetActive(true);
                    demon.transform.position = new Vector3(-2.6f, 0.5f, -17);
                    yield return new WaitForSeconds(0.3f);
                    camera_off.gameObject.SetActive(false);
                    Appearance3.Play();
                }
                if(lose_coll == 10  & coll_anim < 9)
                {
                    coll_anim++;
                    Fast_heartbeat.Stop();
                    End_screamer.Play();
                    demon.transform.position = new Vector3(0, 1, -1.8f);
                    yield return new WaitForSeconds(5f);
                    break;
                }
                yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    IEnumerator ExampleCoroutine2()
    {
        int i = 0;
        while(i < 50)
        {
            button_clicked = false;
            button_clicked2 = false;
            button_green.gameObject.SetActive(false);
            button_red.gameObject.SetActive(false);
            button_green2.gameObject.SetActive(false);
            button_red2.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            int rand_int_button = Random.Range(0,2);
            int rand_int_button2 = Random.Range(0,2);
            float rand_int_sleep = Random.Range(0.5f,1f);
            if(rand_int_button == 0)
            {
                button_red.gameObject.SetActive(true);
            }
            if(rand_int_button == 1)
            {
                button_green.gameObject.SetActive(true);
            }
            if(rand_int_button2 == 0)
            {
                button_red2.gameObject.SetActive(true);
            }
            if(rand_int_button2 == 1)
            {
                button_green2.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1);
            if(rand_int_button == 1 & rand_int_button2 == 1)
            {
                if(button_clicked & button_clicked2)
                {
                    print("Нажаты две кнопки");
                    is_click++;
                    text_coll.text = is_click.ToString();
                    continue;
                }
                if(!button_clicked | !button_clicked2)
                {
                    lose_coll++;
                }
            }
            if(rand_int_button == 1 | rand_int_button2 == 1){
                if(!button_clicked | !button_clicked2)
                {
                    lose_coll++;
                }
                if(button_clicked | button_clicked2)
                {
                    print("Нажата одна из кнопок!");
                    is_click++;
                    text_coll.text = is_click.ToString();
                }
            }
        }
    }
}
