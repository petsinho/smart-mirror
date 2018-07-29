
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
public class PhotoButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button photoButton;
    public Transform brick;

    void Start()
    {
        Button btn = photoButton.GetComponent<Button>();
        btn.onClick.AddListener(PhotoButtonClick);
    }

    void PhotoButtonClick()
    {
        GameObject VideoCanvasGO = GameObject.Find("Video Canvas");
        print(VideoCanvasGO);
        VideoCanvasGO.GetComponent<Canvas>().enabled = true;
        GameObject effectPlaceholder = GameObject.FindGameObjectWithTag("cube");
        Vector3 placeholderPos = effectPlaceholder.transform.localPosition;

        for (int y = 0; y < 250; y += 45)
        {
            for (int x = 0; x < 250; x += 40)
            {
                Instantiate(brick, new Vector3(placeholderPos.x + x, placeholderPos.y + y, placeholderPos.z), Quaternion.identity);
            }
        }

    }

}