using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
 
{
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    const string menuHint = ("Напишите 'Меню',чтобы вернуться обратно");
    int level;
    string password;
    string[] Level1Password = {"Книга","Ручка","Шкаф","Буква","Слово", };
    string[] Level2Password = { "Дубинка", "Закон", "Оружие", "Сержант", "Арест" };
    string[] Level3Password = { "Интерстеллар", "Орион", "Космолёт", "Илон Маск", "Сатурн" };

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
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
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
  / / ____|         
 |-/.____.'      
/___\ /___\   
            ");
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
                Terminal.WriteLine("Вы в библиотеке,будтье потише.");
                break;
            case 2:
                password = Level2Password[Random.Range(0, Level2Password.Length)];
                Terminal.WriteLine("Вы в полицейском участке,будтье бдительны,вас могут заметить.");
                break;
            case 3:
                password = Level3Password[Random.Range(0, Level3Password.Length)];
                Terminal.WriteLine("Вы на космическом корабле,до сих пор непривыкну к невисомости.");
                break;
        }        

        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Вот ваша подсказка:"+ password.Anagram());
        Terminal.WriteLine("Введите пароль:");
    }
    
    }

    




