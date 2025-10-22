using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<GameObject> canvases = new List<GameObject>();

    public void ToggleCanvasVisibility(GameObject canvas)
    {
        if (canvas != null)
        {
            // First, deactivate all canvases
            DeactivateAllCanvases();

            // Then activate the requested canvas
            canvas.SetActive(true);
        }
    }

    private void DeactivateAllCanvases()
    {
        foreach (var canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }
}
