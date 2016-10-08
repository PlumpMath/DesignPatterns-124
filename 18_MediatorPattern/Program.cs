using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_MediatorPattern
{
    #region 不使用中介者模式时：
    //// 抽象牌友类
    //public abstract class AbstractCardPartner
    //{
    //    public int MoneyCount { get; set; }

    //    public AbstractCardPartner()
    //    {
    //        MoneyCount = 0;
    //    }

    //    public abstract void ChangeCount(int Count, AbstractCardPartner other);
    //}

    //// 牌友A类
    //public class ParterA : AbstractCardPartner
    //{
    //    public override void ChangeCount(int Count, AbstractCardPartner other)
    //    {
    //        this.MoneyCount += Count;
    //        other.MoneyCount -= Count;
    //    }
    //}

    //// 牌友B类
    //public class ParterB : AbstractCardPartner
    //{
    //    public override void ChangeCount(int Count, AbstractCardPartner other)
    //    {
    //        this.MoneyCount += Count;
    //        other.MoneyCount -= Count;
    //    }
    //}

    //class Program
    //{
    //    // A,B两个人打牌
    //    static void Main(string[] args)
    //    {
    //        AbstractCardPartner A = new ParterA();
    //        A.MoneyCount = 20;
    //        AbstractCardPartner B = new ParterB();
    //        B.MoneyCount = 20;

    //        // A 赢了则B的钱就减少
    //        A.ChangeCount(5, B);
    //        Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
    //        Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

    //        // B赢了A的钱也减少
    //        B.ChangeCount(10, A);
    //        Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount); // 应该是15
    //        Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
    //        Console.Read();
    //    }
    //}
    #endregion

    #region 使用中介者模式时：
    //// 抽象牌友类
    //public abstract class AbstractCardPartner
    //{
    //    public int MoneyCount { get; set; }

    //    public AbstractCardPartner()
    //    {
    //        MoneyCount = 0;
    //    }

    //    public abstract void ChangeCount(int Count, AbstractMediator mediator);
    //}

    //// 牌友A类
    //public class ParterA : AbstractCardPartner
    //{
    //    // 依赖与抽象中介者对象
    //    public override void ChangeCount(int Count, AbstractMediator mediator)
    //    {
    //        mediator.AWin(Count);
    //    }
    //}

    //// 牌友B类
    //public class ParterB : AbstractCardPartner
    //{
    //    // 依赖与抽象中介者对象
    //    public override void ChangeCount(int Count, AbstractMediator mediator)
    //    {
    //        mediator.BWin(Count);
    //    }
    //}

    //// 抽象中介者类
    //public abstract class AbstractMediator
    //{
    //    protected AbstractCardPartner A;
    //    protected AbstractCardPartner B;
    //    public AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
    //    {
    //        A = a;
    //        B = b;
    //    }

    //    public abstract void AWin(int count);
    //    public abstract void BWin(int count);
    //}

    //// 具体中介者类
    //public class MediatorPater : AbstractMediator
    //{
    //    public MediatorPater(AbstractCardPartner a, AbstractCardPartner b)
    //        : base(a, b)
    //    {
    //    }

    //    public override void AWin(int count)
    //    {
    //        A.MoneyCount += count;
    //        B.MoneyCount -= count;
    //    }

    //    public override void BWin(int count)
    //    {
    //        B.MoneyCount += count;
    //        A.MoneyCount -= count;
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        AbstractCardPartner A = new ParterA();
    //        AbstractCardPartner B = new ParterB();
    //        // 初始钱
    //        A.MoneyCount = 20;
    //        B.MoneyCount = 20;

    //        AbstractMediator mediator = new MediatorPater(A, B);

    //        // A赢了
    //        A.ChangeCount(5, mediator);
    //        Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
    //        Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

    //        // B 赢了
    //        B.ChangeCount(10, mediator);
    //        Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是15
    //        Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
    //        Console.Read();
    //    }
    //}
    #endregion

    #region 中介者模式+状态模式

    // 抽象牌友类
    public abstract class AbstractCardPartner
    {
        public int MoneyCount { get; set; }

        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }

        public abstract void ChangeCount(int Count, AbstractMediator mediator);
    }

    // 牌友A类
    public class ParterA : AbstractCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    // 牌友B类
    public class ParterB : AbstractCardPartner
    {
        // 依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    // 抽象状态类
    public abstract class State
    {
        protected AbstractMediator meditor;
        public abstract void ChangeCount(int count);
    }

    // A赢状态类
    public class AWinState : State
    {
        public AWinState(AbstractMediator concretemediator)
        {
            this.meditor = concretemediator;
        }

        public override void ChangeCount(int count)
        {
            foreach (AbstractCardPartner p in meditor.list)
            {
                ParterA a = p as ParterA;
                // 
                if (a != null)
                {
                    a.MoneyCount += count;
                }
                else
                {
                    p.MoneyCount -= count;
                }
            }
        }
    }

    // B赢状态类
    public class BWinState : State
    {
        public BWinState(AbstractMediator concretemediator)
        {
            this.meditor = concretemediator;
        }

        public override void ChangeCount(int count)
        {
            foreach (AbstractCardPartner p in meditor.list)
            {
                ParterB b = p as ParterB;
                // 如果集合对象中时B对象，则对B的钱添加
                if (b != null)
                {
                    b.MoneyCount += count;
                }
                else
                {
                    p.MoneyCount -= count;
                }
            }
        }
    }

    // 初始化状态类
    public class InitState : State
    {
        public InitState()
        {
            Console.WriteLine("游戏才刚刚开始,暂时还有玩家胜出");
        }

        public override void ChangeCount(int count)
        {
            // 
            return;
        }
    }

    // 抽象中介者类
    public abstract class AbstractMediator
    {
        public List<AbstractCardPartner> list = new List<AbstractCardPartner>();

        public State State { get; set; }

        public AbstractMediator(State state)
        {
            this.State = state;
        }

        public void Enter(AbstractCardPartner partner)
        {
            list.Add(partner);
        }

        public void Exit(AbstractCardPartner partner)
        {
            list.Remove(partner);
        }

        public void ChangeCount(int count)
        {
            State.ChangeCount(count);
        }
    }

    // 具体中介者类
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(State initState)
            : base(initState)
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AbstractCardPartner A = new ParterA();
            AbstractCardPartner B = new ParterB();
            // 初始钱
            A.MoneyCount = 20;
            B.MoneyCount = 20;

            AbstractMediator mediator = new MediatorPater(new InitState());

            // A,B玩家进入平台进行游戏
            mediator.Enter(A);
            mediator.Enter(B);

            // A赢了
            mediator.State = new AWinState(mediator);
            mediator.ChangeCount(5);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

            // B 赢了
            mediator.State = new BWinState(mediator);
            mediator.ChangeCount(10);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15
            Console.Read();
        }
    }

    #endregion
}
