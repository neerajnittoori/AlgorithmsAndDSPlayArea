using System;
using Playground1;
namespace Playground1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var court1 = new Court1();
            court1.play();

            var listNodeCourt = new LinkedListCourt();
            listNodeCourt.Play();

            var court2 = new Court2();
            court2.Play();

            var binaryTreeCourt1 = new BinaryTreeCourt1();
            binaryTreeCourt1.Play();

            var court3 = new Court3();
            court3.Play();

            var court4 = new Court4();
            court4.Play();
            
            var court5 = new Court5();
            court5.Play();
            
            var binaryTreeCourt2 = new BinaryTreeCourt2();
            binaryTreeCourt2.Play();
        }
    }
}
