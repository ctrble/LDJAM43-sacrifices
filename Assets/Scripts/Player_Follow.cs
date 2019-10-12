using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour {

  public GameObject target;
  public float smoothTime = 0.1f;
  private Vector3 velocity = Vector3.zero;

  void Update() {

    Vector3 offset = new Vector3(0, 0, -10);
    transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref velocity, smoothTime);

  }
}
