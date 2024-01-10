DROP TABLE IF EXISTS "Skill";
DROP TABLE IF EXISTS "Certificate";
DROP TABLE IF EXISTS "Link";
DROP TABLE IF EXISTS "EducationItem";
DROP TABLE IF EXISTS "Education";
DROP TABLE IF EXISTS "WorkExperienceItem";
DROP TABLE IF EXISTS "WorkExperience";
DROP TABLE IF EXISTS "User";
DROP TABLE IF EXISTS "Customer";
DROP TABLE IF EXISTS "Address";
DROP TABLE IF EXISTS "State";
DROP TABLE IF EXISTS "Country";
DROP TABLE IF EXISTS "SubRegion";
DROP TABLE IF EXISTS "Region";

create table
  "Region" (
    "Id" bigint primary key generated always as identity,
    "Name" varchar(50) not null
  );

create table
  "SubRegion" (
    "Id" bigint primary key generated always as identity,
    "RegionId" bigint references "Region" ("Id") on delete cascade on update cascade,
    "Name" varchar(50) not null
  );

create table
  "Country" (
    "Id" bigint primary key generated always as identity,
    "RegionId" bigint null references "Region" ("Id"),
    "SubRegionId" bigint null references "SubRegion" ("Id") on delete cascade on update cascade,
    "Name" varchar(50) not null,
    "NativeName" varchar(100) null,
    "ISO3" varchar(3) not null,
    "ISO2" varchar(2) not null,
    "NumericCode" int not null,
    "PhoneCode" varchar(50) not null,
    "Capital" varchar(50) null,
    "Currency" varchar(50) not null,
    "CurrencyName" varchar(50) not null,
    "CurrencySymbol" varchar(50) not null,
    "Tld" varchar(50) not null,
    "Latitude" float null,
    "Longitude" float null,
    "Emoji" varchar(50)
  );

create table
  "State" (
    "Id" bigint primary key generated always as identity,
    "CountryId" bigint not null references "Country" ("Id") on delete cascade on update cascade,
    "StateCode" varchar(50) not null,
    "Name" varchar(100) not null,
    "Latitude" float null,
    "Longitude" float null
  );

create table
  "Address" (
    "Id" bigint primary key generated always as identity,
    "Address1" text not null,
    "Address2" text null,
    "City" text null,
    "PostalCode" text null,
    "StateId" bigint not null references "State" ("Id") on delete cascade on update cascade,
    "CountryId" bigint not null references "Country" ("Id")
  );

create table
  "User"(
    "Id" bigint primary key generated always as identity,
    "AddressId" bigint null references "Address" ("Id"),
    "Title" text not null,
    "FirstName" text not null,
    "LastName" text not null,
    "Email" text not null,
    "PhoneNumber" text null,
    "Description" text null
  );

create table
  "Customer" (
    "Id" bigint primary key generated always as identity,
    "AddressId" bigint null references "Address" ("Id"),
    "Company" text null,
    "FirstName" text not null,
    "LastName" text not null,
    "Email" text not null,
    "PhoneNumber" text null,
    "Password" text not null,
    "IsAdmin" bool not null default false
  );

create table
  "WorkExperience" (
    "Id" bigint primary key generated always as identity,
    "UserId" bigint not null references "User"("Id") on delete cascade on update cascade,
    "AddressId" bigint null references "Address" ("Id"),
    "Employer" text not null,
    "Title" text not null,
    "StartDate" DATE not null,
    "EndDate" DATE not null,
    "PayRate" decimal(18, 0) null
  );

create table
  "WorkExperienceItem" (
    "Id" bigint primary key generated always as identity,
    "WorkExperienceId" bigint not null references "WorkExperience" ("Id") on delete cascade on update cascade,
    "Description" text not null
  );

create table
  "Education" (
    "Id" bigint primary key generated always as identity,
    "UserId" bigint not null references "User"("Id") on delete cascade on update cascade,
    "AddressId" bigint null references "Address" ("Id"),
    "School" text not null,
    "StartDate" DATE not null,
    "EndDate" DATE not null,
    "Grade" text null
  );

create table
  "EducationItem" (
    "Id" bigint primary key generated always as identity,
    "EducationId" bigint not null references "Education" ("Id") on delete cascade on update cascade,
    "Name" text not null
  );

create table
  "Skill" (
    "Id" bigint primary key generated always as identity,
    "UserId" bigint not null references "User"("Id") on delete cascade on update cascade,
    "Type" text not null,
    "Name" text not null
  );

create table
  "Certificate" (
    "Id" bigint primary key generated always as identity,
    "UserId" bigint not null references "User"("Id") on delete cascade on update cascade,
    "Name" text not null,
    "CertificateId" text null,
    "URL" text null,
    "IssuedBy" text null,
    "IssueDate" DATE null
  );

create table
  "Link" (
    "Id" bigint primary key generated always as identity,
    "UserId" bigint not null references "User"("Id") on delete cascade on update cascade,
    "Name" text not null,
    "URL" text not null
  );

-- Policies
CREATE POLICY "Enable read access for all users" ON "public"."Region"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."SubRegion"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."Country"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."State"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."Address"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."User"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable all access for all users" ON "public"."Customer"
AS PERMISSIVE FOR ALL
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."WorkExperience"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."WorkExperienceItem"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."Education"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."EducationItem"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."Skill"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."Certificate"
AS PERMISSIVE FOR SELECT
TO public
USING (true);

CREATE POLICY "Enable read access for all users" ON "public"."Link"
AS PERMISSIVE FOR SELECT
TO public
USING (true);