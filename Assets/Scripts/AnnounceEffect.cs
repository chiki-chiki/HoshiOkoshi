using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnnounceEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOScale(Vector3.one*3f, 1f);
        spriteRenderer.DOFade(0f, 1f);
        Invoke("DestroyEffect", 1f);
    }

    void DestroyEffect()
    {
        Destroy(this.gameObject);
    }
}
