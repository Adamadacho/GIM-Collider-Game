using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 7.0f; // Prędkość ruchu kuli

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Pobieranie wejścia od gracza
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Tworzenie wektora ruchu na podstawie wejścia
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Przypisanie ruchu do komponentu Rigidbody
        rb.velocity = movement * moveSpeed;
    }
}
