use [AddressBook]

Create Procedure RetrieveDetails
@ID int

AS
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;
-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
SET NOCOUNT ON;

declare @result bit = 0;
Select * from AddressDetails where ID = @ID

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