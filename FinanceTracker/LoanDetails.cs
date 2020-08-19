using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceTracker
{
    public class LoanDetails
    {
        public string name;
        public int amount;
        public int interestRate;
        public DateTime issueDate;
        public DateTime updateDate;
        public string type;

        public void update(LoanDetails loan)
        {
            if(loan.type == "0")    // w skali rocznej
            {
                while(loan.updateDate.Year < DateTime.Now.Year)
                {
                    loan.amount = loan.amount * (int)((double)(1 + loan.interestRate / 100000));
                    DateTime newDate = Convert.ToDateTime("01.01." + (loan.updateDate.Year + 1) + " 00:00:01");
                    loan.updateDate = newDate; 
                }
            }
            if (loan.type == "1")   // w skali kwartalnej
            {
                while (loan.updateDate.Year != DateTime.Now.Year || (loan.updateDate.Month - 1) / 3 != (DateTime.Now.Month - 1) / 3)
                {
                    int counter = (loan.updateDate.Month - 1) / 3;
                    if(counter != 3)
                    {
                        loan.amount = loan.amount * (int)((double)(1 + loan.interestRate / 100000.0));
                        DateTime newDate = Convert.ToDateTime("01." + (counter * 3 + 1) + loan.updateDate.Year + " 00:00:01");
                        loan.updateDate = newDate;
                    }
                    else
                    {
                        loan.amount = loan.amount * (int)((double)(1 + loan.interestRate / 100000.0));
                        DateTime newDate = Convert.ToDateTime("01.01." + (loan.updateDate.Year + 1) + " 00:00:01");
                        loan.updateDate = newDate;
                    }
                }
            }
            else if(loan.type == "2")   // w skali miesięcznej
            {
                while (loan.updateDate.Year != DateTime.Now.Year || loan.updateDate.Month != DateTime.Now.Month)
                {

                    if (loan.updateDate.Month != 12)
                    {
                        loan.amount = loan.amount * (int)((double)(1 + loan.interestRate / 100000.0));
                        DateTime newDate = Convert.ToDateTime("01." + (loan.updateDate.Month + 1) + loan.updateDate.Year + " 00:00:01");
                        loan.updateDate = newDate;
                    }
                    else
                    {
                        loan.amount = loan.amount * (int)((double)(1 + loan.interestRate / 100000.0));
                        DateTime newDate = Convert.ToDateTime("01.01." + (loan.updateDate.Year + 1) + " 00:00:01");
                        loan.updateDate = newDate;
                    }
                }
            }
            else if(loan.type == "3")   // w skali dziennej
            {
                while (loan.updateDate.Year != DateTime.Now.Year || loan.updateDate.Month != DateTime.Now.Month || loan.updateDate.Day != DateTime.Now.Day)
                {
                    if(loan.updateDate.Month == 12)
                    {
                        if(loan.updateDate.Day != 31)
                        {
                            loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                            DateTime newDate = Convert.ToDateTime((loan.updateDate.Day + 1) + "." + loan.updateDate.Month + "." + loan.updateDate.Year + " 00:00:01");
                            loan.updateDate = newDate;
                        }
                        else
                        {
                            loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                            DateTime newDate = Convert.ToDateTime("01.01." + (loan.updateDate.Year + 1) + " 00:00:01");
                            loan.updateDate = newDate;
                        }
                    }

                    else if(loan.updateDate.Month == 4 || loan.updateDate.Month == 6 || loan.updateDate.Month == 9 || loan.updateDate.Month == 11)
                    {
                        if (loan.updateDate.Day != 30)
                        {
                            loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                            DateTime newDate = Convert.ToDateTime((loan.updateDate.Day + 1) + "." + loan.updateDate.Month + "." + loan.updateDate.Year + " 00:00:01");
                            loan.updateDate = newDate;
                        }
                        else
                        {
                            loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                            DateTime newDate = Convert.ToDateTime("01." + (loan.updateDate.Month + 1) + "." + loan.updateDate.Year + " 00:00:01");
                            loan.updateDate = newDate;
                        }
                    }
                    else if(loan.updateDate.Month == 2)
                    {
                        if (DateTime.IsLeapYear(loan.updateDate.Year))
                        {
                            if (loan.updateDate.Day != 29)
                            {
                                loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                                DateTime newDate = Convert.ToDateTime((loan.updateDate.Day + 1) + "." + loan.updateDate.Month + "." + loan.updateDate.Year + " 00:00:01");
                                loan.updateDate = newDate;
                            }
                            else
                            {
                                loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                                DateTime newDate = Convert.ToDateTime("01." + (loan.updateDate.Month + 1) + "." + loan.updateDate.Year + " 00:00:01");
                                loan.updateDate = newDate;
                            }
                        }
                        else
                        {
                            if (loan.updateDate.Day != 28)
                            {
                                loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                                DateTime newDate = Convert.ToDateTime((loan.updateDate.Day + 1) + "." + loan.updateDate.Month + "." + loan.updateDate.Year + " 00:00:01");
                                loan.updateDate = newDate;
                            }
                            else
                            {
                                loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                                DateTime newDate = Convert.ToDateTime("01." + (loan.updateDate.Month + 1) + "." + loan.updateDate.Year + " 00:00:01");
                                loan.updateDate = newDate;
                            }
                        }
                    }
                    else
                    {
                        if(loan.updateDate.Day != 31)
                        {
                            loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                            DateTime newDate = Convert.ToDateTime((loan.updateDate.Day + 1) + "." + loan.updateDate.Month + "." + loan.updateDate.Year + " 00:00:01");
                            loan.updateDate = newDate;
                        }
                        else
                        {
                            loan.amount = (int)(loan.amount * (double)(1 + loan.interestRate / 100000.0));
                            DateTime newDate = Convert.ToDateTime("01." + (loan.updateDate.Month + 1) + "." + loan.updateDate.Year + " 00:00:01");
                            loan.updateDate = newDate;
                        }
                    }
                }
            }
            
            
        }


    }
}
