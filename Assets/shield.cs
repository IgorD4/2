using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject obj;
    [SerializeField] public GameObject shieldZone;
    [SerializeField] public GameObject timeLeft;
    void Start()
    {
        obj.GetComponent <Collider2D>().enabled = false;
        obj.GetComponent<SpriteRenderer>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (timeLeft.GetComponent<Text>().text == "50")
        {
            obj.GetComponent<Collider2D>().enabled = true;
            obj.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }
    void OnMouseDown()
    {
        shieldZone.SetActive(true);
    }
    void OnMouseUp()
    {
        shieldZone.SetActive(false);
        obj.SetActive(false);
    }

}
