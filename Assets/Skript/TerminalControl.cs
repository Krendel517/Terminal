using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour

{

    enum Screen { MainMenu, Password, Win,ChekNumber1,ChekNumber2,ChekNumber3,FinishScreen};
    Screen currentScreen = Screen.MainMenu;
    const string menuHint = ("Напишите 'Меню',чтобы вернуться обратно");
    int level;
    string password;
    string[] Level1Password = { "Книга", "Ручка", "Шкаф", "Буква", "Слово", };
    string[] Level2Password = { "Дубинка", "Закон", "Оружие", "Сержант", "Арест" };
    string[] Level3Password = { "Интерстеллар", "Орион", "Космолёт", "Илон Маск", "Сатурн" };
    int number1;
    int number2;
    int number3;


    // Start is called before the first frame update
    void Start()
    {

        ShowMainMenu("Александр");

    }



    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Здравствуй, " + playerName + "!");
        Terminal.WriteLine("Какой терминал вы хотите взломать сегодня?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Введите 1 - городская блиблиотека");
        Terminal.WriteLine("Введите 2 - полицейский участок");
        Terminal.WriteLine("Введите 3 - космический корабль");
        Terminal.WriteLine("Введите 4 - бухгалтерия");
        Terminal.WriteLine("Ваш выбор");

    }




    void OnUserInput(string input)
    {
        if (input == "Меню")
        {
            ShowMainMenu("ты опять вернулся цел и невредим");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            ChekPassword(input);
        }
        else if (currentScreen == Screen.ChekNumber1)
        {
            number1 = int.Parse(input);
            Start2ndScreen();
        }
        else if (currentScreen == Screen.ChekNumber2)
        {
            number2 = int.Parse(input);
            Start3rdScreen();
        }
        else if (currentScreen == Screen.ChekNumber3)
        {
            number3 = int.Parse(input);
            StartFinishScreen(input);
        }
        else if (currentScreen == Screen.FinishScreen)
        {
            if (input == "1")
            {
                Start4thGame();
            }
            else if (input == "0")
            {
                ShowMainMenu("победитель!");
            }
        }
    
    }

    void Start4thGame()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.ChekNumber1;
        Terminal.WriteLine("Введите первое число");

    }

    void Start2ndScreen()
    {
        currentScreen = Screen.ChekNumber2;
        Terminal.ClearScreen();
        Terminal.WriteLine("Введите второе число:");
    }

    void Start3rdScreen()
    {
        currentScreen = Screen.ChekNumber3;
        Terminal.ClearScreen();
        Terminal.WriteLine("Введите произведение первых двух чисел:");
    }

    void StartFinishScreen(string input)
    {
        currentScreen = Screen.FinishScreen;
        int sum;
        sum = number1 * number2;
        Terminal.ClearScreen();
        if (number3 == sum)
        {
            Terminal.WriteLine("Верно бухглатерия ваша!");
            Terminal.WriteLine("Введите 0 для перехода в меню");
            
        }
        else
        {
            Terminal.WriteLine("Неверно!");
            Terminal.WriteLine("Введите 1 чтобы попробовать снова");
        }
      
    }


    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            GameStart();
        }

        else if (input == "Привет")
        {
            Terminal.WriteLine("Ем...да..привет.Почему ты разговариваешь со мной? ._.");
        }
        else if (input == "Пока")
        {
            Terminal.WriteLine("Та ну,ты серьозно что ли?!Уже уходишь!?");
        }
        else
        {
            Terminal.WriteLine("Введите правильное значение");
        }
    }
    void ChekPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen(); 
        }
        else
        {
            GameStart();
        }
        


            }
    void ShowWinScreen()
    {
         Terminal.ClearScreen();
         currentScreen = Screen.Win;
         switch(level)
        {
        case 1:
         Terminal.WriteLine ("Пароль верный,держите книгу!");
         Terminal.WriteLine (@"
    _______
   /      /,
  /      //
 /______//
(______(/
");
        break;
        case 2:
            Terminal.WriteLine("Пароль верный,держите оружие,вы заслужили!");
            Terminal.WriteLine(@"
  _,_______
 / __.==--)
/#(-'
`-'            
            ");
            break; 
            case 3:
            Terminal.WriteLine("Пароль верный, держите своего робота!");
            Terminal.WriteLine(@"
    .---.       
  .'_:___'.
  |__ --==|
  [  ]  :[|       
  |__| I=[|      
            ");
 //                 / / ____ |
 //| -/.____.'      
 /// ___\ / ___\  
            break;
        }
        Terminal.WriteLine(menuHint);


    }




    void GameStart()
    { 
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = Level1Password[Random.Range(0, Level1Password.Length)];
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine("Вы в библиотеке,будтье потише.");
                break;
            case 2:
                password = Level2Password[Random.Range(0, Level2Password.Length)];
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine("Вы в полицейском участке,будтье бдительны,вас могут заметить.");
                break;
            case 3:
                password = Level3Password[Random.Range(0, Level3Password.Length)];
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine("Вы на космическом корабле,до сих пор непривыкну к невисомости.");
                break;
            case 4:
                Start4thGame();
                

                break;

        }  
        
        if (level != 4) 
        {
            Terminal.WriteLine("Вот ваша подсказка:" + password.Anagram());
            Terminal.WriteLine("Введите пароль:");
        }
        
    }

    

}


