using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material cleanMaterial;
    [SerializeField] private MeshRenderer artifactRenderer;
    public void Clean()
    {
        if (artifactRenderer != null && cleanMaterial != null)
        {
            artifactRenderer.material = cleanMaterial;
        }
    }
}
