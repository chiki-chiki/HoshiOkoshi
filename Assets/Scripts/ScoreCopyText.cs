using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreCopyText : MonoBehaviour
{
    public int addScore;
    [SerializeField]string[] catchCopy;
    int catchCopyNum;

    [SerializeField] TextMeshPro scoreText;
    [SerializeField] TextMeshPro catchCopyText;

    [SerializeField] float moveY;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = addScore.ToString();
        catchCopyNum = Random.Range(0, catchCopy.Length);
        catchCopyText.text = "\\ "+catchCopy[catchCopyNum]+" /";
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOMoveY(transform.position.y + moveY, 1f);
        scoreText.DOFade(0f, 1f);
        catchCopyText.DOFade(0f, 1f);
        Invoke("DestroyText", 1f);
    }
    void DestroyText()
    {
        Destroy(this.gameObject);
    }
}
