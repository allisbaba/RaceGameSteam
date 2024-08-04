using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarController : MonoBehaviour
{
    // Düzeltme için kullanacaðýmýz tuþ
    public KeyCode resetKey = KeyCode.R;

    // Aracýn ilk pozisyonu ve rotasyonu
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Oyunun baþýnda aracýn ilk pozisyonunu ve rotasyonunu kaydediyoruz
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Reset tuþuna basýldýðýnda aracýn pozisyonunu ve rotasyonunu sýfýrlýyoruz
        if (Input.GetKeyDown(resetKey))
        {
            ResetCar();
        }
    }

    void ResetCar()
    {
        // Aracýn dikey pozisyonunu koruyarak yatay eksendeki rotasyonunu sýfýrlýyoruz
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        // Aracýn hýzýný sýfýrlýyoruz
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
