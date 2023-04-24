using System.Collections.Immutable;
using System.ComponentModel;
using Controllers;
using Models;

int Menu()
{
    Console.Clear();
    Console.WriteLine("MENU ");
    Console.WriteLine("01 - Cidade Cadastrar");
    Console.WriteLine("02 - Cidade Listar todas");
    Console.WriteLine("03 - Cidade Procurar por nome");
    Console.WriteLine("04 - Cidade procurar por id");
    Console.WriteLine("05 - Cidade atualizar");
    Console.WriteLine("06 - Cidade deletar");
    Console.WriteLine();
    Console.WriteLine("11 - Endereço Cadastrar");
    Console.WriteLine("12 - Endereço Listar todos");
    Console.WriteLine("13 - Endereço procurar por id");
    Console.WriteLine("14 - Endereço atualizar");
    Console.WriteLine("15 - Endereço deletar");
    Console.WriteLine();
    Console.WriteLine("21 - Hotel Cadastrar");
    Console.WriteLine("22 - Hotel Listar todas");
    Console.WriteLine("23 - Hotel Procurar por nome");
    Console.WriteLine("24 - Hotel procurar por id");
    Console.WriteLine("25 - Hotel atualizar");
    Console.WriteLine("26 - Hotel deletar");
    Console.WriteLine();
    Console.WriteLine("31 - Cliente Cadastrar");
    Console.WriteLine("32 - Cliente Listar todas");
    Console.WriteLine("33 - Cliente Procurar por nome");
    Console.WriteLine("34 - Cliente procurar por id");
    Console.WriteLine("35 - Cliente atualizar");
    Console.WriteLine("36 - Cliente deletar");
    Console.WriteLine();
    Console.WriteLine("41 - Ticket Cadastrar");
    Console.WriteLine("42 - Ticket Listar todas");
    Console.WriteLine("43 - Ticket procurar por id");
    Console.WriteLine("44 - Ticket atualizar");
    Console.WriteLine("45 - Ticket deletar");
    Console.WriteLine();
    Console.WriteLine("51 - Pacote Cadastrar");
    Console.WriteLine("52 - Pacote Listar todas");
    Console.WriteLine("53 - Pacote procurar por id");
    Console.WriteLine("54 - Pacote atualizar");
    Console.WriteLine("55 - Pacote deletar");
    Console.WriteLine("Para sair, digite qualquer coisa fora as opções do menu");
    Console.Write("\nDigite sua escolha: ");
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
    PostalCode = "15910000",
    City = city,
};

Address newAddress = new Address()
{
    Street = "Rua 2",
    Number = 20,
    Neighborhood = "Bairro 200",
    Complement = "Apt. 50",
    PostalCode = "15910000",
    City = city,
};

