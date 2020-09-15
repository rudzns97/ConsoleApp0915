using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;

namespace ConsoleApp0915
{

    class AccountManager
    {
        BankAccount account;
        
        public void PrintMenu() // 계좌관리프로그램 메뉴
        {
            
            Console.WriteLine("\n---Menu---------");
            Console.WriteLine("1. 계좌 개설");
            Console.WriteLine("2. 입금");
            Console.WriteLine("3. 출금");
            Console.WriteLine("4. 잔액 조회");
            Console.WriteLine("5. 프로그램 종료");
            Console.Write("선택: ");
        }
        public void MakeAccount()//1. 계좌 개설
        {
            Console.Write("계좌번호:");
            string accNum = Console.ReadLine();
            Console.Write("예금주명");
            string accName = Console.ReadLine();

            account = new BankAccount(accNum, accName); 
            //account.AccNum = accNum;
            }
        private bool CheckAccount() 
        {
            if (account == null)
            {
                Console.WriteLine("계좌개설을 먼저 해주십시오");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Deposit() //2. 입금
        {
            if (CheckAccount() == false) return;
            
            Console.Write("입금하실 금액은?:");
            int money = int.Parse(Console.ReadLine());
            account.InputMoney(money);
            int d = account.Balance;
            //Console.Write("잔액:"+d);

        }
        public void Out() //3. 출금
        {
            if (account == null)
            {
                Console.WriteLine("계좌개설을 먼저 해주십시오");
                return;
            }
            Console.Write("출금하실 금액은?:");
            int money = int.Parse(Console.ReadLine());
            account.OutputMoney(money);
            int d = account.Balance;
            //Console.Write("잔액:" + d);
        }
        public void In() //4. 잔액 조회
        {
            if (account == null)
            {
                Console.WriteLine("계좌개설을 먼저 해주십시오");
                return;
            }
            int d = account.Balance;
            Console.Write("잔액:" + d);
        }

    }
    class AccountProgram
    {
        static void Main()
        {

            AccountManager manager = new AccountManager();
            //Console.WriteLine(manager.ToString());

            while (true)
            {
                manager.PrintMenu();
                //Console.WriteLine(manager.ToString());
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        manager.MakeAccount(); break;
                    case 2:
                        manager.Deposit(); break;
                    case 3:
                        manager.Out(); break;
                        
                    case 4:
                        manager.In(); break;
                    case 5: return;
                    default:
                        Console.WriteLine("다시 선택하세요"); break;
                }
            }
        }
    }
}
