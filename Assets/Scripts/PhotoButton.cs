using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhotoButton
 : MonoBehaviour
{

    public Button photoButton;
    private Texture2D snapshot;

    void Start()
    {
        Button btn = photoButton.GetComponent<Button>();
        btn.onClick.AddListener(photoButtonClick);
    }

    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();
        this.snapshot = ScreenCapture.CaptureScreenshotAsTexture();
        // do something with texture

        System.IO.File.WriteAllBytes("snapshots/snap" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").Replace(":", "-") + ".png", this.snapshot.EncodeToPNG());

        // cleanup
        // Object.Destroy(texture);
    }

    public void LateUpdate()
    {
    }

    private void SaveScreenshot()
    {
        print("saving this ");
        print(this.snapshot);
        print(snapshot);
    }

    void photoButtonClick()
    {
        print("taking photo...");
        GameObject VideoCanvasGO = GameObject.Find("Video Canvas");
        VideoCanvasGO.GetComponent<Canvas>().enabled = true;
        GameObject effectPlaceholder = GameObject.FindGameObjectWithTag("cube");
        Vector3 placeholderPos = effectPlaceholder.transform.localPosition;

        StartCoroutine(RecordFrame());
        SaveScreenshot();
        // Todo: load up some nice text, messages, 3, 2, 1 count down and take a snapshot



    }
}
