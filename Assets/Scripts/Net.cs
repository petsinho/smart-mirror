using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{

    GameObject scoreText;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText = GameObject.FindGameObjectWithTag("score");
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            audioSource.Play();
            var textComponent = scoreText.GetComponent<TextMesh>();
            textComponent.text = (int.Parse(textComponent.text) + 1).ToString();
            collision.gameObject.GetComponent<Rigidbody>().drag = .55f;
        }
    }
}
