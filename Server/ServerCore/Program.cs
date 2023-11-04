namespace ServerCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ThreadPool.SetMinThreads(1, 1);
            //ThreadPool.SetMaxThreads(5, 5);

            for (int i = 0; i < 8; i++)
                ThreadPool.QueueUserWorkItem((obj) => { while (true) { } });

           

            ThreadPool.QueueUserWorkItem(MainThread);

            //for(int i=0; i < 10000; i++)
            //{

            //Thread t = new Thread(MainThread);
            ////t.Name = "TestThread";
            //t.IsBackground = true;
            //t.Start();
            //}

            //Console.WriteLine("Waiting Hello, World!");

            //t.Join();

            //Console.WriteLine("Hello, World!");


            while (true) { }
        }

        static void MainThread(object? state)
        {
            int count = 0;
            while (true)
            {
                Console.WriteLine(count++);
            }
        }

    }





}