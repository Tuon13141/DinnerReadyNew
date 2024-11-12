using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRedScreen : UIElement
{
    public override bool ManualHide => true;

    public override bool DestroyOnHide => true;

    public override bool UseBehindPanel => false;

    public List<GameObject> panels;

    public override void Show()
    {
        base.Show();

        StartBlinkEffect();
    }

    public void StartBlinkEffect()
    {
        foreach (var panel in panels)
        {
            StartCoroutine(BlinkPanel(panel));
        }
    }

    private IEnumerator BlinkPanel(GameObject panel)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = panel.AddComponent<CanvasGroup>();
        }

        float duration = 1.5f;
        float halfDuration = duration / 3f;


        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / halfDuration);
            yield return null;
        }

        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / halfDuration);
            yield return null;
        }

        canvasGroup.alpha = 1;
        yield return null;

        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / halfDuration);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        Hide();
    }
}
