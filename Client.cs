using static System.Console;
using static System.Convert;
using 矩阵类库;

namespace LinearAlgebraClient
{
    /// <summary>
    /// 客户端类
    /// 定义和使用关于运算符号的委托和事件
    /// 主要实现基于控制台的客户端界面
    /// </summary>
    class Client
    {
        /// <summary>
        /// 版本号
        /// </summary>
        private string version = "1.0.0.0";

        private Matrix A;

        private Matrix B;

        /// <summary>
        /// 声明服务端对象
        /// </summary>
        private Server myServer = new Server();

        private char type = '0';
        /////////////////////////////////////////////////////////////
        //加，减，乘法事件的触发
        private void GetTwoElementEventResult(Matrix a, Matrix b)
        {
            if (TwoElementEvent != null)
            {
                TwoElementEvent(a, b);
            }
        }

        //乘方事件的触发
        private void GetPowerEventResult(Matrix a, int b)
        {
            if (PowerEvent != null)
            {
                PowerEvent(a, b);
            }
        }

        //行列式事件的触发
        private void GetDetaminateEvent(Matrix a)
        {
            if (DetaminateEvent != null)
            {
                DetaminateEvent(a);
            }
        }

        /////////////////////////////////////////////////////////////
        //加，减，乘法的委托
        public delegate void TwoElementHandler(Matrix a, Matrix b);

        //乘方委托
        public delegate void PowerHandler(Matrix a, int b);

        //行列式委托
        public delegate void DetaminateHandler(Matrix a);

        //////////////////////////////////////////////////////////////
        //加，减，乘法事件
        public event TwoElementHandler TwoElementEvent;

        //乘方事件
        public event PowerHandler PowerEvent;

        //行列式事件
        public event DetaminateHandler DetaminateEvent;

        //////////////////////////////////////////////////////////////

