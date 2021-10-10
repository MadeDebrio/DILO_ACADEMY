using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode upButton;// Tombol untuk menggerakkan ke atas
    public KeyCode downButton ;// Tombol untuk menggerakkan ke bawah
    public float speed;// Kecepatan gerak
    public float yBoundary ;// Batas atas dan bawah game scene (Batas bawah menggunakan minus (-))
    private Rigidbody2D rigidBody2D;// Rigidbody 2D raket ini
    private int score;// Skor pemain 
    private ContactPoint2D lastContactPoint;// Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
        yBoundary = 9.0f;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 velocity = rigidBody2D.velocity;// Dapatkan kecepatan raket sekarang.

        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas).
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke bawah).
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apa-apa, kecepatannya nol.
        else
        {
            velocity.y = 0.0f;
        }
        
        rigidBody2D.velocity = velocity;// Masukkan kembali kecepatannya ke rigidBody2D.

        
        Vector3 position = transform.position;// Dapatkan posisi raket sekarang.

        // Jika posisi raket melewati batas atas (yBoundary), kembalikan ke batas atas tersebut.
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut.
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukkan kembali posisinya ke transform.
        transform.position = position;
    }

    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }

    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    
}
