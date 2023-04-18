
using System.ComponentModel;
using prjAndreTurismo.controllers;
using prjAndreTurismo.models;

#region City
City city = new()
{
    Description = "Sertãozinho"
};

//// inserir cidade
//if (new CityController().Insert(city.Description) > 0)
//    Console.WriteLine("SUCESSO! Registro inserido!");
//else
//    Console.WriteLine("ERRO! Registro não inserido!");

// listar todas as cidades
//new CityController().FindAll().ForEach(Console.WriteLine);

// procurar cidade pelo nome
//Console.WriteLine(new CityController().FindByName("Monte Alto").ToString());

// procurar cidade pelo id
//Console.WriteLine(new CityController().FindById(6).ToString());

// deletar cidade pelo id
//if (new CityController().Delete(17) > 0)
//    Console.WriteLine("SUCESSO! Registro deletado!");
//else
//    Console.WriteLine("ERRO! Registro não deletado!");

// atualizar cidade
//string name = "Sertãozinho";
//string newName = "Araraquara";
//if (new CityController().UpdateCity(name, newName) > 0)
//    Console.WriteLine("SUCESSO! Registro atualizado!");
//else
//    Console.WriteLine("ERRO! Registro não atualizado!");
#endregion

#region Address
Address address = new Address()
{
    Street = "Rua 1",
    Number = 1,
    Neighborhood = "Bairro 1",
    Complement = "Fundos",
    CEP = "15910000",
    City = city,
};

//if (new AddressController().Insert(address) > 0)
//    Console.WriteLine("SUCESSO! Registro inserido!");
//else
//    Console.WriteLine("ERRO! Registro não inserido!");

// procurar endereço por id
//Address address = new AddressController().FindById(2);
//if (address != null)
//    Console.WriteLine(address);
//else Console.WriteLine("Registro não encontrado");

// deletar por id
//if (new AddressController().Delete(2) > 0)
//    Console.WriteLine("Registro deletado!");
//else
//    Console.WriteLine("Registro não deletado!");

// atualizar pelo id
Address newAddress = new Address()
{
    Street = "Rua 2",
    Number = 20,
    Neighborhood = "Bairro 200",
    Complement = "Apt. 50",
    CEP = "15910000",
    City = new() { Id = 18},
};
//if (new AddressController().Update(4, newAddress) > 0)
//    Console.WriteLine("SUCESSO! Registro editado");
//else Console.WriteLine("ERRO! Registro não editado");

#endregion

#region Hotel
Hotel hotel = new()
{
    Name = "High Prices Hotel",
    Price = 210.00,
    Address = address
};

// inserir
//if (new HotelController().Isert(hotel) > 0)
//    Console.WriteLine("SUCESSO! Registro inserido!");
//else
//    Console.WriteLine("ERRO! Registro não inserido!");

// listar hoteis
new HotelController().FindAll().ForEach(Console.WriteLine);

#endregion

#region Client
Client client = new()
{
    Name = "Nicolas Balduino",
    Phone = "16997654312",
    Address = address
};

//if (new ClientController().Isert(client) > 0)
//    Console.WriteLine("SUCESSO! Registro inserido!");
//else
//    Console.WriteLine("ERRO! Registro não inserido!");
#endregion

#region Ticket
Ticket ticket = new()
{
    Origin = address,
    Destination = address,
    Client = client,
    Checkin = DateTime.Now,
    Price = 500.00
};

//if (new TicketController().Insert(ticket) > 0)
//    Console.WriteLine("SUCESSO! Registro inserido!");
//else
//    Console.WriteLine("ERRO! Registro não inserido!");
#endregion

#region Package
Package package = new()
{
    Hotel = hotel,
    Ticket = ticket,
    Price = 1050.00,
    Client = client
};

//if (new PackageController().Insert(package) > 0)
//    Console.WriteLine("SUCESSO! Registro inserido!");
//else
//    Console.WriteLine("ERRO! Registro não inserido!");

////listar todos os pacotes
//new PackageController().FindAll().ForEach(Console.WriteLine);
#endregion



