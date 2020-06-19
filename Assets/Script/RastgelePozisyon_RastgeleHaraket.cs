using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastgelePozisyon_RastgeleHaraket : MonoBehaviour
{
    void Start()
    {
        rastgelepozisyon();
    }


    float RastPos;
    public void rastgelepozisyon()
    {
        RastPos = Random.Range(-260, 320);
        transform.Rotate(0, 0, RastPos);
        ////
        int RAST = Random.Range(0,4);
        if (RAST==2)
        {
            Debug.Log("yer değiştirme ..");
            StartCoroutine(RastgeleYerDegistirme());
        }
        ////
    }

    IEnumerator RastgeleYerDegistirme()
    {
        int RAST = Random.Range(0,6);
        float rs = Random.Range(0.7f,2.4f);
        yield return new WaitForSeconds(rs);
        float Yer = Random.Range(1.0f,4.0f);
        float durat = Random.Range(1.5f,3.0f);
        transform.DORotate(new Vector3(0,0,RastPos+Yer),durat);
        if (RAST==2)
        {
            rs = Random.Range(1.2f, 3.0f);
            yield return new WaitForSeconds(rs);
             Yer = Random.Range(5, 15);
             durat = Random.Range(1f, 2f);
            transform.DORotate(new Vector3(0, 0, RastPos + Yer), durat);
        }
        else if(RAST==1)
        {
            rs = Random.Range(1.2f, 3.2f);
            yield return new WaitForSeconds(rs);
            Yer = Random.Range(5, 20);
            durat = Random.Range(0.7f, 2f);
            transform.DORotate(new Vector3(0, 0, RastPos - Yer), durat);

        }
    }
   
}
