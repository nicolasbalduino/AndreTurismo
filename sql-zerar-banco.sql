delete from Package;
delete from Ticket;
delete from Hotel;
delete from Client;
delete from Address;
delete from City;

DBCC CHECKIDENT('Package', RESEED, 0)
DBCC CHECKIDENT('Ticket', RESEED, 0)
DBCC CHECKIDENT('Hotel', RESEED, 0)
DBCC CHECKIDENT('Client', RESEED, 0)
DBCC CHECKIDENT('Address', RESEED, 0)
DBCC CHECKIDENT('City', RESEED, 0)