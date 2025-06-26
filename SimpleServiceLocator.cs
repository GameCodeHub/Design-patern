using System;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

// Service Locator đơn giản
public static class SimpleServiceLocator
{
    // Từ điển lưu trữ các dịch vụ
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    // Đăng ký dịch vụ
    public static void Register<T>(T service)
    {
        services[typeof(T)] = service; // Ghi đè nếu dịch vụ đã tồn tại
    }

    // Truy xuất dịch vụ
    public static T Get<T>()
    {
        return (T)services[typeof(T)]; // Ép kiểu và trả về instance của dịch vụ
    }
    // Kiểm tra xem dịch vụ đã được đăng ký hay chưa
    public static bool IsRegistered<T>()
    {
        return services.ContainsKey(typeof(T)); // Kiểm tra xem từ điển có chứa dịch vụ hay không
    }
    public class GameManager
{
    public int playerScore;

    public void AddScore(int score)
    {
        playerScore += score;
        Debug.Log($"[GameManager] Player Score: {playerScore}");
    }
}

    public class AudioManager
    {
        public void PlaySound(string soundName)
        {
            Debug.Log($"[AudioManager] Playing sound: {soundName}");
        }
    }

    // Ví dụ sử dụng
   
}
// MonoBehaviour để đăng ký và sử dụng dịch vụ
public class ServiceUser : MonoBehaviour
{
    private void Start()
    {
        // Đăng ký dịch vụ
        SimpleServiceLocator.Register(new SimpleServiceLocator.GameManager());
        SimpleServiceLocator.Register(new SimpleServiceLocator.AudioManager());

        // Sử dụng dịch vụ
        var gameManager = SimpleServiceLocator.Get<SimpleServiceLocator.GameManager>();
        gameManager.AddScore(10);

        var audioManager = SimpleServiceLocator.Get<SimpleServiceLocator.AudioManager>();
        audioManager.PlaySound("Jump");
    }
}