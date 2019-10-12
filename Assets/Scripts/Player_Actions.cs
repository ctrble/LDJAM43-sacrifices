using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour {

  public GameObject attackObject;

  void OnEnable() {

  }

  void Update() {
    if (Input.GetButtonDown("Attack")) {
      // if (attackObject.activeInHierarchy) {
      //   attackObject.SetActive(false);
      // }
      if (attackObject != null) {
        attackObject.SetActive(true);
      }
    }
  }
}
