using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 어떠한 정보를 담고 있는 객체 클래스
[System.Serializable]
public class ObjectInfo
{
    // 정보
    public GameObject goPrefab; // 필요한 것들 생성
    public int count; // 생성시킬 개수
    public Transform tfPoolParent; // 어느 위치의 부모 자식 위치로 설정할지
}

public class ObjectPool : MonoBehaviour
{
    // 공유자원 instance를 통해 어디서든 public 변수, 함수에 접근이 가능
    public static ObjectPool instance;

    // ObjectInfo을 배열로 가져다 사용하기
    [SerializeField] ObjectInfo[] objectInfo = null;

    // Queue : 선입선출 자료형 (가장 먼저 들어간 데이터가 가장 먼저 빠져나옴)
    public Queue<GameObject> noteQueue = new Queue<GameObject>();

    void Start()
    {
        instance = this;
        // return시킨 값 NoteQueue에 삽입
        noteQueue = InsertQueue(objectInfo[0]);

    }

    // 노트를 가져다가 사용하는 함수
    // GameObject타입을 가지고 있는 Queue를 return
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        // Object 정보 받아주는 임시 Queue
        Queue<GameObject> t_queue = new Queue<GameObject>();

        // 정보 넘기기
        for (int i = 0; i < p_objectInfo.count; i++)
        {
            // 객체 생성
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity);

            // 객체 생성후 바로 비활성화
            t_clone.SetActive(false);

            // 부모 설정
            // 기존에 설정했덙 Note는 NoteManagerScript가 붙어 있는 객체가 부모
            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else // 부모 객체가 null값일 경우
                t_clone.transform.SetParent(this.transform);

            // 생성한 객체 Queue에 삽입
            t_queue.Enqueue(t_clone);
        }

        return t_queue; // count 개수 만큼 들어있을 것
    }
}
