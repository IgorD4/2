using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMove2D : MonoBehaviour
{
    [SerializeField] public Text timeLeft;
    [SerializeField] public GameObject obj;
    [SerializeField] public GameObject endPanel;
    [SerializeField] public GameObject wind;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private bool check = false;
    void Start()
    {
        StartCoroutine(Timer());
        obj.GetComponent<Collider2D>().isTrigger = true;
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        Physics2D.gravity = new Vector2(0, -9.8f);
    }

    void OnMouseDown()
    {
        check = true;
        obj.GetComponent<Rigidbody2D>().gravityScale = 0;

    }
    void OnMouseUp()
    {
        check = false;
        obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        obj.GetComponent<Collider2D>().isTrigger = false;
    }
    IEnumerator Timer()
    {
        for (int i = 60; i >= 0 ; i--)
        {
            if (i == 45)
            {
                wind.GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                wind.GetComponent<Collider2D>().enabled = false;
            }
            timeLeft.text = (i).ToString();
            yield return new WaitForSeconds(1);
            if(i == 0)
            {
                endPanel.SetActive(true);
                obj.GetComponent<Collider2D>().enabled = false;
                Time.timeScale = 0;
            }
        }
    }
    void Update()
    {
        if (check == true)
        {
            if (Input.GetMouseButton(0))
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            endPanel.SetActive(true);
            obj.GetComponent<Collider2D>().enabled = false;
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "GameController")
        {
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
