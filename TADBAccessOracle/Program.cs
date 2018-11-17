using DomainModels.Entites;
using System.Data.Entity;

namespace TADBAccessOracle
{
    class Program
    {
        private static void Main(string[] args)
        {
            string connStr =
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=TAAnywhere)));Persist Security Info=True;User ID=SYS;Password=Binary007";

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TADBAccessOracleDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());

            TADBAccessOracleDbContext context = new TADBAccessOracleDbContext(connStr);

            TAPurpose te = new TAPurpose();
            te.TravelPurposePkId = 1;
            te.TravelPurpose = "Test1";
            te.TravelPurposeDescirption = "test";
            context.TAPurposes.Add(te);

            context.SaveChanges();
        }
    }
}
