using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class progressbar : MonoBehaviour
{
    private Slider slider;
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;
    // Start is called before the first frame update
    private void Awake() 
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start() {
        IncrementProgress(0.75f);
    }
    public void IncrementProgress(float newProgress) {
        targetProgress = slider.value + newProgress;
    } 
    
       // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress) {
            slider.value += fillSpeed * Time.deltaTime;
        }
        
    }
}
