using UnityEngine;

public class GameTimeController : MonoBehaviour
{
    private const string StartTimeKey = "StartTime";
    private static GameTimeController instance;

    private void Awake()
    {
        // Đảm bảo chỉ có một instance tồn tại
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Kiểm tra xem có thời gian bắt đầu đã được lưu trữ trước đó hay không
        if (!PlayerPrefs.HasKey(StartTimeKey))
        {
            // Nếu không, đây là lần đầu tiên bắt đầu chơi, lưu thời gian bắt đầu
            SaveStartTime();
        }
    }

    void OnApplicationQuit()
    {
        // Gọi hàm GameOver khi ứng dụng thoát
        GameOver();
    }

    // Hàm này có thể được gọi khi game kết thúc theo điều kiện nào đó
    public void GameOver()
    {
        // Lấy thời gian bắt đầu từ PlayerPrefs
        float startTime = PlayerPrefs.GetFloat(StartTimeKey);

        // Tính thời gian chênh lệch giữa thời điểm kết thúc và thời điểm bắt đầu
        float gameTime = Time.time - startTime;

        // Gửi thời gian chơi đến hàm xử lý gửi dữ liệu (có thể là hàm gửi lên server)
        SendGameData(gameTime);
    }

    void SaveStartTime()
    {
        // Lưu thời gian bắt đầu vào PlayerPrefs
        PlayerPrefs.SetFloat(StartTimeKey, Time.time);
        PlayerPrefs.Save();
    }

    void SendGameData(float gameTime)
    {
        // Xử lý gửi dữ liệu, có thể là gửi lên server hoặc thực hiện các xử lý khác
        Debug.Log("Playtime: " + gameTime + " seconds");
    }
}
