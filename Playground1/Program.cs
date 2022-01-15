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
        }
    }
}
