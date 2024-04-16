using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
	public Timer timer;

    private int selectedOption = 0;

	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar; 

    // Start is called before the first frame update
    void Start()
    {
		if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
		
        UpdateCharacter(selectedOption);
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
		// Changed KeyCode.Space to KeyCode.T for testing
		if (Input.GetKeyDown(KeyCode.T))
		{
			TakeDamage(20);
			
		}

		if (currentHealth <= 0)
		{
			SceneManager.LoadScene("DeathScreen");
		}
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	public void HealthBox(int health)
	{
		currentHealth += health;

		healthBar.SetHealth(currentHealth);
	}
	private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "MySpike")
        {
			// Minus health
			TakeDamage(15);
        }
		
		if (obj.tag == "MyBox")
        {
			// Health Boost
			HealthBox(20);
			Destroy(obj.gameObject);
        }

		if (obj.tag == "Flag") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if (obj.tag == "Lava")
		{
			TakeDamage(10);
		}

		if (obj.tag == "Timer")
        {
            timer.TimerPickup(20);
			// Gets rid of timer object after player gets it
			Destroy((UnityEngine.Object)obj.gameObject);
        }

		if (obj.tag == "FallingSpike")
		{
			TakeDamage(5);
			Destroy(obj.gameObject);
		}

		if (obj.tag == "Blade")
		{
			TakeDamage(10);
		}
    }

	private void UpdateCharacter(int selectedOption)
	{
		if (characterDB != null)
    	{
        	Character character = characterDB.GetCharacter(selectedOption);
        	if (character != null && artworkSprite != null)
        	{
            	artworkSprite.sprite = character.characterSprite;
        	}
        	else
        	{
            	Debug.LogError("character is null");
        	}
    	}
    	// else
    	// {
        // 	Debug.LogError("characterdatabase is null");
    	// }
	}

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

}
