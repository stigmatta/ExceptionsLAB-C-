// See https://aka.ms/new-console-template for more information
using CreditCardClass;
using ExpressionClass;

DateOnly date = new DateOnly(2027, 10, 17);
CreditCard creditCard = new CreditCard("ds",231,"2312312312315231",date);


Expression expr = new Expression("3*4*8");
Console.WriteLine(expr.Evaluate());