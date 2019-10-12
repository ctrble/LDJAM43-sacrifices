using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

  public float disableDelay = 0.5f;
  public int damageAmount;
  public BoxCollider2D boxCollider;
  public Collider2D collider;
  public LayerMask hurtLayer;

  void OnEnable() {

    if (boxCollider == null)
      boxCollider = gameObject.GetComponent<BoxCollider2D>();

    collider = boxCollider;

    DetectHits();
    StartCoroutine(Disable(disableDelay));
  }

  IEnumerator Disable(float delay) {
    yield return new WaitForSeconds(delay);
    gameObject.SetActive(false);
  }

  void Update() {
  }

  void DetectHits() {

    int numColliders = 4;
    Collider2D[] colliders = new Collider2D[numColliders];
    ContactFilter2D contactFilter = new ContactFilter2D();
    contactFilter.layerMask = hurtLayer;
    contactFilter.useLayerMask = true;

    int hit = Physics2D.OverlapBox(transform.position, boxCollider.size, AngleOfRotation(transform.rotation), contactFilter, colliders);

    for (int i = 0; i < colliders.Length; i++) {
      if (colliders[i] != null) {
        if (colliders[i].CompareTag("Body")) {
          Debug.Log(colliders[i].gameObject.transform.root.name);

          colliders[i].transform.root.GetComponent<Entity_Lifecycle>().Damage(damageAmount);
        }
      }
    }
  }

  float AngleOfRotation(Quaternion rotation) {
    float angle = Quaternion.Angle(Quaternion.identity, rotation);
    return angle;
  }
}
