

using UnityEngine;

public class Anima : MonoBehaviour
{
    Animator anima;
    private string currentState;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        if (anima == null) Debug.LogError("Animator not attached ");
    }
    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        //play the animation
        anima.Play(newState);

        //reassign the current state
        currentState = newState;
    }



    //Animations
    public static class PlayerAnimations
    {
        public const string WALK_UP = "WALK_UP";
        public const string WALK_DOWN = "WALK_DOWN";
        public const string WALK_LEFT = "WALK_LEFT";
        public const string WALK_RIGHT = "WALK_RIGHT";

        public const string IDLE_UP = "IDLE_UP";

        public const string IDLE_DOWN = "IDLE_DOWN";

        public const string IDLE_LEFT = "IDLE_LEFT";

        public const string IDLE_RIGHT = "IDLE_RIGHT";

        public const string GRAB = "Grab";

    }
}