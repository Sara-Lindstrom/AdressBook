using Console_App.Interfaces;
using Console_App.Services;
using Newtonsoft.Json;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    menu.MainMenu();

} 
