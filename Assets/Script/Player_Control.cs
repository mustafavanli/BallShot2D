using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Control : MonoBehaviour
{
    Rigidbody2D fizik;
    [SerializeField]GameObject player;
    [SerializeField] GameObject game_manager;
    public float AtisHizi;
    public bool atis;
    
    private void Start()
    {
        atis = true;
        fizik = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && atis==true)
        {
            atis = false;
            player.GetComponent<Collider_Control>().pos = player.transform.localPosition;
            game_manager.GetComponent<Sound_Controller>().TopDokunmaSes();
            GetComponent<DonmeScript>().donmehizi = 0f;
            fizik.velocity += new Vector2(player.transform.position.x*AtisHizi, player.transform.position.y*AtisHizi);
        }
    }
   
}
