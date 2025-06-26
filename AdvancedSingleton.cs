using UnityEngine;

public class AdvancedSingleton : MonoBehaviour
{
    private static AdvancedSingleton instance;

    public static AdvancedSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                // Tự tạo Singleton nếu chưa tồn tại
                GameObject singletonObject = new GameObject("AdvancedSingleton");
                instance = singletonObject.AddComponent<AdvancedSingleton>();
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Xóa GameObject trùng lặp
        }
    }
    // Thêm các phương thức và thuộc tính cần thiết cho Singleton tại đây
    public void ExampleMethod()
    {
        Debug.Log("This is an example method in the AdvancedSingleton class.");
    }
    public void ResetInstance()
    {
        instance = null; // Cho phép tạo lại instance nếu cần
        Debug.Log("AdvancedSingleton instance has been reset.");
    }
}
// MonoBehaviour này sẽ đảm bảo rằng chỉ có một instance của AdvancedSingleton tồn tại trong toàn bộ ứng dụng.
// Bạn có thể gọi AdvancedSingleton.Instance để truy cập instance này từ bất kỳ đâu trong mã

// Ví dụ sử dụng AdvancedSingleton
public class AdvancedSingletonExampleUsage : MonoBehaviour
{
    private void Start()
    {
        // Sử dụng AdvancedSingleton
        AdvancedSingleton.Instance.ExampleMethod();
        
        // Reset instance nếu cần
        // AdvancedSingleton.Instance.ResetInstance();
    }
}   