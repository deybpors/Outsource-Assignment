using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinRenderer;
    [SerializeField] private List<Mesh> skins = new List<Mesh>();

    [SerializeField, HideInInspector]
    private int currentSkinIndex;

    private void Awake()
    {
        if (skinRenderer == null || skins.Count == 0)
            return;

        // Find current skin index
        for (int i = 0; i < skins.Count; i++)
        {
            if (skinRenderer.sharedMesh == skins[i])
            {
                currentSkinIndex = i;
                break;
            }
        }
    }

    public void NextSkin()
    {
        if (skins.Count == 0) return;

        currentSkinIndex = (currentSkinIndex + 1) % skins.Count;
        ApplySkin();
    }

    public void PreviousSkin()
    {
        if (skins.Count == 0) return;

        currentSkinIndex--;
        if (currentSkinIndex < 0)
            currentSkinIndex = skins.Count - 1;

        ApplySkin();
    }

    private void ApplySkin()
    {
        skinRenderer.sharedMesh = skins[currentSkinIndex];
    }
}
