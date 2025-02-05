﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

namespace _3rd_Lab
{
    class Theory
    {
        struct Student
        {
            public string name;
            public double average_score;
            public Student(string name, double[] marks)
            {
                this.name = name;
                average_score = marks.Sum() / marks.Length;
            }
        }
        struct Jumper
        {
            public string name;
            public double best_trial;
            public double[] trials;
            public Jumper(string name, double[] trials)
            {
                this.trials = trials;
                this.name = name;
                best_trial = trials.Max();
            }
        }

        struct Group
        {
            public string name;
            public double average_score;
            public Group(string name, double[] marks)
            {
                this.name = name;
                average_score = marks.Sum() / marks.Length;
            }
        }

        struct Sportsman
        {
            public string name;
            public double result;

            public Sportsman(string name, double result)
            {
                this.result = result;
                this.name = name;
            }
        }

        struct Person
        {
            public string[] replyes;

            public Person(string[] replyes)
            {
                this.replyes = replyes;

            }
        }
        static void Main(string[] args)
        {

            static double[] double_array(string str_, int size, ref bool flag)
            {

                double[] fin_arr = new double[size];
                string[] array_1 = str_.Split(' ');
                for (int i = 0; i < size; i++)
                {
                    if (!(array_1.Length == size & double.TryParse(array_1[i], out fin_arr[i])))
                    {
                        Console.WriteLine("input error");
                        flag = true;
                        double[] arr = { };
                        return arr;
                    }
                }
                return fin_arr;
            }
            static double[] min_value_index(double[] array)
            {
                double smallest_value = array[0];
                int smallest_index = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < smallest_value)
                    {
                        smallest_value = array[i];
                        smallest_index = i;
                    }
                }
                double[] fin_array = { smallest_value, smallest_index };
                return fin_array;
            }
            static double[] max_value_index(double[] array)
            {
                double biggest_value = array[0];
                int biggest_index = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > biggest_value)
                    {
                        biggest_value = array[i];
                        biggest_index = i;
                    }
                }
                double[] fin_array = { biggest_value, biggest_index };
                return fin_array;
            }
            static double[,] double_matrix(int rows, int columns, ref bool flag)
            {
                double[,] fin_matrix = new double[rows, columns];
                for (int j = 0; j < rows; j++)
                {
                    Console.WriteLine($"enter row {j}:");
                    string str_ = Console.ReadLine();
                    double[] str_arr = new double[columns];
                    string[] row = str_.Split(' ');
                    for (int i = 0; i < columns; i++)
                    {
                        if (!(row.Length == columns & double.TryParse(row[i], out str_arr[i])))
                        {
                            Console.WriteLine("input error");
                            flag = true;
                            double[,] mat = { };
                            return mat;
                        }
                        fin_matrix[j, i] = str_arr[i];
                    }

                }
                return fin_matrix;
            }
            static void show_matrix(double[,] matrix, int rows, int columns, ref bool flag)
            {
                Console.WriteLine();
                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < columns; k++)
                    {
                        Console.Write($"{matrix[i, k]} ");
                    }
                }
            }


            static int Factorial(int numb)
            {
                int res = 1;
                for (int i = numb; i > 1; i--)
                    res *= i;
                return res;
            }
            task_3_6();





            static void task_2_1()
            {
                bool flag = false;
                int quality = 0;
                int n;
                Console.WriteLine("enter students quality:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                if (!(res & n > 0)) return;
                Student[] student__ = new Student[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"enter student {i + 1} name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter marks(array size 4): ");
                    string str_ = Console.ReadLine();
                    double[] array_in_use = double_array(str_, 4, ref flag);
                    if (flag)
                    {
                        Console.WriteLine("input error");
                        return;
                    }
                    for (int k = 0; k < 4; k++)
                    {

                        if (array_in_use[k] < 0 | array_in_use[k] > 5)
                        {
                            Console.WriteLine("input error");
                            return;
                        }

                    }
                    student__[i] = new Student(name, array_in_use);
                    if (student__[i].average_score >= 4) quality++;



                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"{student__[i].name}:\t{student__[i].average_score}");
                }
                Console.WriteLine();
                Student[] student_excelent = new Student[quality];
                for (int i = 0, j = 0; i < quality | j < n; j++)
                {
                    if (student__[j].average_score >= 4)
                    {
                        student_excelent[i] = student__[j];
                        i++;
                    }
                }
                for (int i = 0; i < quality; i++)
                {
                    double max_score = student_excelent[i].average_score;
                    int ind = i;
                    for (int k = i + 1; k < quality; k++)
                    {
                        if (student_excelent[k].average_score > max_score)
                        {
                            max_score = student_excelent[k].average_score;
                            ind = k;

                        }
                    }

                    Console.WriteLine($"{student_excelent[ind].name}:\t{max_score}");

                    Student student2 = student_excelent[ind];
                    student_excelent[ind] = student_excelent[i];
                    student_excelent[i] = student2;
                }


            }
            static void task_2_3()
            {
                bool flag = false;
                int n;
                Console.WriteLine("enter jumpers quality:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                if (!(res & n > 0)) return;
                Jumper[] jumper__ = new Jumper[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"enter Jumper {i + 1} name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter trials(array size 3): ");
                    string str_ = Console.ReadLine();
                    double[] array_in_use = double_array(str_, 3, ref flag);
                    for (int k = 0; k < 3; k++)
                    {
                        if (array_in_use[k] <= 0)//i think 0 result is inpassible of course if we dont't speak about stas borecki
                        {
                            Console.WriteLine("input error");
                            return;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("input error");
                        return;
                    }
                    jumper__[i] = new Jumper(name, array_in_use);

                }
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{jumper__[i].name}:\t");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"{jumper__[i].trials[j]}\t");
                    }
                    Console.WriteLine();

                }
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    double max_score = jumper__[i].best_trial;
                    int ind = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (jumper__[k].best_trial > max_score)
                        {
                            max_score = jumper__[k].best_trial;
                            ind = k;

                        }
                    }

                    Console.WriteLine($"{jumper__[ind].name}:\t{max_score}");

                    Jumper jumper2 = jumper__[ind];
                    jumper__[ind] = jumper__[i];
                    jumper__[i] = jumper2;
                }


            }

            static void task_3_1()
            {
                bool flag = false;
                int n = 3;

                Group[] group__ = new Group[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"enter Group {i + 1} name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter marks(array size 5): ");
                    string str_ = Console.ReadLine();
                    double[] array_in_use = double_array(str_, 5, ref flag);
                    for (int k = 0; k < 5; k++)
                    {
                        if (array_in_use[k] < 0 | array_in_use[k] > 5)
                        {
                            Console.WriteLine("input error");
                            return;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("input error");
                        return;
                    }
                    group__[i] = new Group(name, array_in_use);

                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"{group__[i].name}:\t{group__[i].average_score}");
                }
                Console.WriteLine();

                Console.WriteLine("group name\t result");
                for (int i = 0; i < n; i++)
                {
                    double max_score = group__[i].average_score;
                    int ind = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (group__[k].average_score > max_score)
                        {
                            max_score = group__[k].average_score;
                            ind = k;

                        }
                    }

                    Console.WriteLine($"{group__[ind].name}:\t\t{max_score}");

                    Group group2 = group__[ind];
                    group__[ind] = group__[i];
                    group__[i] = group2;
                }


            }
            static void task_3_4()
            {
                bool flag = false;
                int n;
                int m;
                Console.WriteLine("enter size of group 1:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                if (!(res & n > 0)) return;
                Console.WriteLine("enter size of group 2:");
                bool res1 = int.TryParse(Console.ReadLine(), out m);
                if (!(res1 & m > 0)) return;

                Sportsman[] sportsman__ = new Sportsman[n + m];

                for (int i = 0; i < n + m; i++)
                {
                    if (i < n)
                    {
                        Console.WriteLine($"enter student {i + 1} name (group 1): ");
                    }
                    else
                    {
                        Console.WriteLine($"enter student {i + 1} name (group 2): ");
                    }
                    string name = Console.ReadLine();
                    Console.WriteLine("enter result: ");
                    double result;
                    bool res2 = double.TryParse(Console.ReadLine(), out result);
                    if (!(res2 & result > 0)) return;      //0 result is impassible i think                                 
                    sportsman__[i] = new Sportsman(name, result);

                }
                Console.WriteLine();
                Console.WriteLine("group 1:");
                for (int i = 0; i < n + m; i++)
                {
                    Console.WriteLine($"{sportsman__[i].name}:\t{sportsman__[i].result}");

                    if (n - i == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("group 2:");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("group 1\t result");
                for (int i = 0; i < n; i++)
                {
                    double max_score = sportsman__[i].result;
                    int ind = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (sportsman__[k].result > max_score)
                        {
                            max_score = sportsman__[k].result;
                            ind = k;

                        }
                    }

                    Console.WriteLine($"{sportsman__[ind].name}:\t\t{max_score}");

                    Sportsman sportsman2 = sportsman__[ind];
                    sportsman__[ind] = sportsman__[i];
                    sportsman__[i] = sportsman2;
                }
                Console.WriteLine();
                Console.WriteLine("group 2\t result");
                for (int i = n; i < n + m; i++)
                {
                    double max_score = sportsman__[i].result;
                    int ind = i;
                    for (int k = i + 1; k < n + m; k++)
                    {
                        if (sportsman__[k].result > max_score)
                        {
                            max_score = sportsman__[k].result;
                            ind = k;

                        }
                    }

                    Console.WriteLine($"{sportsman__[ind].name}:\t\t{max_score}");

                    Sportsman sportsman2 = sportsman__[ind];
                    sportsman__[ind] = sportsman__[i];
                    sportsman__[i] = sportsman2;
                }
                Console.WriteLine();
                Console.WriteLine("final result");
                for (int i = 0; i < n + m; i++)
                {
                    double max_score = sportsman__[i].result;
                    int ind = i;
                    for (int k = i + 1; k < n + m; k++)
                    {
                        if (sportsman__[k].result > max_score)
                        {
                            max_score = sportsman__[k].result;
                            ind = k;

                        }
                    }

                    Console.WriteLine($"{sportsman__[ind].name}:\t\t{max_score}");

                    Sportsman sportsman2 = sportsman__[ind];
                    sportsman__[ind] = sportsman__[i];
                    sportsman__[i] = sportsman2;
                }


            }//i do many outputs so that you can chek more easy
            static void task_3_6()
            {
                bool flag = false;
                int n;
                Console.WriteLine("enter people quality:");
                bool res = int.TryParse(Console.ReadLine(), out n);
                if (!(res & n > 0)) return;


                Person[] person__ = new Person[n];

                for (int i = 0; i < n; i++)
                {
                    string[] replyes = new string[3];
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"enter {i + 1} person {j + 1} : ");
                        replyes[j] = Console.ReadLine();

                    }
                    person__[i].replyes = replyes;
                }
                Console.WriteLine();

                double[,] matrix_in_use = new double[2, n];
                string[] cheked = new string[n];
                bool f = false;
                double quality_not_nothing = 0;
                for (int i = 0; i < n; i++)
                {
                    if (person__[i].replyes[0] != "") quality_not_nothing++;

                    double coinside = 1;
                    for (int h = 0; h < n; h++)
                    {
                        if (person__[i].replyes[0] == cheked[h])
                        { 
                        f = true;
                        break;
                        }
                    }
                    if (f)
                    {
                        f = false;
                        continue;
                        
                    }
                    string to_chek = person__[i].replyes[0];
                    for (int j = 1 + i; j < n; j++)
                    {
                        if (to_chek == person__[j].replyes[0])
                        {
                            coinside++;
                        }
                    }
                    cheked[i] = to_chek;
                    matrix_in_use[0, i] = coinside;
                    matrix_in_use[1, i] = i;

                }
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    double max_score = matrix_in_use[0, i];
                    int ind = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (matrix_in_use[0, k] > max_score)
                        {
                            max_score = matrix_in_use[0, k];
                            ind = k;

                        }
                    }
                    double pip = matrix_in_use[0, i];
                    matrix_in_use[0, i] = max_score;
                    matrix_in_use[0, ind] = pip;
                    double pip1 = matrix_in_use[1, i];
                    matrix_in_use[1, i] = ind;
                    matrix_in_use[1, ind] = pip1;

                }
                Console.WriteLine();
                Console.WriteLine("For first question:");
                for (int i = 0; i < 3; i++)
                {
                    int ind = (int)matrix_in_use[1, i];
                    Console.Write($"{person__[ind].replyes[0]}\t");
                    double percent = matrix_in_use[0, i] / quality_not_nothing * 100;
                    Console.WriteLine($"{percent} %");
                }
                double[,] matrix_in_use2 = new double[2, n];
                string[] cheked2 = new string[n];
                bool f2 = false;
                double quality_not_nothing2 = 0;
                for (int i = 0; i < n; i++)
                {
                    if (person__[i].replyes[1] != "") quality_not_nothing2++;

                    double coinside = 1;
                    for (int h = 0; h < n; h++)
                    {
                        if (person__[i].replyes[1] == cheked2[h])
                        {
                            f2 = true;
                            break;
                        }
                    }
                    if (f2)
                    {
                        f2 = false;
                        continue;

                    }
                    string to_chek = person__[i].replyes[1];
                    for (int j = 1 + i; j < n; j++)
                    {
                        if (to_chek == person__[j].replyes[1])
                        {
                            coinside++;
                        }
                    }
                    cheked2[i] = to_chek;
                    matrix_in_use2[0, i] = coinside;
                    matrix_in_use2[1, i] = i;

                }
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    double max_score = matrix_in_use2[0, i];
                    int ind = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (matrix_in_use2[0, k] > max_score)
                        {
                            max_score = matrix_in_use2[0, k];
                            ind = k;

                        }
                    }
                    double pip = matrix_in_use2[0, i];
                    matrix_in_use2[0, i] = max_score;
                    matrix_in_use2[0, ind] = pip;
                    double pip1 = matrix_in_use2[1, i];
                    matrix_in_use2[1, i] = ind;
                    matrix_in_use2[1, ind] = pip1;

                }
                Console.WriteLine();
                Console.WriteLine("For second question:");
                for (int i = 0; i < 3; i++)
                {
                    int ind = (int)matrix_in_use2[1, i];
                    Console.Write($"{person__[ind].replyes[1]}\t");
                    double percent = matrix_in_use2[0, i] / quality_not_nothing2 * 100;
                    Console.WriteLine($"{percent} %");
                }

                double[,] matrix_in_use3 = new double[2, n];
                string[] cheked3 = new string[n];
                bool f3 = false;
                double quality_not_nothing3 = 0;
                for (int i = 0; i < n; i++)
                {
                    if (person__[i].replyes[2] != "") quality_not_nothing3++;

                    double coinside = 1;
                    for (int h = 0; h < n; h++)
                    {
                        if (person__[i].replyes[2] == cheked3[h])
                        {
                            f3 = true;
                            break;
                        }
                    }
                    if (f3)
                    {
                        f3 = false;
                        continue;

                    }
                    string to_chek = person__[i].replyes[2];
                    for (int j = 1 + i; j < n; j++)
                    {
                        if (to_chek == person__[j].replyes[2])
                        {
                            coinside++;
                        }
                    }
                    cheked3[i] = to_chek;
                    matrix_in_use3[0, i] = coinside;
                    matrix_in_use3[1, i] = i;

                }
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    double max_score = matrix_in_use3[0, i];
                    int ind = i;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (matrix_in_use3[0, k] > max_score)
                        {
                            max_score = matrix_in_use3[0, k];
                            ind = k;

                        }
                    }
                    double pip = matrix_in_use3[0, i];
                    matrix_in_use3[0, i] = max_score;
                    matrix_in_use3[0, ind] = pip;
                    double pip1 = matrix_in_use3[1, i];
                    matrix_in_use3[1, i] = ind;
                    matrix_in_use3[1, ind] = pip1;

                }
                Console.WriteLine();
                Console.WriteLine("For third question:");
                for (int i = 0; i < 3; i++)
                {
                    int ind = (int)matrix_in_use3[1, i];
                    Console.Write($"{person__[ind].replyes[2]}\t");
                    double percent = matrix_in_use3[0, i] / quality_not_nothing3 * 100;
                    Console.WriteLine($"{percent} %");

















                }

                }//it was too much
        }
    }
}  
