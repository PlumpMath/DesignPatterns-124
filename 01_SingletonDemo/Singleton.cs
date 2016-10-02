using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SingletonDemo
{
    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class Singleton
    {
        #region 懒汉模式： 静态初始化

        //private Singleton() { }
        //public static readonly Singleton Instance = new Singleton();

        #endregion

        #region 单线程下OK

        //// 定义一个静态变量来保存类的实例
        //private static Singleton uniqueInstance;

        //// 定义私有构造函数，使外界不能创建该类实例
        //private Singleton()
        //{
        //}

        ///// <summary>
        ///// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        ///// </summary>
        ///// <returns></returns>
        //public static Singleton GetInstance()
        //{
        //    // 如果类的实例不存在则创建，否则直接返回
        //    if (uniqueInstance == null)
        //    {
        //        uniqueInstance = new Singleton();
        //    }
        //    return uniqueInstance;

        //}

        #endregion

        #region 多线程下时单例的解决方案
        //// 定义一个静态变量来保存类的实例
        //private static Singleton uniqueInstance;

        //// 定义一个标识确保线程同步
        //private static readonly object locker = new object();

        //// 定义私有构造函数，使外界不能创建该类实例
        //private Singleton()
        //{
        //}

        ///// <summary>
        ///// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        ///// </summary>
        ///// <returns></returns>
        //public static Singleton GetInstance()
        //{
        //    // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
        //    // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
        //    // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
        //    lock (locker)
        //    {
        //        // 如果类的实例不存在则创建，否则直接返回
        //        if (uniqueInstance == null)
        //        {
        //            uniqueInstance = new Singleton();
        //        }
        //    }

        //    return uniqueInstance;
        //}
        #endregion

        #region 多线程下双锁单例(安全，麻烦）
        //// 定义一个静态变量来保存类的实例
        //private static Singleton uniqueInstance;

        //// 定义一个标识确保线程同步
        //private static readonly object locker = new object();

        //// 定义私有构造函数，使外界不能创建该类实例
        //private Singleton()
        //{
        //}

        ///// <summary>
        ///// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        ///// </summary>
        ///// <returns></returns>
        //public static Singleton GetInstance()
        //{
        //    // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
        //    // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
        //    // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
        //    // 双重锁定只需要一句判断就可以了
        //    if (uniqueInstance == null)
        //    {
        //        lock (locker)
        //        {
        //            // 如果类的实例不存在则创建，否则直接返回
        //            if (uniqueInstance == null)
        //            {
        //                uniqueInstance = new Singleton();
        //            }
        //        }
        //    }
        //    return uniqueInstance;
        //}
        #endregion

        #region 延迟初始化
        //private Singleton()
        //{
        //}

        ///// <summary>
        ///// Gets the instance.
        ///// </summary>
        //public static Singleton Instance { get { return Nested._instance; } }

        //private class Nested
        //{
        //    // Explicit static constructor to tell C# compiler
        //    // not to mark type as beforefieldinit
        //    static Nested()
        //    {
        //    }

        //    internal static readonly Singleton _instance = new Singleton();
        //}

        #endregion

        #region 使用系统提供的延迟Lazy<T> type初始化
        /// <summary>
        /// .NET 4's Lazy<T> type
        /// </summary>
        private static readonly Lazy<Singleton> lazy =
                            new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }
        #endregion
    }
}