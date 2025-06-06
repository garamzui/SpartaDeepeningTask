
using UnityEngine;

public interface IDondestroy { }

public class SingleTon<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            // T 타입을 가진 컴포넌트를 하이어라키에서 찾아봄
            if (_instance == null)
                _instance = FindObjectOfType<T>();

            // 찾아봐도 없으면 새로 생성
            if (_instance == null)
            {
                GameObject go = new GameObject() { name = typeof(T).Name };
                _instance = go.AddComponent<T>();

                if (_instance is IDondestroy)
                    DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
    }
    
    
}