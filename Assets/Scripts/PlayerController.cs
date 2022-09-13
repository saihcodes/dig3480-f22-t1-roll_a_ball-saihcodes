using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livestext;
    public GameObject winTextObject;
    public GameObject LoseTextObject;
    private Rigidbody rb;
    private int count;
    private int lives;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

        rb = GetComponent<Rigidbody>();
        lives = 3;

        SetCountText();
        LoseTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 25)
        {
            winTextObject.SetActive(true);
        }

        livestext.text = "Lives: " + lives.ToString();
        if (lives == 0)   
        {
            LoseTextObject.SetActive(true);
            Destroy(gameObject);

        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
        }

        else if (count == 12)
        {
            transform.position = new Vector3(50.0f, 0.5f, 50.0f);
        }

        else if (count == 20)
        {
            transform.position = new Vector3(100.0f, 0.5f, 100.0f);
        }
    }
}


