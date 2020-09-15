using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915
{
    public class BankAccount
    {
        private static double interest = 0.2; //이자율
        private string name;           //예금주명
        private string accNum;         //계좌번호
        private int balance;       //잔액

        #region property
        public string AccNum
        {
            get { return accNum; }
            set { accNum = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Balance //읽기전용속성
        {
            get { return balance; }
        }
        #endregion

        #region constructor
        public BankAccount() //기본 생성자
        {
            balance = 10;
        }
        public BankAccount(string accnum, string accname)
        {
            accNum = accnum;
            Name = accname;
        }
        #endregion

        #region method
        public string OutputMoney(int amount) //출금
        {
            if (balance < amount)
            {
                string msg = "잔액이 부족합니다";
                return msg;
            }
            balance = balance - amount;
            return "";
        }
        /*
        public void OutputMoney(int amount) //출금
        {
            if (balance < amount)
            {
                string msg = "잔액이 부족합니다";
                return;
            }
            balance = balance - amount;
            
        }
        */
        public void InputMoney(int amount) //예금
        {
            balance = balance + amount + (int)(amount * interest);
        }
        
        public void PrintAccInfo() //계좌정보 출력
        {
            Console.WriteLine($"계좌번호{accNum} / 예금주명: {accNum} / 잔액: {this.Balance} / 이자율:{interest}");
        }
        public void SetInterest(double interest) //이자율 변경
        {
            BankAccount.interest = interest;
            balance += 10;
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc0 = new BankAccount();
            acc0.AccNum = "111-11111";
            acc0.Name = "홍길동";
            acc0.PrintAccInfo();
            acc0.SetInterest(10);



            BankAccount acc1 = new BankAccount("222-22222", "류현진");
            acc1.AccNum = "222-22222";
            acc1.Name = "손흥민";

            acc0.InputMoney(500);

            Console.WriteLine("예금주명: " + acc1.Name+", 잔액:" + acc1.Balance);
            string errMsg = acc0.OutputMoney(100);
            if (errMsg.Length > 0)
                Console.WriteLine(errMsg);
            else
                Console.WriteLine(acc0.Balance);

            
        }
    }
}
