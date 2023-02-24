// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] FillMatrix(int[,] matr)                                  //  метод заполнения матрицы спирально
{
    int num = 1;                                                //  заполнитель матрицы - нумератор
    int x = 0;                                                  //  координата по вертикали
    int y = 0;                                                  //  координата по горизонтали
    int dr = 0;                                                 //  указатель направления движения

    while (true)
    {
        matr[x, y] = num;                                       //  заполенние элемента матрицы нумератором
        num = num + 1;                                          //  подготовили нумератор к следующему элементу
        switch (dr)                                             //  переключатель направления
        {
            case 0:                                             //  движемся вправо по часовой стрелке
                if (y == matr.GetLength(1) - 1 || y < matr.GetLength(1) - 1 && matr[x, y + 1] != 0)
                    if (x == matr.GetLength(0) - 1)               //  стенка снизу
                        return matr;
                    else
                        if (matr[x + 1, y] == 0)                //  ячейка снизу свободна
                        {
                            x += 1;                             //  смещаемся вниз
                            dr = 1;                             //  меняем направление на вниз
                        }
                        else                                    //  ячейка снизу занята
                            return matr;
                else
                    y += 1;                                     //  смещаемся влево
                break;
            case 1:                                             //  движемся вниз по часовой стрелке
                if (x == matr.GetLength(0) - 1 || x < matr.GetLength(0) - 1 && matr[x + 1, y] != 0)
                    if (y == 0)                               //  стенка слева
                        return matr;
                    else
                        if (matr[x, y - 1] == 0)                //  ячейка слева свободна
                        {
                            y -= 1;                             //  смещаемся вправо
                            dr = 2;                             //  меняем направление на вправо
                        }
                        else                                    //  ячейка слева занята
                            return matr;
                else
                    x += 1;                                     //  смещаемся вниз          
                break;
            case 2:                                             //  движемся влево по часовой стрелке
                if (y == 0 || y > 0 && matr[x, y - 1] != 0)
                    if (x == 0)                               //  стенка сверху
                        return matr;
                    else
                        if (matr[x - 1, y] == 0)                //  ячейка выше свободна
                        {
                            x -= 1;                             //  смещаемся вверх
                            dr = 3;                             //  меняем направление на вверх
                        }
                        else                                    //  ячейка выше занята
                            return matr;
                else
                    y -= 1;                                     //  смещаемся влево
                break;
            case 3:                                             //  движемся вверх по часовой стрелке
                if (x == 0 || x > 0 && matr[x - 1, y] != 0)
                    if (y == matr.GetLength(1) - 1)                 //  стенка слева
                        return matr;
                    else
                        if (matr[x, y + 1] == 0)                //  ячейка слева свободна
                        {
                            y += 1;                             //  смещаемся вправо
                            dr = 0;                             //  меняем направление на вправо
                        }
                    else                                    //  ячейка слева занята
                        return matr;
                else
                    x -= 1;                                     //  смещаемся вверх
                break;
        }
    }
}

void PrintMatrix(int[,] matr)                                    //  вывод матрицы в консоль
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < matr.GetLength(1); j++)
            Console.Write("\t" + matr[i, j]);
    }
}

Console.Clear();				                                //  очистка консоли
Console.WriteLine("Введите количество строк матрицы (m): ");	//  запрос первого параметра матрицы
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов матрицы (n): ");	//  запрос второго параметра матрицы
int n = Convert.ToInt32(Console.ReadLine());
if (m > 0 && n > 0)
{                                             //  проверка на корректность
    int[,] matrix = new int[m, n];
    FillMatrix(matrix);                                    //  заполнение марицы спирально
    PrintMatrix(matrix);                                        //  вывод матрицы на консоль
}
else
    Console.WriteLine("Числа m и n должны быть больше 0.");