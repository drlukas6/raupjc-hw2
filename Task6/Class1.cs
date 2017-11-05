using System;
using System.Threading.Tasks;

namespace Task6
{
    public class Class1
    {
        async static Task<int> calculate(int a)
        {
            int mul = 1;
            for (int i = 1; i <= a; i++)
            {
                mul = mul * i;
            }
            int sum = 0;
            while (mul != 0) {
                sum += mul % 10;
                mul /= 10;
            }
            return sum;
        }
        
        public static async Task<int> FactorialDigitSum(int n)
        {
            var task =  calculate(n);
            int result = await task;
            return result;
        }
        
        

        
    }
}