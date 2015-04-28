using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f,0f,0f,0.1f);
	public Slider healthSlider;
	public Text hpText;

	bool isDead;
	bool damaged;


	// Use this for initialization
	void Awake () {
	
		currentHealth = startingHealth;
		healthSlider.value = currentHealth;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;
		healthSlider.value = currentHealth;
		hpText.text = "HP: " + currentHealth + "/" + startingHealth;

	}

	public void TakeDamage(int amount){

		damaged = true;
		currentHealth -= amount;

		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death(){

		isDead = true;

	}
}
