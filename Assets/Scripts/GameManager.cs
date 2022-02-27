using UnityEngine;

/// <summary>
/// Реализация синглтона для наследования.
/// </summary>
/// <typeparam name="GameManager">Класс, который нужно сделать синглтоном</typeparam>
/// <remarks>
/// Если необходимо обращаться к классу во время OnDestroy или OnApplicationQuit
/// необходимо проверять наличие объекта через IsAlive. Объект может быть уже 
/// уничтожен, и обращение к нему вызовет его еще раз.
/// 
/// 
/// При использовании в дочернем классе Awake, OnDestroy, 
/// OnApplicationQuit необходимо вызывать базовые методы
/// base.Awake() и тд.
/// 
/// Добавил скрываемый метод Initialization - чтобы перегружать его и использовать 
/// необходимые действия.
/// 
/// Создание объекта производится через unity, поэтому использовать блокировку 
/// объекта нет необходимости. Однако ее можно добавить, в случае если 
/// понадобится обращение к объекту из других потоков.
/// 
/// Из книг:
///     - Рихтер "CLR via C#"
///     - Chris Dickinson "Unity 2017 Game optimization"
///</remarks>

public class Singleton<GameManager> : MonoBehaviour where GameManager : Singleton<GameManager>
{

    private static GameManager instance = null;

    private bool alive = true;

    public static GameManager Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                //Find GameManager
                GameManager[] managers = GameObject.FindObjectsOfType<GameManager>();
                if (managers != null)
                {
                    if (managers.Length == 1)
                    {
                        instance = managers[0];
                        DontDestroyOnLoad(instance);
                        return instance;
                    }
                    else
                    {
                        if (managers.Length > 1)
                        {
                            Debug.LogError($"Have more that one {typeof(GameManager).Name} in scene. " +
                                            "But this is Singleton! Check project.");
                            for (int i = 0; i < managers.Length; ++i)
                            {
                                GameManager manager = managers[i];
                                Destroy(manager.gameObject);
                            }
                        }
                    }
                }
                //create 
                GameObject go = new GameObject(typeof(GameManager).Name, typeof(GameManager));
                instance = go.GetComponent<GameManager>();
                instance.Initialization();
                DontDestroyOnLoad(instance.gameObject);
                return instance;
            }
        }

        //Can be initialized externally
        set
        {
            instance = value as GameManager;
        }
    }

    /// <summary>
    /// Check flag if need work from OnDestroy or OnApplicationExit
    /// </summary>
    public static bool IsAlive
    {
        get
        {
            if (instance == null)
                return false;
            return instance.alive;
        }
    }

    protected void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this as GameManager;
            Initialization();
        }
        else
        {
            Debug.LogError($"Have more that one {typeof(GameManager).Name} in scene. " +
                            "But this is Singleton! Check project.");
            DestroyImmediate(this);
        }
    }

    protected void OnDestroy() { alive = false; }

    protected void OnApplicationQuit() { alive = false; }

    protected virtual void Initialization() { }
}