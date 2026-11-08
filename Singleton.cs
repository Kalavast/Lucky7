using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }
    protected virtual void Awake() {
        if (Instance == null) {
            Instance = this as T;
        } else {
            Destroy(gameObject);
        }
    }
    protected virtual void OnApplicationQuit() {
        Instance = null;
        Destroy(gameObject);
    }
}
    public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour {
        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }

 