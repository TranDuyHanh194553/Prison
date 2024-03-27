using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Tốc độ xoay mỗi giây

    private float currentRotationY = 0f; // Góc xoay hiện tại trên trục Y
    private int rotationDirection = 1; // Hướng xoay (1: tăng góc, -1: giảm góc)
    public float max;

    void Update()
    {   
        float min = max - 90.0f;
        // Xoay vật thể quanh trục Y
        currentRotationY += rotationSpeed * rotationDirection * Time.deltaTime;

        // Kiểm tra xem đã đạt góc tối đa hoặc góc tối thiểu
        if (currentRotationY >= max)
        {
            currentRotationY = max;
            rotationDirection = -1; // Đổi hướng xoay về ngược lại
        }
        else if (currentRotationY <= min)
        {
            currentRotationY = min;
            rotationDirection = 1; // Đổi hướng xoay lại ban đầu
        }

        // Áp dụng xoay
        transform.rotation = Quaternion.Euler(-90.0f, currentRotationY, 0.0f);
    }
}
