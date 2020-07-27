using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScriptbutton : MonoBehaviour
{
    // Start is called before the first frame update
  
    public AudioSource myFX;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    
    public void HoverSound() {
        myFX.PlayOneShot(hoverFx);
    }
    
    public void ClickSound() {
        myFX.PlayOneShot (clickFx);
    }
}
