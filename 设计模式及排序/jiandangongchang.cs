using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂
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
    class Program : Idtabase
        {
            public void Delete()
            {
                Console.WriteLine("delete data from sqlserver");
            }
            public void Insert()
            {
                Console.WriteLine("insert data to sqlserver");
            }
            public static class DatabaseFactory //创建工厂类 这个类中的静态方法可以根据不同的参数创建不同的实例
            {
                public static Idtabase CreateDatabase(string dbType)
                {
                    Idtabase db = null;

                    switch (dbType)
                    {
                        case "MySql":
                            db = new MySql();
                            break;
                        case "SqlServer":
                            db = new SqlServer();
                            break;
                        case "MongoDB":
                            db = new MongoDB();
                            break;
                        default:
                            break;
                    }

                    return db;
                }
            }

            static void Main(string[] args)
            {
                //Main函数里声明三个接口，然后给工厂类传入不同的参数来创建三个不同的实例，再分别调用接口中声明的方法。
                Idtabase db1 = DatabaseFactory.CreateDatabase("MySql");
                             db1.Insert();
                             db1.Delete();
                
             Idtabase db2 = DatabaseFactory.CreateDatabase("SqlServer");
                             db2.Insert();
                             db2.Delete();
                
            Idtabase db3 = DatabaseFactory.CreateDatabase("MongoDB");
                            db3.Insert();
                             db3.Delete();
                Console.ReadKey();
  //              这就是简单工厂模式。

　　//我们可以看到简单工厂模式的优点：

　　//1.拓展性好，如果这时候我们又添加了一个Oracle数据库，只需要再添加一个新的类并实现IDatabase这个这个接口就行了。

　　//2.我们只需要关注接口中的方法，不需要关注具体类的实现。

　　//缺点：只适用于工厂需要创建比较少的具体类这样的情况。如果具体类多，代码的复杂程度会增加。
            }
        }

    }
