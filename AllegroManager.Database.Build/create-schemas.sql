USE AllegroManager

IF NOT EXISTS ( SELECT *  FROM sys.schemas WHERE name = 'allegro' )
BEGIN
    PRINT ' Creating the DB schema allegro';
    EXEC('CREATE SCHEMA allegro');
END;

IF NOT EXISTS ( SELECT *  FROM sys.schemas WHERE name = 'baselinker' )
BEGIN
    PRINT ' Creating the DB schema baselinker';
    EXEC('CREATE SCHEMA baselinker');
END;

IF NOT EXISTS ( SELECT *  FROM sys.schemas WHERE name = 'offers' )
BEGIN
    PRINT ' Creating the DB schema offers';
    EXEC('CREATE SCHEMA offers');
END;