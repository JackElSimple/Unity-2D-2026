using UnityEngine;
public class moverCesta : MonoBehaviour
{
    float yPosition;
    public float speed;
    void Start()
    {
        speed = 5;
        yPosition = 0;
    }
    void Update()
    {
        yPosition = gameObject.GetComponent<Transform>().position.y;

        transform.Translate(Input.GetAxis("Horizontal") * speed*Time.deltaTime, 0.0f, 0.0f);


        if (yPosition < 1) { transform.Translate(0.0f, Input.GetAxis("Vertical") * speed*Time.deltaTime, 0.0f); }


        if (yPosition > -3.61)
        {
            transform.Translate(0.0f, -9.8f*Time.deltaTime, 0.0f);
        }

        }
}