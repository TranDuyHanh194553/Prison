using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;
    [SerializeField] private float minX, maxX, minZ, maxZ;

    [SerializeField] private float moveSpeed; // Tốc độ di chuyển cố định (m/s)
    [SerializeField] private float rotationSpeed; // Tốc độ quay (độ/giây)
    public NavMeshAgent agent;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    [SerializeField] private float timeToChangeDirection = 5f; // Thời gian để thay đổi hướng

    private float elapsedTime = 0.0f;
    private bool isRotating = false;
    [SerializeField] private float stopTime = 0.5f; // Thời gian dừng lại sau khi đến điểm đích
    private float currentStopTime = 0.0f; // Thời gian hiện tại đã dừng lại
    private bool isStopping = false; // Đang dừng lại hay không

    private void Awake()
    {
        if (!m_animator) { m_animator = gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { m_rigidBody = gameObject.GetComponent<Rigidbody>(); }
    }

    private void Start()
    {
        UpdateTargetPosition();
        UpdateTargetRotation();
    }

    private void FixedUpdate()
    {
        if (!isStopping)
        {
            MoveUpdate();
        }
        else
        {
            currentStopTime += Time.fixedDeltaTime;
            if (currentStopTime >= stopTime)
            {
                isStopping = false;
                currentStopTime = 0.0f;

                if (isRotating)
                {
                    UpdateTargetRotation();
                }
                else
                {
                    UpdateTargetPosition();
                }
            }
        }
    }

    private void MoveUpdate()
    {
        float step = moveSpeed * Time.deltaTime;

        if (!isRotating)
        {
            agent.SetDestination(targetPosition);
            m_animator.SetFloat("MoveSpeed", moveSpeed);
            m_animator.SetBool("isWalking", true);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            m_animator.SetBool("isWalking", false);

            if (isRotating)
            {
                isRotating = false;
                isStopping = true;
            }
            else
            {
                isRotating = true;
                isStopping = true;
            }
        }

        if (isStopping)
        {
            // Chờ thời gian dừng lại
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToChangeDirection)
            {
                elapsedTime = 0.0f;
                isRotating = !isRotating;
                isStopping = true;

                if (isRotating)
                {
                    UpdateTargetRotation();
                }
                else
                {
                    UpdateTargetPosition();
                }
            }
        }
    }

    private void UpdateTargetPosition()
    {
        Vector3 newTargetPosition = GetValidRandomPosition();

        if (newTargetPosition != Vector3.zero)
        {
            targetPosition = newTargetPosition;
        }
    }

    private void UpdateTargetRotation()
    {
        float randomYRotation = Random.Range(0f, 360f);
        targetRotation = Quaternion.Euler(0, randomYRotation, 0);
    }

    Vector3 GetValidRandomPosition()
    {
        Vector3 randomPosition;
        int attempts = 0;
        do
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            randomPosition = new Vector3(randomX, 0, randomZ);

            if (!IsPointInNotWalkableArea(randomPosition))
            {
                return randomPosition;
            }

            attempts++;
        } while (attempts < 5); // Thử tối đa 10 lần

        return Vector3.zero; // Không tìm thấy điểm hợp lệ sau 10 lần thử
    }

    bool IsPointInNotWalkableArea(Vector3 position)
    {
        NavMeshHit hit;
        if (!NavMesh.SamplePosition(position, out hit, maxDistance: 4f, NavMesh.AllAreas))
        {
            return true;
        }
        return false;
    }
}
