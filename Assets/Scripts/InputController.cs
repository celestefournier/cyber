using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    void Start()
    {
        // #if UNITY_STANDALONE
        //     Destroy(joystick.gameObject);
        // #endif

        // #if UNITY_ANDROID
        //     moveDirection = new Vector2(joystick.Horizontal, joystick.Vertical);
        // #endif
    }
}
