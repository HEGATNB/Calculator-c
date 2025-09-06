int a = 0;
int b = 0;
console.writeline("Проект 'калькулятор' на C#");
console.writeline("Для выхода введите exit, для использования калькулятора введите 1 число, 2 число и операцию.");
while (true){
    var input = Console.ReadLine(); 
    if (input = "exit"){
        break;
    }
    foreach (char c in input){
        if ( Char.IsDigit()){
               if (convert.ToInt(input)){
                break;
               }
        }
    }
}