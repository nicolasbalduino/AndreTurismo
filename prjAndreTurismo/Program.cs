
using System.ComponentModel;
using prjAndreTurismo.controllers;
using prjAndreTurismo.models;


int Menu()
{
    Console.Clear();
    Console.WriteLine("MENU ");
    Console.WriteLine("0 - Sair do programa");
    Console.WriteLine("1 - Cidade Cadastrar");
    Console.WriteLine("2 - Cidade Listar todas");
    Console.WriteLine("3 - Cidade Procurar por nome");
    Console.WriteLine("4 - Cidade procurar por id");
    Console.WriteLine("5 - Cidade atualizar");
    Console.WriteLine("6 - Cidade deletar");
    Console.WriteLine();
    Console.WriteLine("7 - Endereço Cadastrar");
    Console.WriteLine("8 - Endereço Listar todos");
    Console.WriteLine("9 - Endereço procurar por id");
    Console.WriteLine("10 - Endereço atualizar");
    Console.WriteLine("11 - Endereço deletar");
    Console.WriteLine();
    Console.WriteLine("12 - Hotel Cadastrar");
    Console.WriteLine("13 - Hotel Listar todas");
    Console.WriteLine("14 - Hotel Procurar por nome");
    Console.WriteLine("15 - Hotel procurar por id");
    Console.WriteLine("16 - Hotel atualizar");
    Console.WriteLine("17 - Hotel deletar");
    Console.WriteLine();
    Console.WriteLine("18 - Cliente Cadastrar");
    Console.WriteLine("19 - Cliente Listar todas");
    Console.WriteLine("20 - Cliente Procurar por nome");
    Console.WriteLine("21 - Cliente procurar por id");
    Console.WriteLine("22 - Cliente atualizar");
    Console.WriteLine("23 - Cliente deletar");
    Console.WriteLine();
    Console.WriteLine("24 - Ticket Cadastrar");
    Console.WriteLine("25 - Ticket Listar todas");
    Console.WriteLine("26 - Ticket Procurar por nome");
    Console.WriteLine("27 - Ticket procurar por id");
    Console.WriteLine("28 - Ticket atualizar");
    Console.WriteLine("29 - Ticket deletar");
    Console.WriteLine();
    Console.WriteLine("30 - Pacote Cadastrar");
    Console.WriteLine("31 - Pacote Listar todas");
    Console.WriteLine("32 - Pacote Procurar por nome");
    Console.WriteLine("33 - Pacote procurar por id");
    Console.WriteLine("34 - Pacote atualizar");
    Console.WriteLine("35 - Pacote deletar");
    Console.Write("Digite sua escolha: ");
    int.TryParse(Console.ReadLine(), out int op);

    return op;
}



City city = new()
{
    Description = "Sertãozinho"
};

Address address = new Address()
{
    Street = "Rua 1",
    Number = 1,
    Neighborhood = "Bairro 1",
    Complement = "Fundos",
    CEP = "15910000",
    City = city,
};

Address newAddress = new Address()
{
    Street = "Rua 2",
    Number = 20,
    Neighborhood = "Bairro 200",
    Complement = "Apt. 50",
    CEP = "15910000",
    City = city,
};

Hotel hotel = new()
{
    Name = "High Prices Hotel",
    Price = 210.00,
    Address = address
};

Hotel newHotel = new()
{
    Name = "Low Prices Hotel",
    Price = 10.00,
    Address = new() { Id = 2},
};

Client client = new()
{
    Name = "Nicolas Balduino",
    Phone = "16997654312",
    Address = address
};

Client newClient = new()
{
    Name = "Leticia Balduino",
    Phone = "99888887777",
    Address = newAddress
};

Ticket ticket = new()
{
    Origin = address,
    Destination = newAddress,
    Client = client,
    Checkin = DateTime.Now,
    Price = 500.00
};

