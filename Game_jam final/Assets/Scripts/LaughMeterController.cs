using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaughMeterController : MonoBehaviour
{
    
    [SerializeField] private Image laughMeterImage;
    [SerializeField] private Sprite calmSprite;
    [SerializeField] private Sprite oneQuarterSprite;
    [SerializeField] private Sprite thirdQuarterSprite;
    [SerializeField] private Sprite fullLaughSprite;
    private float laughMeterPercentage = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateLaughMeter(){
        if (laughMeterPercentage >= 0.75f){
            laughMeterImage.sprite = oneQuarterSprite;
        }
        else if (laughMeterPercentage >= 0.5f){
            laughMeterImage.sprite = thirdQuarterSprite;
        }
        else if (laughMeterPercentage >= 0.25f){
            laughMeterImage.sprite = fullLaughSprite;
        }
        else
        {
            laughMeterImage.sprite = fullLaughSprite;
        }
    }
    public void SetLaughMeterPercentage(float percentage){
        laughMeterPercentage= Mathf.Clamp01(percentage);
        UpdateLaughMeter();
    }
}
