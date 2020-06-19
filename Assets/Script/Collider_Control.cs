using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collider_Control : MonoBehaviour
{
    // Color 
    Color32[] hedefcolor = new Color32[16] { new Color32(188, 232, 132, 255), new Color32(188, 232, 132, 255), new Color32(59, 255, 160, 255), new Color32(255, 231, 148, 255), new Color32(245, 162, 97, 255), new Color32(245, 162, 97, 255), new Color32(240, 34, 60, 255), new Color32(255, 112, 73, 255), new Color32(219, 68, 68, 255), new Color32(249, 238, 104, 255), new Color32(0, 173, 181, 255), new Color32(126, 189, 194, 255), new Color32(159, 39, 39, 255), new Color32(125, 125, 254, 255), new Color32(74, 160, 182, 255), new Color32(255, 228, 113, 255) };

    ////////////////////
    Rigidbody2D fizik;
    public Vector3 pos;
    int skor;
    [SerializeField] GameObject Effect;
    [SerializeField] GameObject Donencember_Hedef;

    [SerializeField] GameObject Hedef;

    [SerializeField] GameObject EndMenu;

    [SerializeField] TextMeshProUGUI skor_Text,skor_endmenu,best_endmenu;


    [SerializeField] GameObject game_manager;



    int donme;
    float donushizi;
    float onceki;

    bool DonusTersi;
    public void Start()
    {
        //   gameObject.SetActive(true);
        GetComponent<Image>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        
        DonusTersi = true;
        donme = 1;

        transform.parent.GetComponentInChildren<DonmeScript>().donmehizi = 100; // default 100
        donushizi = transform.parent.GetComponentInChildren<DonmeScript>().donmehizi;
        skor = 0;
        skor_endmenu.text = "";
        best_endmenu.text = "";
        skor_Text.gameObject.SetActive(false);
        fizik = GetComponent<Rigidbody2D>();
    }
    public void yeniden()
    {
        Donencember_Hedef.GetComponent<RastgelePozisyon_RastgeleHaraket>().rastgelepozisyon();
        GetComponent<Image>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        fizik.velocity = new Vector2(0, 0);
        transform.DOLocalMoveX(pos.x, 0f);
        transform.DOLocalMoveY(pos.y, 0f);
        transform.parent.GetComponent<Player_Control>().atis = true;
        EndMenu.transform.DOLocalMoveY(-2500,1f);
        transform.parent.transform.parent.transform.DOLocalMoveY(0, 1f);
        Start();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Hedef"))
        {
            DonusTersi = !DonusTersi;
            game_manager.GetComponent<Sound_Controller>().SkorAlmaSes();


            if (skor/donme==5 && donme<7)
            {
                donme += 1;
                donushizi += 5;
            }
        

            skor_Text.gameObject.SetActive(true);
            skor++;
            skor_Text.text = skor.ToString();
            GameObject efekt = Instantiate(Effect, transform.position, new Quaternion(0, 0, 0, 0));
            efekt.GetComponent<ParticleSystem>().startColor = col.GetComponent<Image>().color;
            Destroy(efekt,1f);
            
            skorani();
            
            transform.DOLocalMoveX(pos.x, 0.6f);
            transform.DOLocalMoveY(pos.y, 0.6f);
            StartCoroutine(donmehizisabitle());
            fizik.velocity = new Vector2(0,0);
        }
        else if (col.gameObject.CompareTag("Engel"))
        {

            ChangeMenuPos();
            int best = PlayerPrefs.GetInt("skor");
            Debug.Log("BEST : " + best);
            if (best==null || best==0 )
            {
                StartCoroutine(yazidegisimi());
                skor_endmenu.text = skor.ToString();
                best_endmenu.text = "NEW BEST";
                PlayerPrefs.SetInt("skor",skor);
                game_manager.GetComponent<Sound_Controller>().NewBestSes();
            }
            else
            {

                if (best < skor)
                {
                    StartCoroutine(yazidegisimi());
                    skor_endmenu.text = skor.ToString();
                    best_endmenu.text = "NEW BEST";
                    PlayerPrefs.SetInt("skor", skor);
                    game_manager.GetComponent<Sound_Controller>().NewBestSes();
                }
                else
                {
                    skor_endmenu.text = skor.ToString();
                    best_endmenu.text = "BEST " + best;
                }
            }

            game_manager.GetComponent<Sound_Controller>().PatlamaSes();
            GameObject efekt = Instantiate(Effect, transform.position, new Quaternion(0, 0, 0, 0));
            efekt.GetComponent<ParticleSystem>().startColor = GetComponent<Image>().color;
            Destroy(efekt,1f);
            // gameObject.SetActive(false);

            GetComponent<Image>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            transform.DOLocalMoveX(pos.x,0f);
            transform.DOLocalMoveY(pos.y,0f);
        
            StartCoroutine(ChangeMenuPos());
       
        }
    }
    IEnumerator ChangeMenuPos()
    {
        yield return new WaitForSeconds(0.7f);
        EndMenu.transform.DOLocalMoveY(0 , 0.4f);
        transform.parent.transform.parent.transform.DOLocalMoveY(2500 , 1f);
    }
    IEnumerator yazidegisimi()
    {
        for (int i = 0; i < 6; i++)
        {
            best_endmenu.DOColor(new Color32(255, 255, 255, 0), 0.4f);
            yield return new WaitForSeconds(0.35f);
            best_endmenu.DOColor(new Color32(255, 255, 255, 255), 0.4f);
            yield return new WaitForSeconds(0.35f);

        }

    }
    
    void skorani()
    {
        skor_Text.gameObject.GetComponent<Animator>().SetTrigger("SkorAlma");
    }
    IEnumerator donmehizisabitle()
    {
        Hedef.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        transform.parent.GetComponent<Player_Control>().atis = true;
        if (DonusTersi)
        {
            transform.parent.GetComponentInChildren<DonmeScript>().donmehizi = donushizi;
        }
        else
        {
            transform.parent.GetComponentInChildren<DonmeScript>().donmehizi = -donushizi;
        }
        Debug.Log(transform.parent.GetComponentInChildren<DonmeScript>().donmehizi);
        yield return new WaitForSeconds(0.2f);
        DOTween.PauseAll();
        int rans = Random.Range(0, hedefcolor.Length);
        Hedef.GetComponent<Image>().color = hedefcolor[rans];
        Hedef.SetActive(true);
        Donencember_Hedef.GetComponent<RastgelePozisyon_RastgeleHaraket>().rastgelepozisyon();
    }
}
