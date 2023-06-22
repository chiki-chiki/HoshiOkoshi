using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] GameObject howToPlayDialog;
    [SerializeField] Image howToPlaySlideObject;
    [SerializeField] Sprite[] howToPlaySlideImage;
    [SerializeField] TextMeshProUGUI slideNumText;
    int slideNum;
    // Start is called before the first frame update
    void Start()
    {
        slideNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slideNumText.text = (slideNum+1).ToString();
    }

    public void startHowToPlay()
    {
        howToPlayDialog.SetActive(true);
    }
    public void endHowToPlay()
    {
        howToPlayDialog.SetActive(false);
    }

    public void rightButton()
    {
        slideNum++;
        if (slideNum >= howToPlaySlideImage.Length)
        {
            slideNum = 0;
        }
        howToPlaySlideObject.sprite = howToPlaySlideImage[slideNum];
    }

    public void leftButton()
    {
        slideNum--;
        if (slideNum < 0)
        {
            slideNum = howToPlaySlideImage.Length-1;
        }
        howToPlaySlideObject.sprite = howToPlaySlideImage[slideNum];
    }
    
}
