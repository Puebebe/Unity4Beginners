using UnityEngine;

public class MovingComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    IInput input;
    Transform myTransform;

    public void Initialize(float speed, IInput inputAdapter)
    {
        input = inputAdapter;
        moveSpeed = speed;
    }

    void Start()
    {
        myTransform = transform;
    }

    void Update()
    {
        if (input.GetKey("w"))
            UpdatePosition(Vector3.up);

        if (input.GetKey("s"))
            UpdatePosition(Vector3.down);

        if (input.GetKey("a"))
            UpdatePosition(Vector3.left);

        if (input.GetKey("d"))
            UpdatePosition(Vector3.right);
    }

    private void UpdatePosition(Vector3 moveVector)
    {
        myTransform.position += moveVector * moveSpeed * Time.deltaTime;
    }
}