        /// <summary>
        /// 客户端主循环
        /// </summary>
        public void RunLoop()
        {
            int control = 1;
            int x = 0;
            int y = 0;
            string N = "";

            while (control == 1)
            {
                Welcome();
                InputTypeData();

                //判断计算类型
                if (type == '+')
                {
                    Clear();

                    WriteLine("你选择了加法运算，输入任意非数字回到主菜单");
                    TwoElementEvent += new TwoElementHandler(myServer.Add);
                    try
                    {
                        WriteLine("请输入第一个矩阵的名字:");
                        N = ReadLine();
                        WriteLine("请输入第一个矩阵的行数:");
                        x = ToInt32(ReadLine());
                        WriteLine("请输入第一个矩阵的列数:");
                        y = ToInt32(ReadLine());
                        A = new Matrix((string)N.Clone(), x, y);
                        A.SetMatrix();

                        WriteLine("请输入第二个矩阵的名字:");
                        N = ReadLine();
                        WriteLine("请输入第二个矩阵的行数:");
                        x = ToInt32(ReadLine());
                        WriteLine("请输入第二个矩阵的列数:");
                        y = ToInt32(ReadLine());
                        B = new Matrix((string)N.Clone(), x, y);
                        B.SetMatrix();

                        GetTwoElementEventResult(A, B);
                        TwoElementEvent -= new TwoElementHandler(myServer.Add);
                        Clear();
                        continue;
                    }
                    catch
                    {
                        //检测到非数字回到主菜单
                        Clear();
                        continue;
                    }
                }
                else
                {
                    if (type == '-')
                    {
                        Clear();

                        WriteLine("你选择了减法运算，输入任意非数字回到主菜单");
                        TwoElementEvent += new TwoElementHandler(myServer.Subduction);
                        try
                        {
                            WriteLine("请输入第一个矩阵的名字:");
                            N = ReadLine();
                            WriteLine("请输入第一个矩阵的行数:");
                            x = ToInt32(ReadLine());
                            WriteLine("请输入第一个矩阵的列数:");
                            y = ToInt32(ReadLine());
                            A = new Matrix((string)N.Clone(), x, y);
                            A.SetMatrix();

                            WriteLine("请输入第二个矩阵的名字:");
                            N = ReadLine();
                            WriteLine("请输入第二个矩阵的行数:");
                            x = ToInt32(ReadLine());
                            WriteLine("请输入第二个矩阵的列数:");
                            y = ToInt32(ReadLine());
                            B = new Matrix((string)N.Clone(), x, y);
                            B.SetMatrix();

                            GetTwoElementEventResult(A, B);
                            TwoElementEvent -= new TwoElementHandler(myServer.Subduction);
                            Clear();
                            continue;
                        }
                        catch
                        {
                            Clear();
                            continue;
                        }
                    }
                    else
                    {
                        if (type == '$')
                        {
                            Clear();

                            WriteLine("你选择了乘方运算，输入任意非数字回到主菜单");
                            PowerEvent += new PowerHandler(myServer.Power);
                            try
                            {
                                int mz = 0;
                                WriteLine("请输入矩阵的名字:");
                                N = ReadLine();
                                WriteLine("请输入矩阵的行数:");
                                x = ToInt32(ReadLine());
                                WriteLine("请输入矩阵的列数:");
                                y = ToInt32(ReadLine());
                                A = new Matrix((string)N.Clone(), x, y);
                                A.SetMatrix();

                                WriteLine("请输入幂指数");
                                mz = ToInt32(ReadLine());
                                GetPowerEventResult(A, mz);
                                PowerEvent -= new PowerHandler(myServer.Power);
                                Clear();
                                continue;
                            }
                            catch
                            {
                                Clear();
                                continue;
                            }
                        }
                        else
                        {
                            if (type == 'D' || type == 'd')
                            {
                                Clear();

                                WriteLine("你选择了求行列式运算，输入任意非数字回到主菜单");
                                DetaminateEvent += new DetaminateHandler(myServer.Detaminate);
                                try
                                {
                                    WriteLine("请输入矩阵的名字:");
                                    N = ReadLine();
                                    WriteLine("请输入矩阵的行数:");
                                    x = ToInt32(ReadLine());
                                    WriteLine("请输入矩阵的列数:");
                                    y = ToInt32(ReadLine());
                                    A = new Matrix((string)N.Clone(), x, y);
                                    A.SetMatrix();

                                    GetDetaminateEvent(A);
                                    DetaminateEvent -= new DetaminateHandler(myServer.Detaminate);
                                    Clear();
                                    continue;
                                }
                                catch
                                {
                                    Clear();
                                    continue;
                                }
                            }
                            else
                            {
                                if (type == '*')
                                {
                                    Clear();

                                    WriteLine("你选择了乘法运算，输入任意非数字回到主菜单");
                                    TwoElementEvent += new TwoElementHandler(myServer.Multi);
                                    try
                                    {
                                        WriteLine("请输入第一个矩阵的名字:");
                                        N = ReadLine();
                                        WriteLine("请输入第一个矩阵的行数:");
                                        x = ToInt32(ReadLine());
                                        WriteLine("请输入第一个矩阵的列数:");
                                        y = ToInt32(ReadLine());
                                        A = new Matrix((string)N.Clone(), x, y);
                                        A.SetMatrix();

                                        WriteLine("请输入第二个矩阵的名字:");
                                        N = ReadLine();
                                        WriteLine("请输入第二个矩阵的行数:");
                                        x = ToInt32(ReadLine());
                                        WriteLine("请输入第二个矩阵的列数:");
                                        y = ToInt32(ReadLine());
                                        B = new Matrix((string)N.Clone(), x, y);
                                        B.SetMatrix();

                                        GetTwoElementEventResult(A, B);
                                        TwoElementEvent -= new TwoElementHandler(myServer.Multi);
                                        Clear();
                                        continue;
                                    }
                                    catch
                                    {
                                        Clear();
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }

        /// <summary>
        /// 欢迎界面
        /// </summary>
        private void Welcome()
        {
            WriteLine("================================================");
            for (int i = 0; i < 3; i++)
            {
                WriteLine("=                                              =");
            }
            WriteLine("=          欢迎使用LinearAlgebraClient         =");
            WriteLine($"=                 --------Version:{version}     =");
            for (int i = 0; i < 3; i++)
            {
                WriteLine("=                                              =");
            }
            WriteLine("===============================================");
            WriteLine("\n\n");
        }

        /// <summary>
        /// 请求用户输入矩阵信息
        /// </summary>
        private void InputTypeData()
        {
            WriteLine("===============================================");
            WriteLine("====温馨提示：输入时请一行输入一个变量的值 ====");
            WriteLine("===============================================");
            WriteLine("请输入要进行的操作： +  -  *  $(乘方) D(行列式)");
            type = ToChar(ReadLine());
            while (type != '+' && type != '-' && type != '*' && type != '$' && type != 'D' && type != 'd')
            {
                WriteLine("输入有误，请重新输入");
                WriteLine("请输入要进行的操作： +  -  *  $(乘方) D(行列式)");
                type = ToChar(ReadLine());
            }

        }

    }
}
