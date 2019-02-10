using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp4
{
    class Program
    { 
        [ThreadStatic]
        public static int field = 10; 


        public  static  ThreadLocal<int> _localThread = new ThreadLocal<int>(() =>
            {
                return DateTime.Now.Millisecond;
            });
        static void Main(string[] args)
        {


            new Thread(() =>
            {
                 
                    Console.WriteLine("i-0:"+ _localThread.Value);
                    
                    
               
            }).Start();


            new Thread(() =>
            {
                 

                    Console.WriteLine("i-1:" +_localThread.Value);
                  

              
            }).Start();
            AsyncFlowControl aFC = ExecutionContext.SuppressFlow();
            Console.WriteLine("Is the flow suppressed? " +
                              ExecutionContext.IsFlowSuppressed());
            Console.WriteLine("Restore the flow.");
            aFC.Undo();
            Console.WriteLine("Is the flow suppressed? " +
                              ExecutionContext.IsFlowSuppressed());

            Console.ReadKey();



        }

    }
}
