using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class RotateMove : MonoBehaviour
{
    //中心
    [SerializeField] GameObject target;
    [SerializeField]float angle = 50;
    [SerializeField] float angleMin;
    [SerializeField] float angleMax;

    [SerializeField] int objScore;
    public bool anounced;

    [SerializeField]SpriteRenderer spriteRenderer;
    Color anouncedColor;
    Color overAnouncedColor;


    AudioSource audioSource;
    [SerializeField]AudioClip announcedClip;
    [SerializeField]AudioClip overAnnouncedClip;

    GameManager gameManager;

    bool invalid;//スコア無効

    [SerializeField]GameObject scoreCopyTextObj;
    ScoreCopyText scoreCopyText;

    [SerializeField] GameObject announcedEffect;

    private void Start()
    {
        anounced = false;
        invalid = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anouncedColor = new Color32(255, 200, 64,255);
        overAnouncedColor = new Color32(92, 92, 92, 255);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreCopyText = scoreCopyTextObj.GetComponent<ScoreCopyText>();
        angle = UnityEngine.Random.Range(angleMin, angleMax);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //RotateAround(中心の場所,軸,回転角度)
        transform.RotateAround(target.transform.position, Vector3.forward, angle * Time.deltaTime);
        transform.eulerAngles = Vector3.zero;

        if (transform.position.x < -17)
        {
            Destroy(gameObject);
        }
    }

    RotateMove colRotateMove;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lader")
        {
            anouncedMethod(collision.gameObject.tag);
        }
        else if (collision.gameObject.tag == "Customer")
        {
            colRotateMove = collision.gameObject.GetComponent<RotateMove>();
            if (colRotateMove.anounced)
            {
                anouncedMethod(collision.gameObject.tag);
            }
        }
        
    }

    void anouncedMethod(string tag)
    {
        
        if (!anounced&&!invalid)
        {
            spriteRenderer.color = anouncedColor;
            gameManager.scoreSubject.OnNext(objScore);
            scoreCopyText.addScore = objScore;
            Instantiate(scoreCopyTextObj, transform.position, Quaternion.identity);
            Instantiate(announcedEffect, transform);
            audioSource.PlayOneShot(announcedClip);
        }
        else if (!invalid&&tag=="Lader")
        {
            spriteRenderer.color = overAnouncedColor;
            gameManager.scoreSubject.OnNext(-objScore / 2);
            scoreCopyText.addScore = -objScore / 2;
            Instantiate(scoreCopyTextObj, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(overAnnouncedClip);
        }
        anounced = true;
        invalid = true;
        Invoke("InvalidOff", 0.1f);
    }

    void InvalidOff()
    {
        invalid = false;
    }
}