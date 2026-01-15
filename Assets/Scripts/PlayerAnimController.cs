using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private AnimController animController;
    [SerializeField] private CharacterControls characterController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveThreshold = 0.25f; // tweak in inspector or code

    // Update is called once per frame
    void Update()
    {
        print("is_grounded: " + characterController.groundedNow);

        if (!characterController.groundedNow)
        {
            if (rb.velocity.y > 0)
                animController.PlayAnimation("jump");
            else
                animController.PlayAnimation("fall");
        }
        else
        {
            Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (horizontalVelocity.magnitude > moveThreshold)
            {
                animController.PlayAnimation("sprint");
            }
            else if(horizontalVelocity.magnitude <= moveThreshold && horizontalVelocity.magnitude != 0)
            {
                animController.PlayAnimation("walk");
            }
            else
            {
                animController.PlayAnimation("idle");
            }
        }
    }
}
