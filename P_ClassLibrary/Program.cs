using Models;

Car car = new Car { 
    Id = 1,
    Name = "Fiorino", 
    Color = "Branco", 
    Year = 1991 
};

Console.WriteLine(car);

if(new CarController().Insert(car))
{

}
