using System;
using System.IO;
using Xunit;
using DBBot;
using Microsoft.Data.Sqlite;

namespace DBBot.tests
{
    public class DBUnderTest
    {
        [Fact]
        public void DBTC01() //Adding a Driver - Positive Scenario
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted   = 0;
                int nRowsDeleted    = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding Driver to Person table
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                Assert.True(1==nRowsInserted);             
            }
        }

        [Fact]
        public void DBTC02() //Adding a Driver - Negative Scenario - Duplicated
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding a Driver - Duplicated 
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                      VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                    commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                    commandInsert.Parameters.AddWithValue("$password"    , password);
                    commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                    commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                    commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                    commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC03() //Adding a new Vehicle - Positive Scenario
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted   = 0;
                int nRowsDeleted    = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding a Vehicle 
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                Assert.True(1==nRowsInserted);             
            }
        }

        [Fact]
        public void DBTC04() //Adding a Vehicle - Negative Scenario - Duplicated
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding a Vehicle 
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //Adding the same Vehicle - Again 
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                      VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                    commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                    commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                    commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC05() //Adding an Orders - Positive Scenario
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted   = 0;
                int nRowsDeleted    = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding a Orders 
                int    orderNumber  = 1; 
                int    qtyProducts  = 3;
                string oDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                commandInsert.CommandText =
                @"INSERT INTO Orders(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                Assert.True(1==nRowsInserted);             
            }
        }

        [Fact]
        public void DBTC06() //Adding an Orders - Negative Scenario - Duplicated
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted     = 0;
                int nRowsDeleted      = 0;
                int nRowsNotInserted  = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding an Orders 
                int    orderNumber  = 1; 
                int    qtyProducts  = 3;
                string oDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                commandInsert.CommandText =
                @"INSERT INTO Orders(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //Adding an Orders 
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Orders(OrderNumber, QtyProducts, DateRegist)
                      VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                    commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                    commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                    commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC07() //Adding a Delivery - Positive Scenario
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted   = 0;
                int nRowsDeleted    = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Persont table
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding Driver to Person table
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Vehicle table
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Vehicle 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Orders Table
                int    orderNumber  = 1; 
                int    qtyProducts  = 3;
                string oDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Orders 
                commandInsert.CommandText =
                @"INSERT INTO Orders(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Delivery table
                string person_PhoneNumber   = "4372154699"; 
                string vehicle_LicensePlate = "A1A1A1"; 
                int    order_OrderNumber    = 1; 
                string dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Delivery - Positive scenario 
                commandInsert.CommandText =
                @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                  VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                Assert.True(1==nRowsInserted);             
            }
        }

        [Fact]
        public void DBTC08() //Adding a Delivery - Negative Scenario - Phone Number doesn't exist
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Vehicle table
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Vehicle 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Orders Table
                int    orderNumber  = 1; 
                int    qtyProducts  = 3;
                string oDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Orders 
                commandInsert.CommandText =
                @"INSERT INTO Orders(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Delivery table
                string person_PhoneNumber   = "4372154699"; 
                string vehicle_LicensePlate = "A1A1A1"; 
                int    order_OrderNumber    = 1; 
                string dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding the same Delivery - again
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                      VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                    commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                    commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                    commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                    commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC09() //Adding a Delivery - Negative Scenario - License Plate doesn't exist
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Persont table
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding Driver to Person table
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Orders Table
                int    orderNumber  = 1; 
                int    qtyProducts  = 3;
                string oDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Deleting Orders table
                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Adding a Orders 
                commandInsert.CommandText =
                @"INSERT INTO Orders(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Delivery table
                string person_PhoneNumber   = "4372154699"; 
                string vehicle_LicensePlate = "A1A1A1"; 
                int    order_OrderNumber    = 1; 
                string dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Delivery
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                      VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                    commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                    commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                    commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                    commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC10() //Adding a Delivery - Negative Scenario - Orders Number doesn't exist
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Orders";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Persont table
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding Driver to Person table
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Vehicle table
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Vehicle 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Delivery table
                string person_PhoneNumber   = "4372154699"; 
                string vehicle_LicensePlate = "A1A1A1"; 
                int    order_OrderNumber    = 1; 
                string dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Delivery
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                      VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                    commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                    commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                    commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                    commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC11() //Adding an Odometer - Positive Scenario
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted   = 0;
                int nRowsDeleted    = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Person table
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding Driver to Person table
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Vehicle table
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Vehicle 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Odometer table
                string dateReceived          = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string timeReceived          = DateTime.UtcNow.ToString("hh:mm");
                int    valueReceived         = 12345;
                string oVehicle_LicensePlate = "A1A1A1"; 
                string oPerson_PhoneNumber   = "4372154699"; 
                
                //Adding Odometer 
                commandInsert.CommandText =
                @"INSERT INTO Odometer(DateReceived, TimeReceived, ValueReceived, Vehicle_LicensePlate, Person_PhoneNumber)
                  VALUES($dateReceived, $timeReceived, $valueReceived, $oVehicle_LicensePlate, $oPerson_PhoneNumber)";
                commandInsert.Parameters.AddWithValue("$dateReceived"          , dateReceived);
                commandInsert.Parameters.AddWithValue("$timeReceived"          , timeReceived);
                commandInsert.Parameters.AddWithValue("$valueReceived"         , valueReceived);
                commandInsert.Parameters.AddWithValue("$oVehicle_LicensePlate" , oVehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$oPerson_PhoneNumber"   , oPerson_PhoneNumber);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                Assert.True(1==nRowsInserted);             
            }
        }

        [Fact]
        public void DBTC12() //Adding an Odometer - Negative Scenario - Phone Number doesn't exist
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Vehicle table
                string licensePlate = "A1A1A1"; 
                string typeVehicle  = "Van";
                string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding a Vehicle 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Odometer table
                string dateReceived          = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string timeReceived          = DateTime.UtcNow.ToString("hh:mm");
                int    valueReceived         = 12345;
                string oVehicle_LicensePlate = "A1A1A1"; 
                string oPerson_PhoneNumber   = "4372154699"; 
                
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Odometer(DateReceived, TimeReceived, ValueReceived, Vehicle_LicensePlate, Person_PhoneNumber)
                      VALUES($dateReceived, $timeReceived, $valueReceived, $oVehicle_LicensePlate, $oPerson_PhoneNumber)";
                    commandInsert.Parameters.AddWithValue("$dateReceived"          , dateReceived);
                    commandInsert.Parameters.AddWithValue("$timeReceived"          , timeReceived);
                    commandInsert.Parameters.AddWithValue("$valueReceived"         , valueReceived);
                    commandInsert.Parameters.AddWithValue("$oVehicle_LicensePlate" , oVehicle_LicensePlate);
                    commandInsert.Parameters.AddWithValue("$oPerson_PhoneNumber"   , oPerson_PhoneNumber);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }

        [Fact]
        public void DBTC13() //Adding an Odometer - Negative Scenario - License Plate doesn't exist
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                int nRowsInserted    = 0;
                int nRowsDeleted     = 0;
                int nRowsNotInserted = 0;

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting All
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                commandDelete.CommandText = @"DELETE FROM Person";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //For Persont table
                string phoneNumber  = "4372154699";
                int    password     = 1234;
                string hierarchy    = "Driver"; 
                string firstName    = "Heloisa"; 
                string lastName     = "Prog8060";
                string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

                //Adding Driver to Person table
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                //For Odometer table
                string dateReceived          = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string timeReceived          = DateTime.UtcNow.ToString("hh:mm");
                int    valueReceived         = 12345;
                string oVehicle_LicensePlate = "A1A1A1"; 
                string oPerson_PhoneNumber   = "4372154699"; 
                
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Odometer(DateReceived, TimeReceived, ValueReceived, Vehicle_LicensePlate, Person_PhoneNumber)
                      VALUES($dateReceived, $timeReceived, $valueReceived, $oVehicle_LicensePlate, $oPerson_PhoneNumber)";
                    commandInsert.Parameters.AddWithValue("$dateReceived"          , dateReceived);
                    commandInsert.Parameters.AddWithValue("$timeReceived"          , timeReceived);
                    commandInsert.Parameters.AddWithValue("$valueReceived"         , valueReceived);
                    commandInsert.Parameters.AddWithValue("$oVehicle_LicensePlate" , oVehicle_LicensePlate);
                    commandInsert.Parameters.AddWithValue("$oPerson_PhoneNumber"   , oPerson_PhoneNumber);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    nRowsNotInserted = 1;
                }

                Assert.True(1==nRowsInserted && 1==nRowsNotInserted);             
            }
        }
    }
}
