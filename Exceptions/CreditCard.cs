using System;
using System.Text.RegularExpressions;

namespace CreditCardClass
{
    internal class CreditCard
    {
        private string name, cardNumber;
        private int cvc;
        DateOnly endDate;

        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                        throw new Exception("Формат имени неверен");
                    else
                        name = value;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int Cvc
        {
            get { return cvc; }
            set {
                try
                {
                    if (value < 100 || value > 999)
                        throw new Exception("Формат CVC неверен");
                    else
                        cvc = value;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^[0-9]{16}$"))
                        throw new Exception("Формат номера карты неверен");
                    else
                        cardNumber = value;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public DateOnly EndDate
        {
            get { return endDate; }
            set
            {
                try
                {
                    if (value < DateOnly.FromDateTime(DateTime.Now) || (value.Year > 2028))
                        throw new Exception("Формат даты завершения работы карты неверен");
                    else
                        endDate = value;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public CreditCard(string name, int cvc,string cardNumber,DateOnly endDate)
        {
            Name = name;
            Cvc = cvc;
            CardNumber = cardNumber;
            EndDate = endDate;
        }
    }
}
