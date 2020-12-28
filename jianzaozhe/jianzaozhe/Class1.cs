using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jianzaozhe
{
    //建造者抽象类，定义了建造者的能力
    public abstract class Builder
    {
        public abstract void Dadiji();//打地基
        public abstract void QiZhuan();//砌砖
        public abstract void FenShua();//粉刷
    }
}
