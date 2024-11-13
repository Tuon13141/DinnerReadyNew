using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPointerOnButtonClick : MonoBehaviour
{
    public GameObject panelPrefab;

    public List<Button> buttons;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(() => SpawnPanelAtButton(button));
            }
        }
    }

    private void SpawnPanelAtButton(Button button)
    {
        if (panelPrefab != null)
        {
            Vector3 spawnPosition = button.transform.position;

            Instantiate(panelPrefab, spawnPosition, Quaternion.identity, button.transform.parent);
        }
        else
        {
            //Debug.LogWarning("Panel Prefab chưa được tham chiếu.");
        }
    }
}
