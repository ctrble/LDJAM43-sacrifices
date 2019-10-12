using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

  public int playerSpeed = 10;
  private float circleFunction = 0.7071f;
  public LayerMask staticLayer;
  public BoxCollider2D boxCollider;
  public Animator animator;

  void OnEnable() {
    if (boxCollider == null)
      boxCollider = gameObject.GetComponent<BoxCollider2D>();

    if (animator == null)
      animator = gameObject.GetComponentInChildren<Animator>();
  }

  void Update() {
    Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

    Vector3 desiredPosition = transform.position + input * ConvertSpeedForDiagonal(input, playerSpeed) * Time.deltaTime;
    Quaternion desiredRotation = FaceForward(input);

    bool blockedMovement = Physics2D.OverlapBox(desiredPosition, boxCollider.size, AngleOfRotation(desiredRotation), staticLayer);

    if (input != Vector3.zero) {
      if (!blockedMovement) {
        transform.position = desiredPosition;
        animator.SetBool("moving", true);
      }
      // else if (blockedMovement) {
      //   Debug.Log("blocked");
      // }

      transform.rotation = desiredRotation;
    }
    else {
      animator.SetBool("moving", false);
    }
  }

  Quaternion FaceForward(Vector3 direction) {
    Quaternion newRotation = direction != Vector3.zero ? Quaternion.LookRotation(Vector3.forward, direction) : transform.rotation;
    return newRotation;
  }

  float AngleOfRotation(Quaternion rotation) {
    float angle = Quaternion.Angle(Quaternion.identity, rotation);
    return angle;
  }

  float ConvertSpeedForDiagonal(Vector3 direction, float speed) {
    bool isDiagonal = direction.x != 0 && direction.y != 0;
    float speedModifier = isDiagonal ? circleFunction : 1;
    float newSpeed = speed * speedModifier;
    return newSpeed;
  }
}
