using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using CowBulls.Controllers;
using CowBulls.Models;

//КОММЕНТАРИЙ О ПРОЕКТЕ. Решение тестового задания на вакансию «Специалист по внедрению ПО», Контур. Выпол Самохвалов Дмитрий Сергеевич.
Console.WriteLine("ПРАВИЛА ИГРЫ \"БЫКИ И КОРОВЫ\"\n\nИграют двое человек. Первый игрок задумывает четырехзначное число так, чтобы все цифры числа были разные. " +
    "Второй игрок должен отгадать это число.\r\nХоды делаются по очереди. В каждый ход называется число, тоже четырехзначное и с разными цифрами. " +
    "Если цифра из названного числа есть в отгадываемом числе, то эта ситуация называется «корова». Если цифра из названного числа есть в отгадываемом числе " +
    "и стоит в том же месте, то эта ситуация называется «бык». \r\nВыигрывает тот, кто раньше отгадает число соперника.\r\n");

//Генерируем рандомное четырёхзначное число, удовлетворяющее условиям игры.
string rndNum = SpecialNumGenerationController.ToGenerateFourUniqNums();
Console.WriteLine("Компьютер загадал число!\nОтгадайте число!");
//Создаём экземпляр класса CowBulls, чтобы в цикле начать проверку, угадано число или нет.
CowBullsModel cbModel = new CowBullsModel();
//Проверяем угадано ли число, если нет, то пользователь снова загадывает число.
while (!cbModel.IsGuessedNum())
{
    //Пользователь вводит загаданное число.
    string inputNum = Console.ReadLine()!;
    //Проверяем подходит ли число под условия игры.
    if (CowBullsModel.IsValidNum(inputNum) == null)
    {
        //Вызываем конструктор класса CowBulls, чтобы задать загаданное и названное число. 
        cbModel = new CowBullsModel(rndNum, inputNum);
        //Проверяем если пользователь угадал число.
        if (cbModel.IsGuessedNum())
        { Console.WriteLine("Вы угадали число!"); }
        else
        {
            //Подсчитываем кол-во быков и коров.
            cbModel.ToCountCowBulls();
            Console.WriteLine("############\n{0} бык, {1} кор.\n############", cbModel.bulls, cbModel.cows);
        }
    }
    else Console.WriteLine(CowBullsModel.IsValidNum(inputNum));
}

