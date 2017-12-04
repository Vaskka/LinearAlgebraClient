/// <summary>
/// Version: 1.0.0.0
/// 
/// 
/// 实现矩阵的加减乘法乘方运算
/// 实现方阵求行列式
/// </summary>
namespace LinearAlgebraClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client();
            myClient.RunLoop();

            Console.ReadKey();
        }
    }
}
