using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float variability = 1f;
    private float randomOffset;
    private bool isAnimating = false;
    void Start()
    {
       randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (isAnimating)
        {
        float rotX = Mathf.Sin(Time.time * variability + randomOffset) * speed;
        float rotY = Mathf.Sin(Time.time * 0.7f * variability + randomOffset) * speed;
        float rotZ = Mathf.Sin(Time.time * 0.3f * variability + randomOffset) * speed;

        transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.deltaTime);
        }
    }

    public void setAnimation(bool isAnimating)
    {
        this.isAnimating = isAnimating;
    }
}
