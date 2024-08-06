using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol3 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 200.0f;
    public float damage = 10f;
    public float range = 100f;
    public GameObject chooseshootingmaterial; // Mermi prefab'ı için referans
    public float bulletspeed = 20f; // Mermi hızı
    public bool iscolliding = false;
    public float timeRemaining = 10; // diyelim ki 10'dan geri sayıyoruz
    public bool gameover = false;
    private void Start()
    {
        StartCoroutine(Countdown()); // geri sayım, oyun başlar başlamaz start alıyor
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(moveHorizontal, 0, moveVertical);
        
        if (Input.GetAxis("Mouse X") != 0)
        {
            float turn = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
            transform.Rotate(0, turn, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        GameObject bulletvar = Instantiate(chooseshootingmaterial, transform.position, Quaternion.identity); // Mermiyi oluştur
        Rigidbody rb = bulletvar.AddComponent<Rigidbody>(); // Rigidbody bileşeni ekle
        rb.useGravity = false; // Shootng material'ı yerçekimi uygulanmasın
        rb.velocity = transform.forward * bulletspeed; // Shootng material'ı ileri doğru hareket ettir

        // Shootng material'ı belirli bir süre sonra yok etmek (eğer chooseabullet derseniz sorun oluyor dersten hatırlarsanız. Çünkü oluşturanı değil, runtime esnasında oluşanı sileceğiz.)
        Destroy(bulletvar, 2f); // 2 saniye sonra mermiyi yok et
    }
    IEnumerator Countdown() // sayımı başlayatacak fonksiyonu çağırıyoruz
    {
        while (timeRemaining > 0) // Eğer daha süre varsa kısmı...
        {
            if (gameover == false)
            {
                Debug.Log("Time remaining: " + timeRemaining); // kalan süreyi geriye kalan süre ve sürenin değeri ile birlikte bastırıyoruz
                yield return new WaitForSeconds(1); // süreyi birer birer düşüyoruz
                timeRemaining--; // geri kalan süreyi işletiyoruz
            }
        }

        Debug.Log("Time over. You have LOST! Try again!"); // süre bittiğinde yani 0dan büyük timeRemaining kalmadığında konsola süre bitti yazdırıyoruz
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            iscolliding = true;
        }
        if (iscolliding)
        {
            Debug.Log("You have WON. Time remaining:"+timeRemaining+"seconds");
            gameover = true;
        }
    }


}
