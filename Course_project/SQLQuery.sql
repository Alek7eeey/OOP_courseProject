use TaskWave;

create table userIdentify
(
	id int primary key identity(1,1),
	login varchar(150) not null,
	password varchar(200) not null,
	name varchar(200) not null,
	type varchar(100) not null,
	telegramURL varchar(300)
);

insert into userIdentify(login, password, name, type, telegramURL)
Values
('admin', 'admin', 'Aleksey', 'Руководитель', 'https://t.me/A1ek7eey');

select * from tasks;
select * from TeamTasks;
select * from projects;
select * from PrPhotos;
select * from userIdentify;
select * from readyTasks;
select * from sendTasks
select * from documentTasks
select * from notification

insert into tasks (name, description, dateOt, dateTo, ProjectId, isReady, isSend, nameOfCreator)
VALUES
()

insert into notification(SenderLogin,RecipientLogin,message,date )
Values
('admin', 'a', 'Ваша задача принята', '11-09-2023');

insert into readyTasks(name, description, dateComplete,TaskId,nameOfResponse)
Values
('Реализуйте лабораторную работу по ООП', 'Сделайте сериализацию', '14-05-2023', 1, 's')


delete from tasks;
delete from pHfrojects;
delete from readyTasks;
delete from sendTasks
delete from documentTasks