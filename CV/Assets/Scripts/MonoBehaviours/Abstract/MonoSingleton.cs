using System;
using UnityEngine;

namespace MonoBehaviours.Abstract
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                    return null;
                _instance.Init();

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = (T) this;
            //instance = this as T;
        }

        protected virtual void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
        }

        private void OnDisable()
        {
            if (this == _instance)
                _instance = null;
        }
    }
}