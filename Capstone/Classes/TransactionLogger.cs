﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    class TransactionLogger
    {
        private string Filepath { get; }

        public TransactionLogger(string filepath)
        {
            Filepath = filepath;
        }

        public void RecordDeposit(decimal amount, decimal finalBalance)
        {
            

            try
            {
                using (StreamWriter sw = new StreamWriter(Filepath))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY {amount} {finalBalance}");
                }
            }
            catch
            {

            }


        }
        public decimal RecordPurchase(string slot, string product, decimal initialBal, decimal finalBalance)
        {




            
            try
            {
                using (StreamWriter sw = new StreamWriter(Filepath))
                {
                    sw.WriteLine($"{DateTime.Now} {product} {slot} {initialBal} {finalBalance}");
                }
            }
            catch
            {

            }
            return finalBalance;
        }
        public decimal RecordCompleteTransaction(decimal remainingBalance)
        {
           
            try
            {
                using (StreamWriter sw = new StreamWriter(Filepath))
                {
                    sw.WriteLine($"{DateTime.Now} GIVE CHANGE {remainingBalance} $0.00");
                }
            }
            catch
            {

            }
            return remainingBalance;


        }


    }
}