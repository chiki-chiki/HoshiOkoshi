using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    [SerializeField] Image brackOutImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Retry()
    {
        var seq = DOTween.Sequence();
        seq.Append(brackOutImage.DOFade(1, 0.5f));
        seq.AppendCallback(() =>
        {
            SceneManager.LoadScene("Transition");
        }
            );

    }
}
