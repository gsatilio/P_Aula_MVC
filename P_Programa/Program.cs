using Controllers;
using Models;

/*
Insurance insurance = new Insurance()
{
    Description = "Seguro TOP"
};
*/
/*
if (ReturnInsuranceController().Insert(insurance))
{
    Console.WriteLine("Inserido com sucesso");
} else
{
    Console.WriteLine("Erro de insercao");
}
*/

int opt = -1;

do
{
    Console.WriteLine("Menu");
    Console.WriteLine("1 - Criar Carro");
    Console.WriteLine("2 - Atualizar Carro");
    Console.WriteLine("3 - Deletar Carro");
    Console.WriteLine("4 - Obter Carro");
    Console.WriteLine("5 - Obter Todos os Carros");
    Console.WriteLine("6 - Inserir Varios carros iguais");
    Console.WriteLine("7 - Relatorio");
    opt = int.Parse(Console.ReadLine());
    switch (opt)
    {
        case 1:
            Console.WriteLine("Informe o Nome do carro:");
            string carname = Console.ReadLine();
            Console.WriteLine("Informe a Cor:");
            string carcolor = Console.ReadLine();
            Console.WriteLine("Informe o Ano do carro:");
            int caryear = int.Parse(Console.ReadLine());
            InsertCar(carname, carcolor, caryear);
            break;
        case 2:
            UpdateCar();
            break;
        case 3:
            break;
        case 4:
            GetCar();
            break;
        case 5:
            GetAllCar();
            break;
        case 6:
            DestruirBanco();
            break;
        case 7:
            foreach (var item in ReturnCarController().GetAll().Where(x => x.Id > 5).ToList().Take(10))
            {
                Console.WriteLine(item);
            }
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
} while (opt != 0);


InsuranceController ReturnInsuranceController()
{
    //InsuranceController insurance = new InsuranceController(new InsuranceService(new InsuranceRepository()));
    InsuranceController insurance = new InsuranceController();
    return insurance;
}

CarController ReturnCarController()
{
    //CarController car = new CarController(new CarService(new CarRepository()));
    CarController car = new CarController();
    return car;
}


void InsertCar(string carname, string carcolor, int caryear)
{
    Car car = new Car
    {
        Name = carname,
        Color = carcolor,
        Year = caryear,
        Insurance = new Insurance {Description = "NovoSeg"}
    };

    if (ReturnCarController().Insert(car))
        Console.WriteLine("Carro registrado");
    else Console.WriteLine("Carro nao registrado");
};



void UpdateCar()
{
    string carname, carcolor;
    int caryear;
    Console.WriteLine("Informe o Id do carro desejado:");
    int id = int.Parse(Console.ReadLine());

    Car? car = ReturnCarController().Get(id);

    Console.WriteLine("Informe o nome do carro desejado:");
    carname = Console.ReadLine();
    Console.WriteLine("Informe a cor do carro desejado:");
    carcolor = Console.ReadLine();
    Console.WriteLine("Informe o ano do carro:");
    caryear = int.Parse(Console.ReadLine());

    car.Color = carcolor;
    car.Year = caryear;
    car.Name = carname;
    Console.WriteLine("\nExemplo UPDATE:");
    Console.WriteLine(ReturnCarController().Update(car) ? "Registro Atualizado" : "Erro ao atualizar Registro");
}

void DeleteCar()
{
    Console.WriteLine("Informe o Id do carro desejado:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("\nExemplo DELETE:");
    Console.WriteLine(ReturnCarController().Delete(id) ? "Registro Deletado" : "Erro ao deletar Registro");

}

void GetCar()
{
    Console.WriteLine("Informe o Id do carro desejado:");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("\nExemplo GET:");
    Car? car = ReturnCarController().Get(id);
    Console.WriteLine(car != null ? car : "Não retornou");
}

void GetAllCar()
{
    Console.WriteLine("\nExemplo GETALL:");
    foreach (var item in ReturnCarController().GetAll())
    {
        Console.WriteLine(item.ToString());
    }
}

void DestruirBanco()
{
    string carname = "Carro Zica";
    string carcolor = "White";
    int caryear = 2001;

    for (int i = 0; i < 10; i++)
    {
        InsertCar(carname, carcolor, caryear);
    }
}