using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Lifecycle : MonoBehaviour {

  public int maxHealth;
  public int currentHealth;

  void OnEnable() {

  }

  public void Kill() {
    gameObject.transform.root.gameObject.SetActive(false);
  }

  public void Damage(int damageTaken) {
    currentHealth -= damageTaken;
    Debug.Log(gameObject.transform.root.name + " health left " + currentHealth);

    if (currentHealth <= 0) {
      Kill();
    }
  }
}
