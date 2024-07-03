using UnityEngine;

public class Colors32Manager: MonoBehaviour
{
    public static Colors32Manager Instance;

    [SerializeField] private Color32[] colors32;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Color32 GetRandomColor32()
    {        
        return colors32[Random.Range(0, colors32.Length)];
    }
}
