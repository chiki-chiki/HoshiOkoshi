using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenaRotate : MonoBehaviour
{
    [SerializeField]float　maxAngle;
    [SerializeField] float moveAngle;
    bool left;

    [SerializeField] GameObject[] lader;
    [SerializeField] GameObject[] laderBody;
    float chargeTime;
    [SerializeField] float chargeSpan;
    int chargeNum;
    bool isCharging;
    bool isCharged;

    AudioSource audioSource;
    [SerializeField]AudioClip tamePi;
    [SerializeField] AudioClip tameBii;
    [SerializeField] AudioClip Shot;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z <= 75)
        {
            left = true;
        }
        else
        {
            left = false;
        }
             
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))&&!isCharging)
        {
        transform.Rotate(new Vector3(0, 0, moveAngle));
            if (left&&transform.eulerAngles.z > maxAngle)
            {
                transform.eulerAngles = new Vector3(0, 0, maxAngle);
            }

        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))&&!isCharging)
        {
            transform.Rotate(new Vector3(0, 0, -moveAngle));
            if (!left&&transform.eulerAngles.z < 360-maxAngle)
            {
                transform.eulerAngles = new Vector3(0, 0, 360-maxAngle);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeStart();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            chargeEnd();
        }
        if (isCharging)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime > chargeSpan)
            {
                chargeNum++;
                if (chargeNum >= lader.Length)
                {
                    chargeNum = lader.Length;
                    isCharged = true;
                    
                }
                chargeTime = 0;
                lader[chargeNum - 1].SetActive(true);
                if (!isCharged)
                {
                    audioSource.PlayOneShot(tamePi);
                }
            }
            if (!isCharged)
            {
                audioSource.pitch += Time.deltaTime * 0.1f;
            }
        }
    }

    void chargeStart()
    {
        isCharging = true;
        audioSource.pitch = 1;
        chargeTime = chargeSpan;
        audioSource.Play();
    }

    
    void chargeEnd()
    {
        isCharging = false;
        isCharged = false;
        for(int i = 0; i < chargeNum; i++)
        {
            lader[i].SetActive(false);
            laderBody[i].SetActive(true);
            StartCoroutine(laderBodyDisapper(i));
        }
        chargeNum = 0;
        Debug.Log("chargeEnd");
        audioSource.Stop();
        audioSource.PlayOneShot(Shot);
    }

    WaitForSeconds laderBodyDissaperWait = new WaitForSeconds(0.1f);
    IEnumerator laderBodyDisapper(int num)
    {
        yield return laderBodyDissaperWait;
        laderBody[num].SetActive(false);
    }
}
