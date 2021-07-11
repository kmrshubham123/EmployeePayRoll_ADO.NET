create procedure  SpAddEmployeeDetail
(
@EmployeeName varchar(32),
@Salary float,
@StartDate date,
@Gender Varchar(32),
@PhoneNumber varchar(20),
@Department varchar(30),
@Address varchar(30),
@BasicPay float,
@Deduction float,
@TaxablePay float,
@IncomeTax float,
@NetPay float

)
 as
 begin
	INSERT INTO EmployeePayroll (EmployeeName,Salary,StartDate,Gender,PhoneNumber,Department,Address,BasicPay,Deduction,TaxablePay,IncomeTax,NetPay) 
VALUES (@EmployeeName,@Salary,@StartDate,@Gender,@PhoneNumber,@Department,@Address,
	@BasicPay,@Deduction,@TaxablePay,@IncomeTax,@NetPay)
 End