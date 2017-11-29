using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    public Text countText;
    public Text winText;
    private int count;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }
    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
    private void FixedUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop) { 
            float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed); }
       else{
float moveHorizontal = Input.acceleration.x;
 float       moveVertical = Input.acceleration.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    rb.AddForce(movement* speed * 2);}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winText.text = "You Win!";
        }
    }
}
 