using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartExperience : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    
    public void OnStartExperience(ARPlane plane)
    {
       var scene = Instantiate(cube, plane.center, Quaternion.identity);
       for (int i = 0; i < scene.transform.childCount; i++)
        {
            var child = scene.transform.GetChild(i).gameObject;
            StartCoroutine(ScaleUp(child, 0.5f));
        }
       
    }

    IEnumerator ScaleUp(GameObject obj, float duration)
    {
        
        Vector3 intitialScale = Vector3.zero;
        Vector3 targetScale = obj.transform.localScale;

        float elapsedTime = 0f;

        obj.transform.localScale = intitialScale;

        while (elapsedTime < duration)
        {
            obj.transform.localScale = Vector3.Lerp(intitialScale, targetScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
