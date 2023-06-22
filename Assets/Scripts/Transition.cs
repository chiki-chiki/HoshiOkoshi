using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdown;
    int count;
    AudioSource audioSource;
    [SerializeField] AudioClip countSound;
    [SerializeField] AudioClip startSound;
       // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        count = 3;
        Invoke("countDown", 1f);//2
        Invoke("countDown", 2f);//1
        Invoke("countDown", 3f);
        Invoke("countDown", 4f);
    }
    void countDown()
    {
        count--;
        if (count != 0)
        {
            countdown.text = count.ToString();
            audioSource.PlayOneShot(countSound);
        }
        else
        {
            countdown.text = "START";
            audioSource.PlayOneShot(startSound);
            Invoke("GameStart", 0.2f);
        }
    }

    void GameStart()
    {
        SceneManager.LoadScene("Main");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
