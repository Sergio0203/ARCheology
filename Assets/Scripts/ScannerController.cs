using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.InputSystem;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class ScannerController : MonoBehaviour
{
    [SerializeField] private SpotController spot;
    [SerializeField] private float scanDuration = 3f;
    [SerializeField] GameObject scanUI; 
    private Animator animator;

    void Start()
    {
      animator = GetComponent<Animator>();
    }

    void Update()
    {
        //probably there is a better way to do it, but for now... It works!
      if (!spot.isOccupied()) scanUI.SetActive(false);  
    }

    void OnCollisionEnter(Collision collision)
    {   
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnSpot(collision.gameObject);
        }
    }

    private void TryToPutOnSpot(GameObject obj)
    {
        if (!spot.isOccupied())
        {
            obj.transform.SetParent(spot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true;
            }

            if (obj.TryGetComponent(out ObjectInteractor interactor))
            {
                StartCoroutine(StartScanning(interactor));
            }
            
        }
    }

    private IEnumerator StartScanning(ObjectInteractor interactor)
    {
        Debug.Log("Srating Scanning");

        animator.SetBool("isScanning", true);
        scanUI.SetActive(false);

        interactor.SetLocked(true);

        yield return new WaitForSeconds(scanDuration);
        Debug.Log("Scan Complete");

        animator.SetBool("isScanning", false);
        scanUI.SetActive(true);
        interactor.SetLocked(false);
        interactor.SetScanned();
        
    }
}