Address clientAddress = new Address()
{
    Street = "Rua 3",
    Number = 30,
    Neighborhood = "Bairro 300",
    Complement = "Apt. 10",
    PostalCode = "10000",
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
    Address = clientAddress
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

Ticket newTicket = new()
{
    Id = 1,
    Origin = newAddress,
    Destination = address,
    Client = newClient,
    Checkin = DateTime.Now,
    Price = 20000.00
};

Package package = new()
{
    Hotel = hotel,
    Ticket = ticket,
    Price = 1050.00,
    Client = client
};

Package newPackage = new()
{
    Id = 1,
    Price = 5000.00,
};

int op;
do
{
    op = Menu();
    Console.WriteLine();
    switch (op)
    {
        case 1:
            if (new CityController().Insert(city) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 2:
            var showcities = new CityController().FindAll();
            if (showcities.Count > 0)
                showcities.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 3:
            var showcityname = new CityController().FindByName("Sertãozinho");
            if (showcityname != null)
                Console.WriteLine(showcityname);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 4:
            var showcityid = new CityController().FindById(1);
            if (showcityid != null)
                Console.WriteLine(showcityid);
            else
                Console.WriteLine("Nenhum registro encontrado!");
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
        case 11:
            if (new AddressController().Insert(address) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 12:
            var showaddresses = new AddressController().FindAll();
            if (showaddresses.Count > 0)
                showaddresses.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Ainda não implementado!");
            break;
        case 13:
            Address FindAddressid = new AddressController().FindById(1);
            if (FindAddressid != null)
                Console.WriteLine(FindAddressid);
            else 
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 14:
            if (new AddressController().Update(1, newAddress) > 0)
                Console.WriteLine("SUCESSO! Registro editado");
            else Console.WriteLine("ERRO! Registro não editado");
            break;
        case 15:
            if (new AddressController().Delete(1) > 0)
                Console.WriteLine("Registro deletado!");
            else
                Console.WriteLine("Registro não deletado!");
            break;
        case 21:
            if (new HotelController().Insert(hotel) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 22:
            var showhotels = new HotelController().FindAll();
            if (showhotels.Count > 0)
                showhotels.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 23:
            var showhotelname = new HotelController().FindByName("High Prices Hotel");
            if (showhotelname != null)
                Console.WriteLine(showhotelname);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 24:
            var showhotelid = new HotelController().FindById(1);
            if(showhotelid != null)
                Console.WriteLine(showhotelid);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 25:
            if (new HotelController().Update(1, newHotel) > 0)
                Console.WriteLine("SUCESSO! Registro editado");
            else Console.WriteLine("ERRO! Registro não editado");
            break;
        case 26:
            if (new HotelController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado!");
            else
                Console.WriteLine("ERRO! Registro não deletado!");
            break;
        case 31:
            if (new ClientController().Isert(client) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 32:
            var showclients = new ClientController().FindAll();
            if (showclients.Count > 0)
                showclients.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 33:
            var showclientname = new ClientController().FindByName("Nicolas Balduino");
            if (showclientname.Count > 0)
                showclientname.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Nenhum registro encontrado!");
                break;
        case 34:
            var showclientid = new ClientController().FindById(1);
            if (showclientid != null)
                Console.WriteLine(showclientid);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 35:
            if (new ClientController().Update(1, newClient) > 0)
                Console.WriteLine("SUCESSO! Registro atualizado");
            else
                Console.WriteLine("ERRO! Registro não atualizado");
            break;
        case 36:
            if (new ClientController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado");
            else
                Console.WriteLine("ERRO! Registro não deletado");
            break;
        case 41:
            if (new TicketController().Insert(ticket) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 42:
            var showtickets = new TicketController().FindAll();
            if (showtickets.Count > 0)
                showtickets.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 43:
            var showticketid = new TicketController().FindById(1);
            if (showticketid != null)
                Console.WriteLine(showticketid);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 44:
            if (new TicketController().Update(newTicket) > 0)
                Console.WriteLine("SUCESSO! Registro atualizado com sucesso");
            else
                Console.WriteLine("ERRO! Registro não atualizado");
            break;
        case 45:
            if (new TicketController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado com sucesso");
            else
                Console.WriteLine("ERRO! Registro não deletado");
            break;
        case 51:
            if (new PackageController().Insert(package) > 0)
                Console.WriteLine("SUCESSO! Registro inserido!");
            else
                Console.WriteLine("ERRO! Registro não inserido!");
            break;
        case 52:
            var shoepackages = new PackageController().FindAll();
            if (shoepackages.Count > 0)
                shoepackages.ForEach(Console.WriteLine);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 53:
            var showpackageid = new PackageController().FindById(1);
            if (showpackageid != null)
                Console.WriteLine(showpackageid);
            else
                Console.WriteLine("Nenhum registro encontrado!");
            break;
        case 54:
            if (new PackageController().Update(newPackage) > 0)
                Console.WriteLine("SUCESSO! Registro atualizado!");
            else
                Console.WriteLine("ERRO! Registro não atualizado!");
            break;
        case 55:
            if (new PackageController().Delete(1) > 0)
                Console.WriteLine("SUCESSO! Registro deletado");
            else
                Console.WriteLine("ERRO! Registro não deletado");
            break;
        default:
            op = 0;
            Console.WriteLine("Bye bye!");
            break;
    }
    Console.WriteLine("Pressione qualquer tecla para continuar");
    
    Console.ReadLine();
} while (op > 0 && op < 56);


