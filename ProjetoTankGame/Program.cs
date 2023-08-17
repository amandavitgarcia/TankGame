using ProjetoTankGame;

//Verificando se o nome digitado pelo usuário está na lista de tanques 
Tank CheckIfTankExists(string name, List<Tank> customTanksList)
{
    foreach (var tank in customTanksList)
    {
        if (tank.Name.ToUpper() == name.ToUpper())
        {
            return tank;
        }
    }

    return null;
}

//Criação dos tanques
var customTanksList = new List<Tank>();

int numberTanks = 0;

while(numberTanks < 2 || numberTanks > 10)
{
    Console.WriteLine("------------Tank Battle ------------");
    Console.WriteLine("\nInforme quantos tanques vão duelar \n -- Mín  2 & Máx 10 --");
    Console.WriteLine("\nRespeite os limites de quantidades mínima e máxima. ");
    
    
    //Tratando algumas exceções
    try
    {
        numberTanks = int.Parse(Console.ReadLine());
    }
    catch(FormatException exception)
    {
        Console.WriteLine("\nO valor digitado não corresponde ao solicitado.\n");
    }
    catch (ArgumentNullException exception)
    {
        Console.WriteLine("\nNenhum valor foi informado.\n");
    }
}

//Incluindo os tanques digitados pelo usuário na lista de tanques
int tankCounter = 1;

while(tankCounter - 1 != numberTanks)
{
    Console.WriteLine("-----------------------------------");
    Console.WriteLine($"\nDigite o nome do: {tankCounter}° tanque");
    string nome = Console.ReadLine();
    var newTank = new Tank(nome);
    customTanksList.Add(newTank);
    tankCounter += 1;
}

//Iniciando rodadas com um tanque gerado aleatóriamente
int roundCounter = 1;

while (customTanksList.Count != 1)
{
    Console.WriteLine($"\n \n \n \n-----------------------------------");
    Console.WriteLine($"\nComeçando {roundCounter}ª rodada...");
    Console.WriteLine($"\nQuantidade de Jogadores: {customTanksList.Count}");

    Console.WriteLine("\nSorteando quem vai atirar...");


    Random rnd = new Random();
    int randomNumber = rnd.Next(0, customTanksList.Count);
    var sniperTank = customTanksList[randomNumber];
    Console.WriteLine($"\nO tanque sorteado foi: {sniperTank.Name}");

    bool isTankSelected = false;

    while (!isTankSelected)
    {
        Console.WriteLine("\nLista de alvos disponiveis:");

        //print dos tanques pra atirar
        foreach (var tank in customTanksList)
        {
            if (tank != sniperTank)
            {
                Console.WriteLine($"{tank.Name}");
            }
        }
        Console.WriteLine("\nQual tanque será atingido? \n");
        string name = Console.ReadLine();

        //Validando o tanque que será atingido
        var tankDamaged = CheckIfTankExists(name, customTanksList);
        if(tankDamaged != null)
        {
            sniperTank.FireAt(tankDamaged);

            //Removendo o tanque com a blindagem zerada
            if (!tankDamaged.Alive)
            {
                customTanksList.Remove(tankDamaged);
            }

            roundCounter++;
            isTankSelected = true;
        }
        else
        {
            Console.WriteLine($"\nTanque Selecionado Inválido");
        }
    }
}
//Informando o tanque vencedor pegando o primeiro (e unico) que sobrou da lista de tanques
Console.WriteLine($"\nO vencedor é {customTanksList.First().Name}");
Console.WriteLine("");
Console.WriteLine("Fim");