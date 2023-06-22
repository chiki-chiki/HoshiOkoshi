using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] customers;

    float generateSpan;
    float generateSpanCount;
    float timeCount;
    [SerializeField]float generateSpanMax;
    [SerializeField]float generateSpanMin;

    

    [SerializeField]float posX;
    float posY;
    [SerializeField] float posYMax;
    [SerializeField] float posYMin;

    int customerNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        generateSpanCount += Time.deltaTime;
        if (generateSpanCount > generateSpan)
        {
            CustomerGenerate();
        }
        timeCount += Time.deltaTime;
        generateSpanMin = generateSpanMin - Time.deltaTime/15;
        generateSpanMax = generateSpanMax - Time.deltaTime / 12;
    }

    void CustomerGenerate()
    {
        customerNum = Random.Range(0, customers.Length);
        posY = Random.Range(posYMin, posYMax);
        
        this.transform.position = Vector3.right * posX + Vector3.up * posY;
        Instantiate(customers[customerNum], transform.position, Quaternion.identity);
        generateSpan = Random.Range(generateSpanMin, generateSpanMax);
        generateSpanCount = 0;
    }
}
