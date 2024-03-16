using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject HealthBar;
    public GameObject GameControllerObject;

    public Sprite[] sprites = new Sprite[3];

    public AudioSource AudioSource;
    public AudioClip laserSound;

    public TextMeshProUGUI healthLevelText;
    public TextMeshProUGUI damageLevelText;
    public TextMeshProUGUI fireRateLevelText;

    public TextMeshProUGUI healthCostText;
    public TextMeshProUGUI damageCostText;
    public TextMeshProUGUI fireRateCostText;

    bool canFire = true;

    float maxHealth = 10f;
    float health = 10f;
    public float damage = 1f;
    float fireRate = 1f;

    int healthLevel = 0;
    int damageLevel = 0;
    int fireRateLevel = 0;

    float vertSpeed = 0;
    float horzSpeed = 0;
    float maxVertSpeed = 8f;
    float maxHorzSpeed = 8f;
    float acceleration = 8f;
    float decceleration = 0;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        healthLevelText.text = "Health LVL: " + healthLevel;
        healthCostText.text = "Cost: " + (250 + 50 * healthLevel);
        damageLevelText.text = "Damage LVL: " + damageLevel;
        damageCostText.text = "Cost: " + (250 + 50 * damageLevel);
        fireRateLevelText.text = "Fire Rate LVL: " + fireRateLevel;
        fireRateCostText.text = "Cost: " + (250 + 50 * fireRateLevel);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && canFire) { Fire(); }
        HealthBar.GetComponent<Image>().fillAmount = health / maxHealth;
        
    }
    public void StartWave()
    {
        health = maxHealth;
    }
    public void Fire()
    {
        GameObject BulletShot = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        BulletShot.GetComponent<BulletScript>().damage = damage;
        canFire = false;
        AudioSource.PlayOneShot(laserSound);
        StartCoroutine(ShootDelay());
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) 
        { 
            GameControllerObject.GetComponent<GameController>().EndGame();
            healthLevel = 0;
            damageLevel = 0;
            fireRateLevel = 0;
            maxHealth = 10f;
            health = 10f;
            this.damage = 1f;
            fireRate = 1f;
        }
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow) && vertSpeed < maxVertSpeed) { vertSpeed += acceleration * Time.deltaTime; transform.rotation = Quaternion.Euler(45f, 0, 45);  }
        else if (Input.GetKey(KeyCode.DownArrow) && vertSpeed > -maxVertSpeed) { vertSpeed -= acceleration * Time.deltaTime; transform.rotation = Quaternion.Euler(-45f, 0, -45); }
        else { if (vertSpeed > 0) { vertSpeed -= acceleration * Time.deltaTime; } if (vertSpeed < 0) { vertSpeed += acceleration * Time.deltaTime; } transform.rotation = Quaternion.Euler(0, 0, 0); }
        if (Input.GetKey(KeyCode.RightArrow) && horzSpeed < maxHorzSpeed) { horzSpeed += acceleration * Time.deltaTime; transform.rotation = Quaternion.Euler(0, 45, 0); GetComponent<SpriteRenderer>().sprite = sprites[1]; }
        else if (Input.GetKey(KeyCode.LeftArrow) && horzSpeed > -maxHorzSpeed) { horzSpeed -= acceleration * Time.deltaTime; transform.rotation = Quaternion.Euler(0, -45, 0); GetComponent<SpriteRenderer>().sprite = sprites[2]; }
        else { if (horzSpeed > 0) { horzSpeed -= acceleration * Time.deltaTime; } if (horzSpeed < 0) { horzSpeed += acceleration * Time.deltaTime; } transform.rotation = Quaternion.Euler(0, 0, 0); GetComponent<SpriteRenderer>().sprite = sprites[0]; }

        transform.position = new Vector3(transform.position.x + horzSpeed * Time.deltaTime, transform.position.y + vertSpeed * Time.deltaTime, 0 );

        if (transform.position.x >= 10.5f) { transform.localPosition = new Vector3(10.4f, transform.position.y, transform.position.z); horzSpeed = 0; }
        if (transform.position.x <= -10.5f) { transform.localPosition = new Vector3(-10.4f, transform.position.y, transform.position.z); horzSpeed = 0; }
        if (transform.position.y >= 5f) { transform.localPosition = new Vector3(transform.position.x, 4.9f, transform.position.z); vertSpeed = 0; }
        if (transform.position.y <= -5f) { transform.localPosition = new Vector3(transform.position.x, -4.9f, transform.position.z); vertSpeed = 0; }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public void IncreaseStat(string name)
    {
        if (name == "Health" && GameControllerObject.GetComponent<GameController>().points >= 250 + 50 * healthLevel) 
        { GameControllerObject.GetComponent<GameController>().points -= 250 + 50 * healthLevel; healthLevel += 1; health = 10f + 5f * healthLevel; }
        if (name == "Damage" && GameControllerObject.GetComponent<GameController>().points >= 250 + 50 * damageLevel) 
        { GameControllerObject.GetComponent<GameController>().points -= 250 + 50 * damageLevel; damageLevel += 1; damage = 1f + 1.5f * damageLevel; }
        if (name == "FireRate" && GameControllerObject.GetComponent<GameController>().points >= 250 + 50 * fireRateLevel) 
        { GameControllerObject.GetComponent<GameController>().points -= 250 + 50 * fireRateLevel; fireRateLevel += 1; fireRate = 1f / (1 + 0.2f * fireRateLevel); }

        healthLevelText.text = "Health LVL: " + healthLevel;
        healthCostText.text = "Cost: " + (250 + 50 * healthLevel);
        damageLevelText.text = "Damage LVL: " + damageLevel;
        damageCostText.text = "Cost: " + (250 + 50 * damageLevel);
        fireRateLevelText.text = "Fire Rate LVL: " + fireRateLevel;
        fireRateCostText.text = "Cost: " + (250 + 50 * fireRateLevel);
    }
}
