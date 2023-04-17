
using prjAndreTurismo.controllers;
using prjAndreTurismo.models;

City city = new City()
{
    Description = "Monte Alto",
};

if (new CityController().Insert(city))
    Console.WriteLine("SUCESSO! Registro inserido!");
else 
    Console.WriteLine("ERRO! Registro não inserido!");
