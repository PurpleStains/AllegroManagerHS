#!/bin/bash

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to be fully up and running
sleep 20

# Run the SQL scripts
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -i /sql-scripts/init.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -i /sql-scripts/create-schemas.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/allegro/InboxMessages.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/allegro/InternalCommands.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/allegro/OutboxMessages.sql 
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/allegro/AllegroOffers.sql 
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/baselinker/InboxMessages.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/baselinker/InternalCommands.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/baselinker/OutboxMessages.sql
            /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P HomeyStyle!23_45 -C -d AllegroManager -i /sql-scripts/baselinker/Products.sql
        

# Keep the container running with SQL Server in the foreground
wait
