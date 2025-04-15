using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CowBulls.Models
{
    /// <summary>
    /// Класс CowBullsModel представляет
    /// модель игры "Быки и коровы".
    /// </summary>
    public class CowBullsModel
    {
        /// <summary>
        /// Приватное поле _cows для подсчёта коров.
        /// </summary>
        private int _cows = 0;
        /// <summary>
        /// Приватное поле _bulls для подсчёта быков.
        /// </summary>
        private int _bulls = 0;
        /// <summary>
        /// Приватное поле _hiddenNum содержит загаддное число.
        /// </summary>
        private string? _hiddenNum;
        /// <summary>
        /// Приватное поле _inputNum содержит названное число.
        /// </summary>
        private string? _inputNum;
        /// <summary>
        /// Свойство cows для обращения к полю _cows.
        /// </summary>
        public int cows { get { return _cows; } set { _cows = value; } }
        /// <summary>
        /// Свойство bulls для обращения к полю _bulls.
        /// </summary>
        public int bulls { get { return _bulls; } set { _bulls = value; } }
        /// <summary>
        /// Свойство hiddenNum для обращения к полю _hiddenNum.
        /// </summary>
        public string hiddenNum { get { return _hiddenNum!; } set { _hiddenNum = value; } }
        /// <summary>
        /// Свойство inputNum для обращения к полю _inputNum.
        /// </summary>
        public string inputNum { get { return _inputNum!; } set { _inputNum = value; } }
        /// <summary>
        /// Конструктор класса CowBullsModel(), задающий экземпляр класса.
        /// </summary>
        public CowBullsModel() { }
        /// <summary>
        /// Перегрузка конструктора класса CowBullsModel(), задающая значения
        /// загаданному и названному числу.
        /// </summary>
        /// <param name="hiddenNum">Загаданное число.</param>
        /// <param name="inputNum">Названное число.</param>
        public CowBullsModel (string hiddenNum, string inputNum)
        {
            _hiddenNum = hiddenNum;
            _inputNum = inputNum;
        }
        /// <summary>
        /// Метод ToCountCowBulls() подсчитывает
        /// кол-во быков и коров при заданных числах.
        /// </summary>
        public void ToCountCowBulls()
        {
            /*
            Думаю можно было бы сделать часть этого кода через регулярные выражения,
            но для такой задачи решил обойтись просто работой со строками =)
            Для начала перебираем названное число и сравниваем его с загаданным на наличие "быков".
            */
            for (int i = 0; i < inputNum.Length; i++)
            {
                /*
                При нахождении "быка", подсчитываем его и выпиливаем из обоих чисел, 
                чтобы вдруг не подсчитать лишнюю корову ниже.
                Хотя по условиям и с учётом валидации, двух одинаковых цифр в числе
                не должно оказаться, на всякий случай такая осторожность не повредит.
                */
                if (hiddenNum[i] == inputNum[i])
                {
                    bulls++;
                    inputNum = inputNum.Remove(i, 1);
                    hiddenNum = hiddenNum.Remove(i, 1);
                    i--;
                }
            }
            //убираем все дублирующиеся цифры из названного числа, опять таки, на всякий случай.
            string inputNoDuolicats = new string(inputNum.Distinct().ToArray());
            //Перебираем все цифры из названного числа на наличие их в загаданном числе, прибавляем коровки.
            for (int i = 0; i < inputNoDuolicats.Length; i++)
            {
                if (hiddenNum.Contains(inputNoDuolicats[i])) cows++;
            }
        }
        /// <summary>
        /// Метод IsGuessedNum() определяет
        /// угадано ли число.
        /// </summary>
        public bool IsGuessedNum()
        {
            return (hiddenNum != null && inputNum != null && hiddenNum == inputNum);
        }
        /// <summary>
        /// Метод IsValidNum() проверяет
        /// подходит ли число условиям игры.
        /// </summary>
        /// <param name="inputNum">Входное число для проверки.</param>
        public static string? IsValidNum(string inputNum)
        {
            //Узнаём является ли входное значение вообще четырёхзначеным числом.
            string ?validationResult = (int.TryParse(inputNum, out int validInput) == true && inputNum.Length == 4) ? null : "############\nВы задали неверное число!\nОно должно состоять из 4 цифр.\n############";
            //Если валидация не прошла, отправляет результат.
            if (validationResult != null) return validationResult;
            //Перебираем это число на наличие двух и более одинаковых цифр.
            for (int i = 0; i < inputNum.Length; i++)
            {
                if (inputNum.Count(c => c == inputNum[i]) > 1) { validationResult = "############\nВы задали неверное число!\nЦифры в числе не должны повторяться.\n############"; break; }
            }
            return validationResult;
        }
    }
}
