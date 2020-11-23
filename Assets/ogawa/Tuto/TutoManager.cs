using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour
{
    [System.Serializable]
    struct Data
    {
        public VideoClip video;
        public Sprite image;
        [TextArea(3, 3)] public string head;
        [TextArea(3, 10)] public string description;
    }
    [SerializeField] Data[] data;

    [SerializeField] VideoPlayer videoPlayer = default;
    [SerializeField] Image image = default;
    [SerializeField] Text headText = default;
    [SerializeField] Text descriptionText = default;
    [SerializeField] GameObject xText = default;

    [SerializeField] string sceneName = "Tutorial2";


    int i = 0;

    void Start()
    {
        xText.SetActive(false);
        Show();
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick 1 button 0") || Input.GetKeyDown(KeyCode.B))
        {
            i++;
            xText.SetActive(true);

            if (data.Length <= i)
            {
                SceneManager.LoadScene(sceneName);
                return;
            }
            else if (0 == i)
            {
                xText.SetActive(false);
            }

            Show();
        }

        if (Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown(KeyCode.G))
        {
            if (0 != i)
            {
                i--;
                if (0 == i)
                {
                    xText.SetActive(false);
                }
            }
            Show();
        }
    }

    void Show()
    {
        if (data[i].video != null)
        { videoPlayer.clip = data[i].video; videoPlayer.gameObject.SetActive(true); }
        else
        { image.sprite = data[i].image; videoPlayer.gameObject.SetActive(false); }
        headText.text = data[i].head;
        descriptionText.text = data[i].description;
    }
}
