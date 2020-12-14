using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 设计模式
{
    class Program
    {
        public class Person
        {
            /// <summary>
            /// 实例化一个私有静态变量，存储类本身的实例
            /// </summary>
            private static Person _person = null;
            /// 作为锁的对象，使用私有的、静态的并且是只读的对象
            /// </summary>
            private static readonly object _obj = new object();
            /// <summary>
            /// 构造函数
            /// </summary>
            private Person()
            {
                Console.WriteLine("构造了一个{0}", GetType().Name);
            }
            /// <summary>
            /// 获取类唯一的实例对象
            /// </summary>
            public static Person GetInstance()
            {
                if (_person == null)//先判断是否为空
                {
                    lock (_obj)//再判断下是否有别的线程在使用
                    {
                        if (_person == null)//等其他线程使用完成后再判断是否为空
                        {
                            _person = new Person();
                        }
                    }
                }
                return _person;
            }
        }
        static void Main(string[] args)
        {//使用锁，锁住的对象:使用私有的、静态的并且是只读的对象
            Person person1 = null;
            Person person2 = null;
            Person person3 = null;
            //多线程下可以输出多次
            var thread1 = new Thread(() => { person1 = Person.GetInstance(); });
            var thread2 = new Thread(() => { person2 = Person.GetInstance(); });
            var thread3 = new Thread(() => { person3 = Person.GetInstance(); });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Thread.Sleep(1000);//等待子线程完成
            Console.WriteLine("person1 == person2：{0}", object.ReferenceEquals(person1, person2));
            Console.ReadKey();
        }
    }
}
//public class Person使用静态函数方法
//{
//    /// <summary>
//    /// 实例化一个私有静态变量，存储类本身的实例
//    /// </summary>
//    private static Person _person = null;

//    /// <summary>
//    /// 构造函数
//    /// </summary>
//    private Person()
//    {
//        Console.WriteLine("构造了一个{0}", GetType().Name);
//    }

//    /// <summary>
//    /// 静态构造函数,只执行一次
//    /// </summary>
//    static Person()
//    {
//        _person = new Person();
//    }

//    /// <summary>
//    /// 获取类的实例
//    /// </summary>
//    public static Person GetInstance()
//    {
//        return _person;
//    }
//}
//{
//                //使用锁，锁住的对象:使用私有的、静态的并且是只读的对象
//                //使用静态构造函数，在里面初始化person对象
//                Person person1 = null;
//Person person2 = null;
//Person person3 = null;
////多线程下可以输出多次
//var thread1 = new Thread(() => { person1 = Person.GetInstance(); });
//var thread2 = new Thread(() => { person2 = Person.GetInstance(); });
//var thread3 = new Thread(() => { person3 = Person.GetInstance(); });
//thread1.Start();
//                thread2.Start();
//                thread3.Start();
//                Thread.Sleep(1000);//等待子线程完成
//                Console.WriteLine("person1 == person2：{0}", object.ReferenceEquals(person1, person2));
//            }