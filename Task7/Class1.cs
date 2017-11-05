using System;
using System.Threading.Tasks;
using Task6;

namespace Task7
{
    public class Class1
    {
        private static async Task<int> GetTheMagicNumber()
        {
            int ultimateResult = await IKnowIGuyWhoKnowsAGuy();

            return ultimateResult;
        }
        
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            int res1 = await IKnowWhoKnowsThis(10);
            int res2 = await IKnowWhoKnowsThis(5);
            
            return res1 + res2; 
        }
        
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
             return Task6.Class1.FactorialDigitSum(n).Result;
        }
    }
}