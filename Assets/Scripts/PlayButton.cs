
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button playButton;
    public Transform stone1;
    public GameObject initialStonePlaceholder;

    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(playButtonClick);
    }

    void playButtonClick()
    {
        GameObject VideoCanvasGO = GameObject.Find("Video Canvas");
        VideoCanvasGO.GetComponent<Canvas>().enabled = true;
        Vector3 placeholderPos = initialStonePlaceholder.transform.localPosition;

        for (int y = 0; y < 180; y += 45)
        {
            for (int x = 0; x < 180; x += 40)
            {
                var transform = Instantiate(stone1, new Vector3(placeholderPos.x + x, placeholderPos.y + y, placeholderPos.z), Quaternion.identity);
                transform.GetComponent<Rigidbody>().useGravity = true;
                transform.GetComponent<Rigidbody>().mass = 50;
            }
        }

    }

}