using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    int score;

    public Subject<int> scoreSubject = new Subject<int>();
    private ReactiveProperty<int> _valuereactiveProperty = new ReactiveProperty<int>(0);

    public IObservable<int> OnScoreChanged
    {
        get { return scoreSubject; }
    }

    float timelimit = 60;
    float timecount;
    float minutecount;
    int displayHour;
    int displayMinute;
    [SerializeField] TextMeshProUGUI dateTimeText;

    //12時間＝720分、720/60=12 1秒間で12分

    [SerializeField] TextMeshProUGUI scoreText;

    bool gameSet;
    [SerializeField] Image Nichibotsu;
    [SerializeField] TextMeshProUGUI NichibotsuText;
    [SerializeField] Image ResultBack;
    [SerializeField] TextMeshProUGUI ScoreLabel;
    [SerializeField] TextMeshProUGUI scoreResultText;
    [SerializeField] RectTransform retryButton;
    [SerializeField] RectTransform titleButton;
    [SerializeField] Image brackOut;
    [SerializeField] GameObject generator;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreSubject.Subscribe(addScore =>
        {
            score += addScore;
            Debug.Log(addScore);
        }
        );
        brackOut.color = new Color32(77 / 255, 77 / 255, 77 / 255, 1);
        brackOut.DOFade(0, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        CalcTime();

        if (timecount > timelimit&&!gameSet)
        {
            GameSet();
            gameSet = true;
        }
    }

    void CalcTime()
    {
        timecount += Time.deltaTime;
        minutecount = 719-timecount * 12;
        displayHour = (int)minutecount / 60;
        displayMinute = (int)Mathf.Round(minutecount % 60);
        dateTimeText.text = displayHour.ToString("d2") + ":" + displayMinute.ToString("d2");

    }
    void GameSet()
    {
        generator.SetActive(false);
        scoreResultText.text = score.ToString();
        var seq = DOTween.Sequence();
        seq.Append(Nichibotsu.DOFade(230f / 255f, 0.5f));
        seq.Append(ResultBack.rectTransform.DOScale(Vector2.one * 0.5f, 0.5f));
        seq.Join(ScoreLabel.rectTransform.DOScale(Vector2.one, 0.5f));
        seq.Join(scoreResultText.rectTransform.DOScale(Vector2.one, 0.5f));
        seq.Append(retryButton.DOScale(Vector2.one*0.5f, 0.5f));
        seq.Join(titleButton.DOScale(Vector2.one * 0.5f, 0.5f));



    }
}
