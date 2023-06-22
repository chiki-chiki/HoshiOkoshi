using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] GameObject brackOutImage;
    Image brackOut;
    // Start is called before the first frame update
    void Start()
    {
        brackOut = brackOutImage.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameStart()
    {
        brackOutImage.SetActive(true);
        var seq = DOTween.Sequence();
        seq.Append(brackOut.DOFade(1, 0.5f));
        seq.AppendCallback(() =>
        {
            SceneManager.LoadScene("Transition");
        });
    }
}
