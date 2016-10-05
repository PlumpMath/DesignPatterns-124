﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_AdapterPattern
{
    /// 这里以插座和插头的例子来诠释适配器模式
    /// 现在我们买的电器插头是2个孔，但是我们买的插座只有3个孔的
    /// 这是我们想把电器插在插座上的话就需要一个电适配器
    class Program
    {
        /// <summary>
        /// 客户端，客户想要把2个孔的插头 转变成三个孔的插头，这个转变交给适配器就好
        /// 既然适配器需要完成这个功能，所以它必须同时具体2个孔插头和三个孔插头的特征
        /// </summary>
        static void Main(string[] args)
        {
            /*
             * 客户端希望调用Request方法（即三个孔插头），
             * 但是我们现有的类（即2个孔的插头）并没有Request方法，
             * 它只有SpecificRequest方法（即两个孔插头本身的方法），
             * 然而适配器类（适配器必须实现三个孔插头接口和继承两个孔插头类）可以提供这种转换，
             * 它提供了Request方法的实现（其内部调用的是两个孔插头，
             * 因为适配器只是一个外壳罢了，包装着两个孔插头（因为只有这样，电器才能使用），并向外界提供三个孔插头的外观，）以供客户端使用。
             */

            #region 类的适配器模式
            // 现在客户端可以通过电适配要使用2个孔的插头了
            //IThreeHole threehole = new PowerAdapter();
            //threehole.Request();
            //Console.ReadLine();
            #endregion

            #region 对象适配器模式

            // 现在客户端可以通过电适配要使用2个孔的插头了
            ThreeHole threehole = new PowerAdapter();
            threehole.Request();
            Console.ReadLine();

            #endregion
        }
    }
    #region 类的适配器模式
    ///// <summary>
    ///// 三个孔的插头，也就是适配器模式中的目标角色
    ///// </summary>
    //public interface IThreeHole
    //{
    //    void Request();
    //}

    ///// <summary>
    ///// 两个孔的插头，源角色——需要适配的类
    ///// </summary>
    //public abstract class TwoHole
    //{
    //    public void SpecificRequest()
    //    {
    //        Console.WriteLine("我是两个孔的插头");
    //    }
    //}

    ///// <summary>
    ///// 适配器类，接口要放在类的后面
    ///// 适配器类提供了三个孔插头的行为，但其本质是调用两个孔插头的方法
    ///// </summary>
    //public class PowerAdapter : TwoHole, IThreeHole
    //{
    //    /// <summary>
    //    /// 实现三个孔插头接口方法
    //    /// </summary>
    //    public void Request()
    //    {
    //        // 调用两个孔插头方法
    //        this.SpecificRequest();
    //    }
    //}
    #endregion

    #region 对象适配器模式
    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标(Target)角色
    /// </summary>
    public class ThreeHole
    {
        // 客户端需要的方法
        public virtual void Request()
        {
            // 可以把一般实现放在这里
        }
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是两个孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，这里适配器类没有TwoHole类，
    /// 而是引用了TwoHole对象，所以是对象的适配器模式的实现
    /// </summary>
    public class PowerAdapter : ThreeHole
    {
        // 引用两个孔插头的实例,从而将客户端与TwoHole联系起来
        public TwoHole twoholeAdaptee = new TwoHole();

        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public override void Request()
        {
            twoholeAdaptee.SpecificRequest();
        }
    }
    #endregion
}
