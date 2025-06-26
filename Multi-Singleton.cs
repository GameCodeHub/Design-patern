using UnityEngine;

// Lớp Singleton Generic giúp tạo Singleton tự động cho bất kỳ lớp nào kế thừa từ MonoBehaviour
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; // Biến tĩnh lưu trữ instance duy nhất của Singleton

    // Truy cập Instance của Singleton
    [System.Obsolete]
    public static T Instance
    {
        get
        {
            if (instance == null) // Nếu instance chưa tồn tại
            {
                instance = FindObjectOfType<T>(); // Tìm trong scene hiện tại

                if (instance == null) // Nếu vẫn không tìm thấy
                {
                    // Tự động tạo mới Singleton
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject); // Đảm bảo không bị phá hủy khi chuyển scene
                }
            }
            return instance; // Trả về instance duy nhất
        }
    }

    // Đảm bảo chỉ có một instance tồn tại, và giữ lại giữa các scene
    protected virtual void Awake()
    {
        if (instance == null) // Nếu instance chưa được gán
        {
            instance = this as T; // Gán instance cho đối tượng hiện tại
            DontDestroyOnLoad(gameObject); // Đảm bảo đối tượng này không bị phá hủy
        }
        else if (instance != this) // Nếu đã tồn tại instance khác
        {
            Destroy(gameObject); // Phá hủy đối tượng mới để tránh trùng lặp
        }
    }
}

// Lớp GameManager kế thừa từ Singleton<GameManager>
// Đây là một ví dụ cụ thể về việc sử dụng Singleton Generic
public class GameManager : Singleton<GameManager>
{
    public int playerScore; // Lưu trữ điểm số của người chơi

    // Ghi đè phương thức Awake để thêm logic tùy chỉnh khi GameManager khởi tạo
    protected override void Awake()
    {
        base.Awake(); // Gọi logic từ lớp Singleton
        Debug.Log("GameManager Initialized"); // In ra Console để kiểm tra khởi tạo
    }

    // Hàm để cộng điểm cho người chơi
    public void AddScore(int score)
    {
        playerScore += score; // Tăng điểm số
        Debug.Log($"Player Score: {playerScore}"); // In ra điểm số hiện tại
    }
}
public class AudioManager : Singleton<AudioManager>
{
    // Hàm để phát âm thanh
    public void PlaySound(string soundName)
    {
        Debug.Log($"Playing sound: {soundName}"); // In ra tên âm thanh đang phát
    }
}
// Lớp này có thể được sử dụng trong các scene khác nhau mà không cần phải tạo lại instance
// Ví dụ:
public class GameManagerUser : MonoBehaviour
{
    [System.Obsolete]
    private void Start()
    {
        // Sử dụng GameManager
        GameManager.Instance.AddScore(10);
        AudioManager.Instance.PlaySound("Jump");
    }
}