Package package = new()
{
    Hotel = hotel,
    Ticket = ticket,
    Price = 1050.00,
    Client = client
};


int op;
do
{
    op = Menu();
    switch (op)
    {
        case 1:
            if (new CityController().Insert(city.Description) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 2:
            new CityController().FindAll().ForEach(Console.WriteLine);
            break;
        case 3:
            Console.WriteLine(new CityController().FindByName("Sertãozinho").ToString());
            break;
        case 4:
            Console.WriteLine(new CityController().FindById(1).ToString());
            break;
        case 5:
            string name = "Sertãozinho";
            string newName = "Araraquara";
            if (new CityController().UpdateCity(name, newName) > 0)
                Console.WriteLine("SUCESSO! Registro atualizado!");
            else
                Console.WriteLine("ERRO! Registro não atualizado!");
            break;
        case 6:
            if (new CityController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado!");
            else
                Console.WriteLine("ERRO! Registro não deletado!");
            break;
        case 7:
            if (new AddressController().Insert(address) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 8:
            break;
        case 9:
            Address FindAddress = new AddressController().FindById(1);
            if (FindAddress != null)
                Console.WriteLine(FindAddress);
            else Console.WriteLine("Registro não encontrado");
            break;
        case 10:
            if (new AddressController().Update(1, newAddress) > 0)
                Console.WriteLine("SUCESSO! Registro editado");
            else Console.WriteLine("ERRO! Registro não editado");
            break;
        case 11:
            if (new AddressController().Delete(1) > 0)
                Console.WriteLine("Registro deletado!");
            else
                Console.WriteLine("Registro não deletado!");
            break;
        case 12:
            if (new HotelController().Insert(hotel) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 13:
            new HotelController().FindAll().ForEach(Console.WriteLine);
            break;
        case 14:
            Console.WriteLine(new HotelController().FindByName("High Prices Hotel"));
            break;
        case 15:
            Console.WriteLine(new HotelController().FindById(1));
            break;
        case 16:
            if (new HotelController().Update(1, newHotel) > 0)
                Console.WriteLine("SUCESSO! Registro editado");
            else Console.WriteLine("ERRO! Registro não editado");
            break;
        case 17:
            if (new HotelController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado!");
            else
                Console.WriteLine("ERRO! Registro não deletado!");
            break;
        case 18:
            if (new ClientController().Isert(newClient) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 19:
            new ClientController().FindAll().ForEach(Console.WriteLine);
            break;
        case 20:
            new ClientController().FindByName("Nicolas Balduino").ForEach(Console.WriteLine);
            break;
        case 21:
            Console.WriteLine(new ClientController().FindById(100));
            break;
        case 22:
            if (new ClientController().Update(1, newClient) > 0)
                Console.WriteLine("SUCESSO! Registro atualizado");
            else
                Console.WriteLine("ERRO! Registro não atualizado");
            break;
        case 23:
            if (new ClientController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado");
            else
                Console.WriteLine("ERRO! Registro não deletado");
            break;
        case 24:
            if (new TicketController().Insert(ticket) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 25:
            new TicketController().FindAll().ForEach(Console.WriteLine);
            break;
        case 26:
            // campo inutil
            break;
        case 27:
            Console.WriteLine(new TicketController().FindById(1));
            break;
        case 28:
            // atualizar
            break;
        case 29:
            if (new TicketController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado com sucesso");
            else
                Console.WriteLine("ERRO! Registro não deletado");
            break;
        case 30:
            if (new PackageController().Insert(package) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 31:
            new PackageController().FindAll().ForEach(Console.WriteLine);
            break;
        case 32:
            Console.WriteLine(new PackageController().FindById(1));
            break;
        case 33:
            // atualizar
            break;
        case 34:
            if (new PackageController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado");
            else
                Console.WriteLine("ERRO! Registro não deletado");
            break;
        default:
            break;
    }
    Console.ReadLine();
} while (op != 0);


