Create database DealAndTripDB
Use DealAndTripDB
go
CREATE TABLE "Users"(
    "UserName" NVARCHAR(255) NOT NULL,
    "FirstName" NVARCHAR(255) NOT NULL,
    "LastName" NVARCHAR(255) NOT NULL,
    "Email" NVARCHAR(255) NOT NULL,
    "Password" INT NOT NULL,
    "PhoneNumber" INT NOT NULL,
    "Price" INT NOT NULL
);
ALTER TABLE
    "Users" ADD CONSTRAINT "users_username_primary" PRIMARY KEY("UserName");
CREATE UNIQUE INDEX "users_email_unique" ON
    "Users"("Email");
CREATE TABLE "VacationsResturant"(
    "id" INT NOT NULL,
    "VacationID" INT NOT NULL,
    "ResturantID" INT NOT NULL
);
ALTER TABLE
    "VacationsResturant" ADD CONSTRAINT "vacationsresturant_id_primary" PRIMARY KEY("id");
CREATE TABLE "TravelAgents"(
    "Rank" INT NOT NULL,
    "UserName" NVARCHAR(255) NOT NULL
);
CREATE UNIQUE INDEX "travelagents_username_unique" ON
    "TravelAgents"("UserName");
CREATE TABLE "Vacations"(
    "id" INT NOT NULL,
    "TravelAgentUserName" NVARCHAR(255) NOT NULL,
    "TypeID" INT NOT NULL,
    "Description" NVARCHAR(255) NOT NULL,
    "StartDate" DATE NOT NULL,
    "EndDate" DATE NOT NULL,
    "Rank" INT NOT NULL,
    "EnterFlightID" INT NOT NULL,
    "ExitFlightID" INT NOT NULL,
    "NightsNumber" INT NOT NULL
);
ALTER TABLE
    "Vacations" ADD CONSTRAINT "vacations_id_primary" PRIMARY KEY("id");
CREATE TABLE "VacationTypes"(
    "id" INT NOT NULL,
    "TypeName" NVARCHAR(255) NOT NULL,
    "TypeDescription" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "VacationTypes" ADD CONSTRAINT "vacationtypes_id_primary" PRIMARY KEY("id");
CREATE UNIQUE INDEX "vacationtypes_typename_unique" ON
    "VacationTypes"("TypeName");
CREATE TABLE "TravelSites"(
    "id" INT NOT NULL,
    "CityID" INT NOT NULL,
    "WebSiteLink" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "TravelSites" ADD CONSTRAINT "travelsites_id_primary" PRIMARY KEY("id");
CREATE TABLE "Countries"(
    "id" INT NOT NULL,
    "Name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Countries" ADD CONSTRAINT "countries_id_primary" PRIMARY KEY("id");
CREATE TABLE "Cities"(
    "id" INT NOT NULL,
    "CountryID" INT NOT NULL,
    "Name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Cities" ADD CONSTRAINT "cities_id_primary" PRIMARY KEY("id");
CREATE TABLE "Flights"(
    "id" INT NOT NULL,
    "Date" DATE NOT NULL,
    "TakeOffTime" DATETIME NOT NULL,
    "FlightTime" TIME NOT NULL,
    "LandingTime" DATETIME NOT NULL,
    "StartingPointCityID" INT NOT NULL,
    "DestinationCityID" INT NOT NULL
);
ALTER TABLE
    "Flights" ADD CONSTRAINT "flights_id_primary" PRIMARY KEY("id");
CREATE TABLE "Hotels"(
    "id" INT NOT NULL,
    "CityID" INT NOT NULL,
    "Name" NVARCHAR(255) NOT NULL,
    "Stars" INT NOT NULL,
    "WebSiteLink" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Hotels" ADD CONSTRAINT "hotels_id_primary" PRIMARY KEY("id");
CREATE TABLE "HotelsVacactions"(
    "id" INT NOT NULL,
    "HotelID" INT NOT NULL,
    "VacationID" INT NOT NULL,
    "NightsNumber" INT NOT NULL
);
ALTER TABLE
    "HotelsVacactions" ADD CONSTRAINT "hotelsvacactions_id_primary" PRIMARY KEY("id");
CREATE TABLE "VacationsTravelSites"(
    "id" INT NOT NULL,
    "VacationID" INT NOT NULL,
    "SiteID" INT NOT NULL
);
ALTER TABLE
    "VacationsTravelSites" ADD CONSTRAINT "vacationstravelsites_id_primary" PRIMARY KEY("id");
CREATE TABLE "Resturant"(
    "id" INT NOT NULL,
    "Name" NVARCHAR(255) NOT NULL,
    "CityID" INT NOT NULL,
    "WebSiteLink" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Resturant" ADD CONSTRAINT "resturant_id_primary" PRIMARY KEY("id");
CREATE TABLE "VacationsCities"(
    "id" INT NOT NULL,
    "VacationID" INT NOT NULL,
    "CityID" INT NOT NULL
);
ALTER TABLE
    "VacationsCities" ADD CONSTRAINT "vacationscities_id_primary" PRIMARY KEY("id");
ALTER TABLE
    "TravelAgents" ADD CONSTRAINT "travelagents_username_foreign" FOREIGN KEY("UserName") REFERENCES "Users"("UserName");
ALTER TABLE
    "VacationsResturant" ADD CONSTRAINT "vacationsresturant_vacationid_foreign" FOREIGN KEY("VacationID") REFERENCES "Vacations"("id");
ALTER TABLE
    "HotelsVacactions" ADD CONSTRAINT "hotelsvacactions_vacationid_foreign" FOREIGN KEY("VacationID") REFERENCES "Vacations"("id");
ALTER TABLE
    "VacationsTravelSites" ADD CONSTRAINT "vacationstravelsites_vacationid_foreign" FOREIGN KEY("VacationID") REFERENCES "Vacations"("id");
ALTER TABLE
    "VacationsCities" ADD CONSTRAINT "vacationscities_vacationid_foreign" FOREIGN KEY("VacationID") REFERENCES "Vacations"("id");
ALTER TABLE
    "Vacations" ADD CONSTRAINT "vacations_typeid_foreign" FOREIGN KEY("TypeID") REFERENCES "VacationTypes"("id");
ALTER TABLE
    "VacationsTravelSites" ADD CONSTRAINT "vacationstravelsites_siteid_foreign" FOREIGN KEY("SiteID") REFERENCES "TravelSites"("id");
ALTER TABLE
    "Cities" ADD CONSTRAINT "cities_countryid_foreign" FOREIGN KEY("CountryID") REFERENCES "Countries"("id");
ALTER TABLE
    "VacationsCities" ADD CONSTRAINT "vacationscities_cityid_foreign" FOREIGN KEY("CityID") REFERENCES "Cities"("id");
ALTER TABLE
    "Vacations" ADD CONSTRAINT "vacations_enterflightid_foreign" FOREIGN KEY("EnterFlightID") REFERENCES "Flights"("id");
ALTER TABLE
    "Vacations" ADD CONSTRAINT "vacations_exitflightid_foreign" FOREIGN KEY("ExitFlightID") REFERENCES "Flights"("id");
ALTER TABLE
    "HotelsVacactions" ADD CONSTRAINT "hotelsvacactions_hotelid_foreign" FOREIGN KEY("HotelID") REFERENCES "Hotels"("id");
ALTER TABLE
    "VacationsResturant" ADD CONSTRAINT "vacationsresturant_resturantid_foreign" FOREIGN KEY("ResturantID") REFERENCES "Resturant"("id");