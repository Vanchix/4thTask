using System.Text;

Console.WriteLine("Введите строку");
var str = Console.ReadLine();
Console.WriteLine("Выберите необходимоее дейтвие.\n" +
    "Введите 1 если хотите найти слова, содержащие максимальное количество цифр.\n" +
    "Введите 2 если хотите найти самое длинное слово и определить, сколько раз оно встретилось в тексте.\n" +
    "Введите 3 если хотите заменить цифры от 0 до 9 на слова «ноль», «один», …, «девять».\n" +
    "Введите 4 если хотите вывести на экран сначала вопросительные, а затем восклицательные предложения.\n" +
    "Введите 5 если хотите вывести на экран только предложения, не содержащие запятых.\n" +
    "Введите 6 если хотите найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.");
var now = new char[] { '!', '?', '.', ' ', ',' };
char brk;
do
{
    Console.WriteLine("Введите номер действие");
    var choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case (1):
            {
                var sent = str.Split(now);
                var longestDigit = str;
                int n1 = 0;
                foreach (var sent2 in sent)
                {
                    int n = 0;
                    foreach (var letter in sent2)
                    {
                        if (char.IsDigit(letter))
                        {
                            n++;
                        }

                    }
                    if (n > n1)
                    {
                        n1 = n;
                        longestDigit = sent2;
                    }
                }
                Console.WriteLine($"Слово содержащее наибольшее количество цифр {longestDigit} с колличетсвом цифр {n1}");
            }
            break;
        case (2):
            {
                var sent = str.Split(now);
                var longestWord = "";
                int n1 = 0;
                int n2 = 0;
                foreach (var sent2 in sent)
                {
                    int n = 0;
                    foreach (var letter in sent2)
                    {
                        if (char.IsLetterOrDigit(letter))
                        {
                            n++;
                        }
                    }
                    if (n > n1)
                    {
                        n1 = n;
                        longestWord = sent2;
                        n2 = 0;
                    }
                    if (longestWord == sent2)
                    {
                        n2++;
                    }
                }
                Console.WriteLine($"Самое длинное слово {longestWord} с колличеством элементов {n1} слово встречается {n2} раз");
            }
            break;
        case (3):
            {
                var sb = new StringBuilder(str);
                sb.Replace("0", "zero");
                sb.Replace("1", "one");
                sb.Replace("2", "two");
                sb.Replace("3", "three");
                sb.Replace("4", "four");
                sb.Replace("5", "five");
                sb.Replace("6", "six");
                sb.Replace("7", "seven");
                sb.Replace("8", "eight");
                sb.Replace("9", "nine");
                str = sb.ToString();
                Console.WriteLine(str);
            }
            break;
        case (4):
            {
                var temporaryStr = str;
                temporaryStr = temporaryStr.Replace(".", ".^^");
                temporaryStr = temporaryStr.Replace("!", "!^^");
                temporaryStr = temporaryStr.Replace("?", "?^^");
                var sent = temporaryStr.Split("^^");
                Console.WriteLine("Вопросительные предложения:");
                foreach (var sent2 in sent)
                {
                    if (sent2.Contains('?'))
                    {
                        Console.WriteLine(sent2);
                    }
                }
                Console.WriteLine("Восклицательные предложения:");
                foreach (var sent2 in sent)
                {
                    if (sent2.Contains('!'))
                    {
                        Console.WriteLine(sent2);
                    }
                }
            }
            break;
        case (5):
            {
                var temporaryStr = str;
                temporaryStr = temporaryStr.Replace(".", ".^^");
                temporaryStr = temporaryStr.Replace("!", "!^^");
                temporaryStr = temporaryStr.Replace("?", "?^^");
                var sent = temporaryStr.Split("^^");
                Console.WriteLine("Предложения не содержащие заптяых:");
                foreach (var sent2 in sent)
                {
                    if (!sent2.Contains(','))
                    {
                        Console.WriteLine(sent2);
                    }
                }
            }
            break;
        case (6):
            {
                var temporaryStr = str;
                temporaryStr = temporaryStr.Replace(".", "^^");
                temporaryStr = temporaryStr.Replace("!", "^^");
                temporaryStr = temporaryStr.Replace("?", "^^");
                temporaryStr = temporaryStr.Replace(" ", "^^");
                temporaryStr = temporaryStr.Replace(",", "^^");
                var sent = temporaryStr.Split("^^");
                Console.WriteLine("Слова начинающиеся и заканчивающиеся на одну и ту же букву:");
                foreach (var sent2 in sent)
                {
                    if (sent2.Length >= 2)
                    {
                        char firstLetter = sent2[0];
                        char lastLetter = sent2[sent2.Length - 1];
                        if (firstLetter == lastLetter)
                        {
                            Console.WriteLine(sent2);
                        }
                    }
                }
            }
            break;
        default:
            Console.WriteLine("Ошибка!");
            break;
    }
    Console.WriteLine("Введите f если хотите закончить или введите другую клавишу если хотите выбрать другое действие");
    brk = Convert.ToChar(Console.ReadLine());
} while (brk != 'f');