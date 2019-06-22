using System;
using System.Collections.Generic;

namespace Patterns
{
    /// <summary>
    ///     Creates a Singleton Class which allows to Pool/Release objects of the type <typeparam name="T"></typeparam>>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Pooler<T> : Singleton<T> where T : class, IPoolable, new()
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Constructor

        /// <summary>
        ///     Constructor, you must have to specify the starting size of the pool
        /// </summary>
        /// <param name="startingSize"></param>
        protected Pooler(int startingSize)
        {
            StartSize = startingSize;

            //pool start size
            for (var i = 0; i < StartSize; ++i)
            {
                var obj = new T();
                free.Add(obj);
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Exceptions

        public class PoolerArgumentException : ArgumentException
        {
            public PoolerArgumentException(string message) : base(message)
            {
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        private readonly List<T> busy = new List<T>();
        private readonly List<T> free = new List<T>();

        public int StartSize { get; }

        public int SizeFreeObjects => free.Count;

        public int SizeBusyObjects => busy.Count;

        public Type PoolType => typeof(T);

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Get an object of the type T
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            T pooled = null;

            if (SizeFreeObjects > 0)
            {
                //pool the last object
                pooled = free[SizeFreeObjects - 1];
                free.Remove(pooled);
            }
            else
            {
                //if can't pool create a new object
                pooled = new T();
            }

            //add to the busy list
            busy.Add(pooled);
            
            OnPool(pooled);
            return pooled;
        }

        /// <summary>
        ///     Release an object of the type T
        /// </summary>
        /// <param name="released"></param>
        public void Release(T released)
        {
            if (released == null)
                throw new PoolerArgumentException("Can't Release a null object");

            //reset object
            released.Restart();

            //add back to the freelist
            free.Add(released);

            //remove from busy list
            busy.Remove(released);
            
            OnRelease(released);
        }

        /// <summary>
        ///     Dispatched before pool an object.
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnPool(T obj)
        {
            
        }
        
        /// <summary>
        ///     Dispatched after release an object.
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void OnRelease(T obj)
        {
            
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}