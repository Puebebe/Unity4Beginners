public class InputAdapter : IInput
{
    public bool GetKey(string input)
    {
        return UnityEngine.Input.GetKey(input);
    }
}