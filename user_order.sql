-- создание бд и схемы (если требуется)
CREATE DATABASE test1
GO
USE test1
GO
CREATE SCHEMA suz
GO

-- пользователи
CREATE TABLE [suz].[users](
    [id_user] [int] IDENTITY(1,1) NOT NULL,
    [code] [varchar](83) NOT NULL,
    [name] [varchar](256) NOT NULL, -- ФИО пользователя
    [mail] [varchar](256) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC)
)
GO

-- заявки пользователей
CREATE TABLE [suz].[orders](
    [id_order] [int] IDENTITY(1,1) NOT NULL,
    [order_create_date] [datetime] NOT NULL, -- дата создания заявки
    [id_author] [int] NOT NULL,
    [order_description] [varchar](max) NOT NULL,
   PRIMARY KEY CLUSTERED ([id_order] ASC)
)
GO

ALTER TABLE [suz].[orders]  WITH CHECK ADD FOREIGN KEY([id_author])
REFERENCES [suz].[users] ([id_user])
GO

-- заполнение таблицы пользователей
INSERT INTO [suz].[users]
           ([code]
           ,[name]
           ,[mail])
     VALUES
     ('0с7', 'Ivanov I. I.',   'ivanov@test.com'),
     ('a02', 'Petrov P. P.',   'petrov@test.com'),
     ('aс3', 'Sidorov S. S.',  'sidorov@test.com')
GO

-- заполнение таблицы заявок
INSERT INTO [suz].[orders]
           ([order_create_date]
           ,[id_author]
           ,[order_description])
     VALUES
           ('2021-01-29T10:15:00'
           , 1
           , 'Покупка в кредит'),
           ('2020-07-30T19:20:15'
           , 2
           , 'Использована скидка'),
           ('2020-03-08T12:45:17'
           , 2
           , 'Использован сертификат'),
           ('2020-04-08T13:01:55'
           , 3
           , 'Юр. лицо'),
           ('2021-02-03T11:25:16'
           , 1
           , 'Покупка в рассрочку'),
           ('2020-04-03T19:57:33'
           , 1
           , 'Покупка в рассрочку')
GO

/*  запрос в результате выполнения которого выдаются следующие данные:
    - ФИО пользователя
    - количество заявок, созданных пользователем
    - дата создания пользователем самой первой заявки
    - дата создания пользователем последней заявки
*/

SELECT name, COUNT(name) AS Order_quantity,
       Min(order_create_date) AS First_order_date,
       Max(order_create_date) AS Last_order_date

  FROM [suz].[users]
  JOIN [suz].[orders]
  ON [suz].[users].id_user = [suz].[orders].id_author
  GROUP BY [suz].[users].name
GO

/* Query result:

name             Order_quantity    First_order_date           Last_order_date
Ivanov I. I.     3                 2020-04-03 19:57:33.000    2021-02-03 11:25:16.000
Petrov P. P.     2                 2020-03-08 12:45:17.000    2020-07-30 19:20:15.000
Sidorov S. S.    1                 2020-04-08 13:01:55.000    2020-04-08 13:01:55.000

*/

