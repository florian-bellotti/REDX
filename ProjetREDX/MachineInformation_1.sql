CREATE TABLE [dbo].[MachineInformation]
(
	[Id_information] INT NOT NULL PRIMARY KEY, 
    [date] DATETIME NULL, 
    [RAM] INT NULL, 
    [CPU] INT NULL, 
    [disque] INT NULL, 
    [Id_machine] INT NOT NULL
)
