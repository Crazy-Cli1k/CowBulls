using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowBulls.Controllers
{
    /// <summary>
    /// Контроллер SpecialNumGenerationController
    /// работает с генерацией специальных чисел.
    /// </summary>
    public static class SpecialNumGenerationController
    {
        /// <summary>
        /// Функция ToGenerateFourUniqNums()
        /// генерирует число из 4 разных цифр.
        /// </summary>
        public static string ToGenerateFourUniqNums()
        {
            string rndValue = "";
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int rndNum = rnd.Next(1, 9);
                while (rndValue.Contains(Convert.ToString(rndNum)))
                {
                    rndNum = rnd.Next(1, 9);
                }
                rndValue = rndValue + rndNum;
            }
            return rndValue;
        }
    }
}
