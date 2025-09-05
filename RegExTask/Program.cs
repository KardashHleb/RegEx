using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        string text = @"Он сказал: ""Привет,
это многострочный
текст!"". А также «Еще один
пример на
нескольких строках».";

        string pattern = @"(""|“|«)([\s\S]*?)(""|”|»)";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Найденный текст в кавычках:");
        Console.WriteLine("========================================\n");

        foreach (Match match in matches)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(match.Groups[1].Value); // открывающие кавычки

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(match.Groups[2].Value); // текст без кавычек

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(match.Groups[3].Value); // закрывающие кавычки

            Console.ResetColor();
            Console.WriteLine("\n");
        }

        Console.WriteLine("========================================");

        // Альтернативно: подсветка прямо в исходном тексте
        Console.WriteLine("\nИсходный текст с подсветкой:");
        Console.WriteLine("========================================");

        string highlightedText = Regex.Replace(text, pattern,
            match =>
            {
                return $"\u001b[32m{match.Groups[1].Value}\u001b[0m" +    // зеленые кавычки
                       $"\u001b[33m{match.Groups[2].Value}\u001b[0m" +    // желтый текст
                       $"\u001b[32m{match.Groups[3].Value}\u001b[0m";     // зеленые кавычки
            });

        Console.WriteLine(highlightedText);











        //////////////////////////////TASK5
        ///
        /*
        string text = "Prices: 3.14, 123.456, .5 (неполное), 7. (неполное), 1,000.25 (с запятой), 1 234.56 (с пробелом)";
        string pattern = @"\b\d+\.\d+\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Найдены дробные числа:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
        */

        ///////////////////////////////////TASK4
        ///
        /*

        string text = "Breakfast at 09:00, meeting at 15:30, invalid time 37:98, 25:61, 12:60";
        string pattern = @"\b([01][0-9]|2[0-3]):([0-5][0-9])\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Найдено корректное время:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }

        */





        ///////////////////////////////TASK3
        ///
        /*
        string[] expressions = {
            "(3+5)*(2-1)",
            "((2+3)*4)",
            "(1+2))-3",
            "((1+2)*3",
            ")(1+2)(",
            "2*9-6*5",
            "(3+5)-9*4",
            "((1+2)*(3-4))/(5+6)"
        };

        Console.WriteLine("Проверка корректности выражений со скобками:");
        Console.WriteLine("============================================\n");

        foreach (string expression in expressions)
        {
            bool isValid = IsValidExpression(expression);
            Console.WriteLine($"Выражение: {expression}");
            Console.WriteLine($"Корректно: {(isValid ? "✓ ДА" : "✗ НЕТ")}");
            Console.WriteLine("---");
        }
    

    static bool IsValidExpression(string expression)
    {
        Stack<char> bracketStack = new Stack<char>();
        var bracketPairs = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };

        foreach (char c in expression)
        {
            // Если открывающая скобка - кладем в стек
            if (bracketPairs.ContainsValue(c))
            {
                bracketStack.Push(c);
            }
            // Если закрывающая скобка
            else if (bracketPairs.ContainsKey(c))
            {
                // Если стек пуст или последняя открывающая не соответствует
                if (bracketStack.Count == 0 || bracketStack.Pop() != bracketPairs[c])
                {
                    return false;
                }
            }
        }

        // Выражение корректно, если стек пуст (все скобки закрыты)
        return bracketStack.Count == 0;
    }
        */







        //////////////////////////////////TASK2
        ///
        /*
        string[] examples = {
            "2*9-6*5",
            "(3+5)-9*4",
            "1+2-3*4/5",
            "10+20-30+40"
        };

        string pattern = @"\d+(?!\+)";

        foreach (string text in examples)
        {
            Console.WriteLine($"Текст: {text}");
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Найдено число: {match.Value} (позиция: {match.Index})");
            }
            Console.WriteLine("---");
        }
        */


        ////////////////////////TASK1 
        /*
        string text = "Colors: #FFFFFF (white), #FF0000 (red), #123ABC, #invalid, #12345";
        string pattern = @"#([A-Fa-f0-9]{6})";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Найдены цвета:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
        */
    }
}