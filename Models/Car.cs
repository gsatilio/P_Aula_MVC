﻿namespace Models
{
    public class Car
    {
        public static readonly string INSERT = " INSERT INTO TB_CAR (Name, Color, Year, InsuranceId) VALUES (@Name, @Color, @Year, @InsuranceId) ";
        public static readonly string UPDATE = " UPDATE TB_CAR SET Name = @Name, Color = @Color, Year = @Year WHERE Id = @Id ";
        public static readonly string GET = " SELECT Id, Name, Color, Year FROM TB_CAR WHERE Id = @Id  ";
        public static readonly string GETALL = " SELECT Id, Name, Color, Year FROM TB_CAR ";
        public static readonly string DELETE = "";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Insurance Insurance { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Cor: {Color}, Ano: {Year}";
        }
    }
}
