using System;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            var at = new AsyncTask();
            Console.WriteLine(at.GetAsync().GetAwaiter().GetResult());
        }
    }

    class AsyncTask
    {
        public async Task<string> GetAsync()
        {
            return await Task.Factory.StartNew(() => {
                return "From async task";
            });
        }
    }
}
