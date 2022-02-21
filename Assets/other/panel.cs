using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    [SerializeField] public Text textBox;
    [SerializeField] public Text timeLeft;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft.GetComponent<Text>().text == "0")
        {
            textBox.GetComponent<Text>().text = "Loss";
        }
        else
        {
            textBox.GetComponent<Text>().text = "Complete";
        }

    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
