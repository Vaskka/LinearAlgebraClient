using static System.Console;
using 矩阵类库;

namespace LinearAlgebraClient
{
    /// <summary>
    /// 服务端类
    /// 主要实现对客户端触发响应事件的响应
    /// </summary>
    class Server
    {
        public Server() { }

        /// <summary>
        /// 加法事件响应函数
        /// </summary>
        /// <param name="a">左操作数</param>
        /// <param name="b">右操作数</param>
        public void Add(Matrix a, Matrix b)
        {
            WriteLine("---------------------------");
            a.ShowMatrix();
            WriteLine();
            b.ShowMatrix();
            WriteLine();
            WriteLine("加法法结果是:");
            Matrix c = a + b;
            c.ShowMatrix();
            WriteLine("......按任意键继续计算......");
            WriteLine("---------------------------");
            ReadKey();
        }

        /// <summary>
        /// 减法事件响应函数
        /// </summary>
        /// <param name="a">左操作数</param>
        /// <param name="b">右操作数</param>
        public void Subduction(Matrix a, Matrix b)
        {
            WriteLine("---------------------------");
            a.ShowMatrix();
            WriteLine();
            b.ShowMatrix();
            WriteLine();
            WriteLine("减法结果是:");
            Matrix c = a - b;
            c.ShowMatrix();
            WriteLine("......按任意键继续计算......");
            WriteLine("---------------------------");
            ReadKey();
        }

        /// <summary>
        /// 乘法事件响应函数
        /// </summary>
        /// <param name="a">左操作数</param>
        /// <param name="b">右操作数</param>
        public void Multi(Matrix a, Matrix b)
        {
            WriteLine("---------------------------");
            a.ShowMatrix();
            WriteLine();
            b.ShowMatrix();
            WriteLine();
            WriteLine("乘法结果是:");
            Matrix c = a * b;
            c.ShowMatrix();
            WriteLine("......按任意键继续计算......");
            WriteLine("---------------------------");
            ReadKey();
        }

        /// <summary>
        /// 乘方事件响应函数
        /// </summary>
        /// <param name="a">待求矩阵</param>
        /// <param name="b">幂指数</param>
        public void Power(Matrix a, int b)
        {
            WriteLine("---------------------------");
            a.ShowMatrix();
            WriteLine();
            WriteLine("乘方结果是:");
            Matrix c = Matrix.pow(a, b);
            c.ShowMatrix();
            WriteLine("......按任意键继续计算......");
            WriteLine("---------------------------");
            ReadKey();
        }

        /// <summary>
        /// 求行列式事件响应函数
        /// </summary>
        /// <param name="a">待求矩阵</param>
        public void Detaminate(Matrix a)
        {
            WriteLine("---------------------------");
            a.ShowMatrix();
            WriteLine();
            WriteLine($"求行列式结果是:{a.Det}");
            WriteLine("......按任意键继续计算......");
            WriteLine("---------------------------");
            ReadKey();
        }

    }
}
