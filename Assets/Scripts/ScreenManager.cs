using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ScreenManager : MonoBehaviour {

    //シーンの開始時に自動的に開く画面
    public Animator initiallyOpen;
    public int packageId;
    public int musicId;
    //現在開いているシーン
    private Animator m_Open;

    //遷移を制御するために使用するパラメーターのハッシュ
    private int m_OpenParameterId;

    //現在の画面を開く前に選択されたゲームオブジェクト
    //画面を閉じるのに使用。すると、それを開いたボタンにもどります。
    private GameObject m_PreviouslySelected;
    private Animator m_PreviouslyScreen;

    //確認すべきアニメーターステートと遷移名
    const string k_OpenTransitionName = "Open";
    const string k_ClosedStateName = "Closed";

    public void OnEnable()
    {
        //ハッシュを "Open" パラメーターにキャッシュし、Animator.SetBool　に供給できます。
        m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);

        //設定すると、最初の画面が開きます。
        if (initiallyOpen == null)
            return;
        OpenPanel(initiallyOpen);
    }

    //現在開いているパネルを閉じ、指定したものを開きます。
    //さらに、ナビゲーションの処理と新しく選択された要素の設定もおこないます。
    public void OpenPanel (Animator anim)
    {
        if (m_Open == anim)
            return;

        //新しい画面のヒエラルキーをアクティベートして、それを動かすことができます。
        anim.gameObject.SetActive(true);
        //画面を開くのに使用した現在選択中のボタンを保存します (CloseCurrent はそれを変更します)
        var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;
        //画面を前方に移動
        anim.transform.SetAsLastSibling();

        CloseCurrent();

        m_PreviouslySelected = newPreviouslySelected;

        //新しい画面を設定し、開きます
        m_Open = anim;
        //画面を開くアニメーションを開始
        m_Open.SetBool(m_OpenParameterId, true);

        //新しく選択されたものとして、新しい画面に要素を設定します
        GameObject go = FindFirstEnabledSelectable(anim.gameObject);
        SetSelected(go);
    }

    //与えられたヒエラルキー内で最初の選択可能な要素を見つけます
    static GameObject FindFirstEnabledSelectable (GameObject gameObject)
    {
        GameObject go = null;
        var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
        foreach (var selectable in selectables) {
            if (selectable.IsActive () && selectable.IsInteractable ()) {
                go = selectable.gameObject;
                break;
            }
        }
        return go;
    }

    //現在開いた画面を閉じます。
    //ナビゲーションも処理します。
    //現在の画面を開く前に使用した選択可能な要素に戻します。
    public void CloseCurrent()
    {
        if (m_Open == null)
            return;

        //画面を閉じるアニメーションを始めます
        m_Open.SetBool(m_OpenParameterId, false);
        
        m_PreviouslyScreen = m_Open;

        //現在の画面を開く前に使用した選択可能な要素に戻します。
        SetSelected(m_PreviouslySelected);
        //画面を閉じるアニメーションが終了するときに、ヒエラルキーを無効にするコルーチンを開始します。
        StartCoroutine(DisablePanelDeleyed(m_Open));
        //画面をすべて閉じます。
        m_Open = null;
    }

    // 画面を閉じるアニメーションの終了を検知し、
    //ヒエラルキーをディアクティベートするコルーチン。
    IEnumerator DisablePanelDeleyed(Animator anim)
    {
        bool closedStateReached = false;
        bool wantToClose = true;
        while (!closedStateReached && wantToClose)
        {
            if (!anim.IsInTransition(0))
                closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);

            wantToClose = !anim.GetBool(m_OpenParameterId);

            yield return new WaitForEndOfFrame();
        }

        if (wantToClose)
            anim.gameObject.SetActive(false);
    }

    //指定したゲームオブジェクトを選択させます。 
    //マウス/タッチパネルを使用しているときは、実際には前に選択したものとして設定し、 
    //現在の選択には何も設定しません。  
    private void SetSelected(GameObject go)
    {
        //ゲームオブジェクトを選択します。
        EventSystem.current.SetSelectedGameObject(go);

        //たった今、キーボードを使っているのなら、それだけで十分です。
        var standaloneInputModule = EventSystem.current.currentInputModule as StandaloneInputModule;
        if (standaloneInputModule != null)
            return;

        //ポインターデバイスを使用しているので、何も選択する必要はありません。 
        //しかし、ユーザーがキーボードに切り替えると、提供されたゲームオブジェクトから移動を開始する必要があります。
        //ここでは、現在の選択を nullに設定します。それにより、指定したゲームオブジェクトが EventSystem の最後の選択になります。
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void PreviousScreen(){
        OpenPanel(m_PreviouslyScreen);
    }
}
