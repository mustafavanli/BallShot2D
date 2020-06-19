using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Button_Script : MonoBehaviour
{
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject StartMenu,GamePanel,EndMenu;
    public void PlayeButton()
    {
        StartMenu.transform.DOLocalMoveY(4500,1.45f);
        StartCoroutine(Bekletme(0.5f,0,GamePanel));
    }
    IEnumerator Bekletme(float Bekletme,float posY,GameObject element)
    {
        element.transform.DOLocalMoveY(posY, Bekletme);
        yield return new WaitForSeconds(Bekletme/4);
        element.SetActive(true);
    }
    public void ShareButton()
    {
        StartCoroutine( TakeSSAndShare());

    }
    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText("").Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }
    public void RestarButton()
    {
        EndMenu.transform.DOLocalMoveY(-2500,1f);
        GamePanel.transform.DOLocalMoveY(0,1f);

    }
}
