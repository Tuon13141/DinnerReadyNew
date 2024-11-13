using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIChatBox : UIElement
{
    public override bool ManualHide => true;

    public override bool DestroyOnHide => false;

    public override bool UseBehindPanel => false;

    [SerializeField] TextMeshProUGUI chatText;

    [SerializeField] List<string> chatList = new List<string>();

    public override void Show()
    {
        base.Show();
        //Debug.Log(1);
        RandomChat();
        StartCoroutine(AutoHide());
    }

    void RandomChat()
    {
        string chat = chatList[Random.Range(0, chatList.Count)];

        chatText.text = chat;
    }

    IEnumerator AutoHide()
    {
        yield return new WaitForSeconds(3f);

        Hide();
    }
}
