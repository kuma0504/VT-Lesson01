using UnityEngine;
using UnityEngine.AI;
using UnityEngine.LowLevel;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody), typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Rigidbody rb;
    public MiniCharacter player;

    //現在地の座標
    public Vector3 targetPoint;

    //巡回座標
    public Vector3[] patrolPoint;
    public int currentIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetComponent<NavMeshAgent>(out agent);
        //agent = GetComponent<NavMeshAgent>();と同じ。nullチェックもしてくれる

        TryGetComponent(out rb);
        //シーン上からPlayerのコンポーネントを持つオブジェクトを取得する
        player = GameObject.FindFirstObjectByType<MiniCharacter>();

    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbodyの影響軽減
        rb. linearVelocity = Vector3.zero;

        Vector3 posA = player.transform.position;
        Vector3 posB = transform.position;
        float distance = Vector3.Distance(posA, posB);

        if(distance < 3)
        {
            targetPoint = posA;     //playerの座標を入れる
        }
        else
        {
            targetPoint = patrolPoint[currentIndex % 3];     //自身(enemy)の座標を入れる
        }

        float patrollDistance = Vector3.Distance(patrolPoint[currentIndex % 3], transform.position);
        if(patrollDistance < 1f)
        {
            currentIndex++;
        }

        //エージェントに目的座標を設定
        //agent.SetDestination(player.transform.position);
        agent.SetDestination(targetPoint);
    }
}
