
#region Translate

#if true
class Program
{
    static Dictionary<string, Dictionary<string, List<string>>> dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Меню: ");
            Console.WriteLine("0. Отображать словари");
            Console.WriteLine("1. Создать словарь ");
            Console.WriteLine("2. Добавить слово в перевод ");
            Console.WriteLine("3. Заменить слово или перевод ");
            Console.WriteLine("4. Удалить слово или перевод ");
            Console.WriteLine("5. Искать перевод слово ");
            Console.WriteLine("6. Сохранить словарь в файл ");
            Console.WriteLine("7. Завершение работы ");
            Console.WriteLine("Ваш выбор: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        ShowDictionary();
                        break;
                    case 1:
                        Console.Clear();
                        AddDictonary();
                        break;
                    case 2:
                        Console.Clear();
                        AddTranslation();
                        break;
                    case 3:
                        Console.Clear();
                        ReplaceTranslation();
                        break;
                    case 4:
                        Console.Clear();
                        DeleteTransaltion();
                        break;
                    case 5:
                        Console.Clear();
                        SearchTranslation();
                        break;
                    case 6:
                        Console.Clear();
                        SaveToFileTranslation();
                        break;
                    case 7:
                        return;
                    default:
                        break;

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Сделайте правильный выбор! ");
            }
        }
    }


    static void ShowDictionary()
    {
        Console.Clear();
        if (dictionaries.Count >= 0)
        {
            Console.WriteLine("Словарей нету. ");
            Console.WriteLine("Для продолжения нажмите любую клавишу. ");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        Console.WriteLine("Словари: ");
        for (int i = 0; i < dictionaries.Count; i++)
        {
            string dictionaryName = dictionaries.Keys.ElementAt(i);
            Console.WriteLine($"{i + 1}. {dictionaryName}");
        }
    }


    static void AddDictonary()
    {
        Console.WriteLine("Введите имя словаря: ");
        string dictionaryName = Console.ReadLine();
        dictionaries[dictionaryName] = new Dictionary<string, List<string>>();
        Console.Clear();
        Console.WriteLine($"Словарь \"{dictionaryName}\" успешно создан. ");
        Console.WriteLine("Для продолжения нажмите любую клавишу. ");
        Console.ReadKey();
        Console.Clear();
    }

    static void AddTranslation()
    {
        Console.WriteLine("Введите название словаря: ");
        string dictionaryName = Console.ReadLine();


        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.Clear();
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Введите перевод для слова \"{word}\": ");
            string translation = Console.ReadLine();
            Console.Clear();
            try
            {
                List<string> translations = translation.Split(',').Select(x => x.Trim()).ToList();
                if (dictionaries[dictionaryName].ContainsKey(word))
                {
                    dictionaries[dictionaryName][word].AddRange(translations);
                }
                else
                {
                    dictionaries[dictionaryName][word] = translations;
                }
                Console.Clear();
                Console.WriteLine($"Слово \"{word}\" и его перевод \"{string.Join(", ", translations)}\" успешно добавлены в словарь \"{dictionaryName}\"");
                Console.WriteLine("Для продолжения нажмите любую клавишу. ");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"Словарь \"{dictionaryName}\" не найдён.");
            Console.WriteLine("Для продолжения нажмите любую клавишу. ");
            Console.ReadKey();
            Console.Clear();
        }

    }

    static void DeleteTransaltion()
    {
        Console.WriteLine("Введите названия словаря: ");
        string dictionaryName = Console.ReadLine();

        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.WriteLine("Введите слово или перевод для удаления: ");
            string wordTranslation = Console.ReadLine();
            bool wordDeleted = false;

            foreach (var word in dictionaries[dictionaryName].Keys.ToList())
            {
                if (word == wordTranslation || dictionaries[dictionaryName][word].Contains(wordTranslation))
                {
                    dictionaries[dictionaryName].Remove(word);
                    wordDeleted = true;
                }
                else
                {
                    dictionaries[dictionaryName][word].RemoveAll(t => t == wordTranslation);
                    if (dictionaries[dictionaryName][word].Count > 0)
                    {
                        dictionaries[dictionaryName].Remove(word);
                    }
                }
            }
            if (wordDeleted)
            {
                Console.WriteLine($"Слово или перевод \"{wordTranslation}\" удалён из словаря \"{dictionaryName}\".");
            }
            else
            {
                Console.WriteLine("Слово или перевод не найдены в словаре. ");
            }
        }
        else
        {
            Console.WriteLine("Словарь не найдён. ");
        }
    }

    static void SearchTranslation()
    {
        Console.WriteLine("Введите названия словаря: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.WriteLine("Введите слово для поиска: ");
            string wordSearch = Console.ReadLine();

            foreach (var word in dictionaries[dictionaryName].Keys)
            {
                if (word == wordSearch || dictionaries[dictionaryName][word].Contains(wordSearch))
                {
                    Console.WriteLine($"Слово: {word}");
                    Console.WriteLine($"Перевод: {string.Join(", ", dictionaries[dictionaryName][word])}");
                }
                else
                {
                    Console.WriteLine($"Слово \"{word}\" не найдено в словаре \"{dictionaryName}\".");
                }
            }
        }
        else
        {
            Console.WriteLine("Словарь не найдён. ");
        }
    }

    static void ReplaceTranslation()
    {
        Console.WriteLine("Введите названия словаря: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.WriteLine("Введите слово, которое хотите заменить: ");
            string wordToReplace = Console.ReadLine();
            Console.WriteLine("Введите новое слово: ");
            string newWord = Console.ReadLine();
            Console.WriteLine("Введите новый перевод, разделяя их запятой: ");
            string newTranslationInput = Console.ReadLine();

            if (dictionaries[dictionaryName].ContainsKey(wordToReplace))
            {
                dictionaries[dictionaryName].Remove(wordToReplace);
                List<string> newTranslations = newTranslationInput.Split(',').Select(x => x.Trim()).ToList();
                dictionaries[dictionaryName][newWord] = newTranslations;
                Console.WriteLine($"Слово \"{wordToReplace}\" успешно заменено на \"{newWord}\" в словаре \"{dictionaryName}\".");
            }
            else
            {
                Console.WriteLine($"Слово \"{wordToReplace}\" которое вы хотите заменить, отсутствует в словаре \"{dictionaryName}\".");
            }
        }
        else
        {
            Console.WriteLine($"Словарь \"{dictionaryName}\" не существует.");
        }
    }

    static void SaveToFileTranslation()
    {
        Console.WriteLine("Введите название словаря для сохранения: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.WriteLine("Введите имя файла для экспорта: ");
            string fileName = Console.ReadLine();

            using StreamWriter writer = new StreamWriter(fileName);
            foreach (var word in dictionaries[dictionaryName])
            {
                writer.WriteLine($"Слово: \"{word}\"");
                writer.WriteLine($"Переводы: \"{string.Join(", ", word.Value)})");
                writer.WriteLine();

            }
            Console.WriteLine($"Словарь \"{dictionaryName}\" был успешно записал в файл \"{fileName}.");
        }
        else
        {
            Console.WriteLine($"Словарь \"{dictionaryName}\" не существует. ");
        }
    }
}

#endif
#endregion
