using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller : MonoBehaviour
{
    [SerializeField] GameObject SoundOn, SoundOff,Sesler;

    [SerializeField] GameObject TopDokunmasesi,PatlamaSesi,NewBestSesi,SkorAlmaSesi;
    void Start()
    {
        // 1 ON
        // 2 OFF
        PlayerPrefs.DeleteAll();
        int ses = PlayerPrefs.GetInt("ses");
        if (ses==null || ses==0)
        {
            PlayerPrefs.SetInt("ses",1);
            SoundOff_V();
        }
        else if (ses == 1)
        {
            SoundOff_V();
        }
        else if (ses == 2)
        {
            SoundOn_V();
        }

    }

    // Update is called once per frame
    public void SoundOn_V()
    {
        SoundOn.SetActive(false);
        SoundOff.SetActive(true);
        Sesler.SetActive(false);
    }
    public void SoundOff_V()
    {
        SoundOn.SetActive(true);
        SoundOff.SetActive(false);
        Sesler.SetActive(true);
    }

    /////////////////////////////////////////
    /////////////////////////////////////////

    public void TopDokunmaSes()
    {
        TopDokunmasesi.GetComponent<AudioSource>().Play();
    }

    public void PatlamaSes()
    {
        PatlamaSesi.GetComponent<AudioSource>().Play();
    }
    public void NewBestSes()
    {
        NewBestSesi.GetComponent<AudioSource>().Play();
    }
    public void SkorAlmaSes()
    {
        SkorAlmaSesi.GetComponent<AudioSource>().Play();
    }

}
