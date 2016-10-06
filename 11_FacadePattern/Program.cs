using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_FacadePattern
{
    #region 不使用外观模式：
    //class Program
    //{
    //    /// <summary>
    //    /// 不使用外观模式的情况
    //    /// 此时客户端与三个子系统都发送了耦合，使得客户端程序依赖与子系统
    //    /// 为了解决这样的问题，我们可以使用外观模式来为所有子系统设计一个统一的接口
    //    /// 客户端只需要调用外观类中的方法就可以了，简化了客户端的操作
    //    /// 从而让客户和子系统之间避免了紧耦合
    //    /// </summary>
    //    static void Main(string[] args)
    //    {
    //        SubSystemA a = new SubSystemA();
    //        SubSystemB b = new SubSystemB();
    //        SubSystemC c = new SubSystemC();
    //        a.MethodA();
    //        b.MethodB();
    //        c.MethodC();
    //        Console.Read();
    //    }
    //}

    //// 子系统A
    //public class SubSystemA
    //{
    //    public void MethodA()
    //    {
    //        Console.WriteLine("执行子系统A中的方法A");
    //    }
    //}

    //// 子系统B
    //public class SubSystemB
    //{
    //    public void MethodB()
    //    {
    //        Console.WriteLine("执行子系统B中的方法B");
    //    }
    //}

    //// 子系统C
    //public class SubSystemC
    //{
    //    public void MethodC()
    //    {
    //        Console.WriteLine("执行子系统C中的方法C");
    //    }
    //}
    #endregion

    #region 使用外观模式
    /// <summary>
    /// 以学生选课系统为例子演示外观模式的使用
    /// 学生选课模块包括功能有：
    /// 验证选课的人数是否已满
    /// 通知用户课程选择成功与否
    /// 客户端代码
    /// </summary>
    class Student
    {
        private static RegistrationFacade facade = new RegistrationFacade();

        static void Main(string[] args)
        {
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();
        }
    }

    // 外观类
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStu;
        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }

            return notifyStu.Notify(studentName);
        }
    }

    #region 子系统
    // 相当于子系统A
    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    // 相当于子系统B
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }
    #endregion
    #endregion
}
