use [AddressBook]

Create Procedure Add_Details
@FirstName varchar(20),
@LastName varchar(20),
@Address varchar(100),
@City varchar (20),
@State varchar (20),
@Zip bigint,
@PhoneNumber bigint,
@Email varchar (50)

AS
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
SET NOCOUNT ON;
declare @new_identity int = 0
declare @result bit = 0;
Insert into AddressDetails (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values (@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email) 
select @new_identity = @@IDENTITY
Commit Transaction
Set @result = 1;
return @result;
END TRY
BEGIN CATCH
if(XACT_STATE()) = -1
 Begin
  Print
  'transaction is uncommitable' + 'rolling back transaction'
 ROLLBACK TRANSACTION;
 RETURN @result;
 End;
else if (XACT_STATE()) = 1
Begin
Print
   'transaction is commitable' + 'commiting back transaction'
   COMMIT TRANSACTION
   set @result = 1;
   return @result;
   END
END Catch
END

select * from AddressDetails
