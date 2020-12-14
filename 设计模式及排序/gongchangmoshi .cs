using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gongchang2
{
    interface Idtabase
    {//定义接口
        void Insert();
        void Delete();
    }
    public class SqlServer : Idtabase//创建三个数据库类实现接口
    {
        public void Delete()
        {
            Console.WriteLine("delete data from sqlserver");
        }

        public void Insert()
        {
            Console.WriteLine("insert data to sqlserver");
        }
    }
    public class MySql : Idtabase
    {
        public void Delete()
        {
            Console.WriteLine("delete data from mysql");
        }

        public void Insert()
        {
            Console.WriteLine("insert data to mysql");
        }
    }
    public class MongoDB : Idtabase
    {
        public void Delete()
        {
            Console.WriteLine("delete data from mongoDb");
        }

        public void Insert()
        {
            Console.WriteLine("insert data to mongoDb");
        }
    }
    interface IDatabaseFactory//将工厂类声明为接口
     {
        Idtabase CreateDatabase();
    }
    //为每个具体类单独创建一个工厂类，工厂类实现刚刚定义的接口
    public class MongoDbFactory : IDatabaseFactory
    {
          public Idtabase CreateDatabase()
          {
             return new MongoDB();
          }
      }
    public class MySqlFactory : IDatabaseFactory
     {       public Idtabase CreateDatabase()
         {
             return new MySql();
        }
    }
    public class SqlServerFactory : IDatabaseFactory
     {
        public Idtabase CreateDatabase()
        {
            return new SqlServer();
         }
     }
class Program : Idtabase
    {
      


        static void Main(string[] args)
        {
            //Main函数里声明三个接口，然后给工厂类传入不同的参数来创建三个不同的实例，再分别调用接口中声明的方法。
            IDatabaseFactory dbFactory1 = new MySqlFactory();
            IDatabase db1 = dbFactory1.CreateDatabase();
            db1.Insert();
            db1.Delete();

            IDatabaseFactory dbFactory2 = new SqlServerFactory();
            IDatabase db2 = dbFactory1.CreateDatabase();
            db2.Insert();
            db2.Delete();

            IDatabaseFactory dbFactory3 = new MongoDbFactory();
            IDatabase db3 = dbFactory3.CreateDatabase();
            db3.Insert();
            db3.Delete();
            Console.ReadKey();
            //              工厂模式的好处便是它符合开闭原则（对扩展开放，对修改封闭）。在刚刚的简单工厂模式中，
            //如果我们扩展一个新的类，除了添加一个新的类之外，我们还需要去修改CrateDatabase(string dbType)这个方法，这是违反开闭原则的。
            //在工厂模式中我们就不需要修改CreateDatabase这个方法，只需要实现工厂类这个接口便能完场扩展。缺点便是我们需要写更多的代码。
        }
    }
}
