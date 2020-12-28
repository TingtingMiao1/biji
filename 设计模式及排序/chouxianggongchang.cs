using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gongchang2
{
//   有了前面工厂模式的铺垫，抽象工厂应该不难理解吧。我看到过很多的博客都写着很多概念，
//什么产品层级，产品族，抽象产品等等，感觉不是特别容易理解。我的理解是这样的：
//把多个不同的工厂再抽象出来，再用一个抽象工厂（超级工厂）来创建这些工厂。也就是说抽象工厂是工厂的工厂。
//为了说明这个模式我想出了一个例子（其实我在工作中没有遇到过使用抽象工厂的例子）：

////　　操作系统有Windows操作系统，Linux操作系统。每个操作系统都可以启动关闭。于是我们就创建一个操作系统工厂，
//用来创建（安装）这些操作系统，方法和上面的创建数据库工厂是一样的。


    // 操作系统具有的操作
    public interface IOpSystem
    {
        void Start();
        void Shutdown();
    }
    // 操作系统工厂
    public interface IOpSystemFactory
    {
        IOpSystem InstallSystem();
    }
    // windows操作系统
    public class WindowsSystem : IOpSystem
    {
        public void Shutdown()
        {
            Console.WriteLine("windows shutdown");
        }

        public void Start()
        {
            Console.WriteLine("windows start");
        }
    }
    // linux操作系统
    public class LinuxSystem : IOpSystem
    {
        public void Shutdown()
        {
            Console.WriteLine("linux shutdown");
        }

        public void Start()
        {
            Console.WriteLine("linux start");
        }
    }

    // windows操作系统工厂，用来创建windows系统实例
    public class WindowsFactory : IOpSystemFactory
    {
        public IOpSystem InstallSystem()
        {
            return new WindowsSystem();
        }
    }
    // linux操作系统工厂，用来创建linux系统实例
    public class LinuxFactory : IOpSystemFactory
    {
        public IOpSystem InstallSystem()
        {
            return new LinuxSystem();
        }
    }
    //我们可以看到操作系统工厂和数据库工厂是完全两个不同的工厂。假设一台服务器上需要安装操作系统和数据库，
    //    我们便可以用一个超级工厂来把这两个不同的工厂抽象出来。
    public interface ISuperFactory
    {
        IDatabaseFactory InstallDB();
        IOpSystemFactory InstallOpSystem();
    }
    //然后我们定义一个具体的服务器类来实现这个超级工厂，在接口的实现中我们让这个服务器类安装windows system和mysql db。
    public class ServerWithWindowsAndMySql : ISuperFactory
    {
        public IDatabaseFactory InstallDB()
        {
            return new MySqlFactory();
        }

        public IOpSystemFactory InstallOpSystem()
        {
            return new WindowsFactory();
        }
    }
    class Program 
    {
        static void Main(string[] args)
        {
            ISuperFactory server1 = new ServerWithWindowsAndMySql();
            server1.InstallDB().CreateDatabase().Delete();
            server1.InstallDB().CreateDatabase().Insert();
            server1.InstallOpSystem().InstallSystem().Start();
            server1.InstallOpSystem().InstallSystem().Shutdown();
            Console.ReadKey();
            //抽象工厂模式
        }
    }
}
