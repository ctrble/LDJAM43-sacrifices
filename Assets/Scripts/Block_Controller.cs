using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Controller : MonoBehaviour {

  public float disableDelay = 0.5f;
  public GameObject hurtableObject;
  public BoxCollider2D boxCollider;
  // public LayerMask blockLayer;
  // public LayerMask hurtLayer;

  void OnEnable() {
    Block();
    StartCoroutine(Disable(disableDelay));
  }

  void Block() {
    if (hurtableObject.layer == LayerMask.NameToLayer("Hurt")) {
      hurtableObject.layer = LayerMask.NameToLayer("Block");
    }
  }

  IEnumerator Disable(float delay) {
    yield return new WaitForSeconds(delay);
    gameObject.SetActive(false);
  }

  void OnDisable() {
    hurtableObject.layer = LayerMask.NameToLayer("Hurt");
  }
}
