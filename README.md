# ТЕСТОВОЕ ЗАДАНИЕ КОНТУР
Это решение тестового задания на вакансию "Специалист по внедрению ПО", выполнил Самохвалов Дмитрий.
### Структура проекта
Проект представляет из себя консольное приложение, написанное на языке C#, платформе .Net 8.0. 
Файлы проекта:
Program.cs основной файл программы.
Папка Controllers содержит контроллер генерации чисел.
Папка Models включает в себя модель представления игры.
### Функционал проекта
Консольное приложение, при запуске которого выводятся правила игры и генерируется рандомное число, которое игрок должен отгадать, введя свой вариант. При вводе любых не чисел и длинной более 4 (по условию) символов, выходит соответствующая ошибка валидации, при вводе числа с 2 и более одинаковыми цифрами, другая ошибка валидации. При вводе удовлетворительного числа, пользователю выводятся на экран кол-во "быков и коров", просчитывающихся согласно условию, пока он не введёт загаданное число. Всю историю ввода пользователь может увидеть в самой консоли.  
