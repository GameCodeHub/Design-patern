using UnityEngine;

public class UnifiedGameFacade : MonoBehaviour
{
    private GameFacade gameFacade;

    void Start()
    {
        // Khởi tạo GameFacade
        gameFacade = new GameFacade();

        // Bắt đầu trò chơi
        gameFacade.StartGame();
    }

    void Update()
    {
        // Nhấn phím E để kết thúc trò chơi
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameFacade.EndGame();
        }

        // Nhấn phím R để khởi động lại trò chơi
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameFacade.StartGame();
        }
    }

    // Facade Pattern
    public class GameFacade
    {
        private AudioManager audioManager;
        private UIManager uiManager;
        private GameStateManager gameStateManager;

        public GameFacade()
        {
            // Khởi tạo các hệ thống nội bộ
            audioManager = new AudioManager();
            uiManager = new UIManager();
            gameStateManager = new GameStateManager();
        }

        public void StartGame()
        {
            Debug.Log("[GameFacade] Starting game...");
            audioManager.PlaySound("StartSound");
            gameStateManager.SetGameState("Playing");
            uiManager.ShowMessage("Welcome to the Game!");
        }

        public void EndGame()
        {
            Debug.Log("[GameFacade] Ending game...");
            audioManager.PlaySound("EndSound");
            gameStateManager.SetGameState("GameOver");
            uiManager.ShowMessage("Thanks for playing!");
        }
    }

    // AudioManager (Subsystem)
    public class AudioManager
    {
        public void PlaySound(string soundName)
        {
            Debug.Log($"[AudioManager] Playing sound: {soundName}");
        }
    }

    // UIManager (Subsystem)
    public class UIManager
    {
        public void ShowMessage(string message)
        {
            Debug.Log($"[UIManager] Showing message: {message}");
        }
    }

    // GameStateManager (Subsystem)
    public class GameStateManager
    {
        public void SetGameState(string state)
        {
            Debug.Log($"[GameStateManager] Game state set to: {state}");
        }
    }
}
