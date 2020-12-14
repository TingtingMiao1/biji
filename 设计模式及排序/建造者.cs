using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jianzaozhe
{
    class Program
    {

        //建造者抽象类，定义了建造者的能力
        public abstract class Builder
        {
            public abstract void Dadiji();//打地基
            public abstract void QiZhuan();//砌砖
            public abstract void FenShua();//粉刷
        }
        /// <summary>
        /// 技术好的建造者
        /// </summary>
        public class GoodBuilder : Builder
        {
            private StringBuilder house = new StringBuilder();
            public override void Dadiji()
            {
                house.Append("深地基-->");
                //这里一般是new一个部件，添加到实例中，如 house.Diji=new Diji("深地基")
                //为了演示方便 用sringBuilder表示一个复杂的房子，string表示房子的部件
            }

            public override void FenShua()
            {
                house.Append("粉刷光滑-->");
            }

            public override void QiZhuan()
            {
                house.Append("砌砖整齐-->");
            }
            public string GetHouse()
            {
                return house.Append("好质量房子建成了！").ToString();
            }
        }
        /// <summary>
        /// 技术差的建造者
        /// </summary>
        public class BadBuilder : Builder
        {
            private StringBuilder house = new StringBuilder();
            public override void Dadiji()
            {
                house.Append("挖浅地基-->");
            }

            public override void FenShua()
            {
                house.Append("粉刷粗糙-->");
            }

            public override void QiZhuan()
            {
                house.Append("砌砖错乱-->");
            }
            public string GetHouse()
            {
                return house.Append("坏质量房子建成了！").ToString();
            }
        }//监工类，制定盖房子的步骤
        public class Director
        {
            private Builder builder;
            public Director(Builder builder)
            {
                this.builder = builder;
            }

            //制定盖房子的流程，
            public void Construct()
            {
                builder.Dadiji();//先打地基
                builder.QiZhuan();//再砌砖
                builder.FenShua();//最后粉刷
            }
        }
        static void Main(string[] args)
        {//监工1派遣技术好的建造者盖房子
            GoodBuilder goodBuilder = new GoodBuilder();
            Director director1 = new Director(goodBuilder);
            director1.Construct();
            string house1 = goodBuilder.GetHouse();
            Console.WriteLine(house1);

            //监工2派遣技术差的建造者盖房子
            GoodBuilder badBuilder = new GoodBuilder();
            Director director2 = new Director(goodBuilder);
            director2.Construct();
            string house2 = goodBuilder.GetHouse();
            Console.WriteLine(house2);
            Console.ReadKey();
        }
    }
}
