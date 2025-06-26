using UnityEngine;

public class NormalSingleton : MonoBehaviour
{
    public static NormalSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại giữa các scene
        }
        else
        {
            Destroy(gameObject); // Xóa instance trùng lặp
        }
    }
    // Thêm các phương thức và thuộc tính cần thiết cho Singleton tại đây
    public void ExampleMethod()
    {
        Debug.Log("This is an example method in the NormalSingleton class.");
    }
}
// MonoBehaviour này sẽ đảm bảo rằng chỉ có một instance của NormalSingleton tồn tại trong toàn bộ ứng dụng.
// Bạn có thể gọi NormalSingleton.Instance để truy cập instance này từ bất kỳ đâu trong mã
public class ExampleUsage : MonoBehaviour
{
    private void Start()
    {
        // Sử dụng NormalSingleton
        NormalSingleton.Instance.ExampleMethod();
    }
}
    
