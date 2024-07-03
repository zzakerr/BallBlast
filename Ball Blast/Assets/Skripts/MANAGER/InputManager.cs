using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
            Debug.Log("Reset");
        }
    }

    private void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
