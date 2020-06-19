using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonmeScript : MonoBehaviour
{
    public float donmehizi = 0f;
    void Update()
    {
            transform.Rotate(0, 0, donmehizi * Time.deltaTime);
        
    }
}
