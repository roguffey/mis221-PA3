using System;

namespace mis221_PA3
{
    class Program
    {
        static void Main(string[] args)
        {
            int userGil = 100;
            
            int userBet = 0;
            
            int userChoice = 0;
         
            AskUserChoice(userChoice);
         
            userChoice = int.Parse(Console.ReadLine());
         
            while(userChoice != 4)
            {
                Choice(userChoice, userGil, ref userBet);
                
                if(userBet >= 300 || userBet <= 0)
                {
                    userChoice = '4';
                    return;
                
                }
                else
                {
                    AskUserChoice(userChoice);
            
                    userChoice = int.Parse(Console.ReadLine());
                }
            }
            return;
        }

        static void AskUserChoice(int userChoice)
        {
            Console.WriteLine("Please Enter:\n1. Play Pig\n2. Play Blackjack\n3. See Current Scoreboard\n4. Exit"); 
        }

        static void GiltoBet(int gilBet)
        {
            Console.WriteLine("How much gil would you like to bet?");
        }

        static void Choice(int userChoice, int userGil, ref int userBet)
        {
            switch(userChoice)
            {
                case 1:
            
                    PlayPig(userGil, ref userBet);

                    break;
                case 2:
            
                    PlayBlackjack(userGil, ref userBet);
            
                    break;
                case 3:
            
                    GilCount(userGil, ref userBet);
            
                    break;
                
            }
        }

        static void PlayPig(int userGil, ref int userBet)
        {
            int gilBet = 0;
            int userPoints = 0;
            int compPoints = 0;

            GiltoBet(gilBet);
            
            gilBet = int.Parse(Console.ReadLine());
            
            GetRollHold();
            
            string userPlay = Console.ReadLine();
            
            while(userPoints < 100)
            {
                userPoints += UserPig(userPlay);
                
                Console.WriteLine("User Points: "+ userPoints);
                
                Console.WriteLine("Computer's Turn");
                
                compPoints += ComputerPig();
                
                Console.WriteLine("Computer points: "+compPoints); 
            }
            if(userPoints >= 100)
            {
                Console.WriteLine("You Won!");
                
                userBet += gilBet;
                
                GilCount(userGil, ref userBet);

            }
            else
            {
                Console.WriteLine("Sorry you Lost");
                
                userBet -= gilBet;
                
                GilCount(userGil, ref userBet);

            }
            
            

        }

        static int UserPig(string userPlay)
        {
            int userPoints = 0;
            
            Random randomNumber= new Random();
            
            int randomNum = randomNumber.Next(6);
            
            randomNum = randomNum + 1;
            
            while(userPlay != "hold")
            {
                if(randomNum == 1)
                {
                    Console.WriteLine("PIG!");
                 
                    ComputerPig();
                
                    return userPoints = 0;
                }
                else
                {
                    Console.WriteLine("You rolled a "+randomNum);
                
                    userPoints += randomNum;
                }
                GetRollHold();
                
                userPlay = Console.ReadLine();
                
                randomNum = randomNumber.Next(6);
                
                randomNum = randomNum + 1;
            }
            return userPoints;
        }
        
        static int ComputerPig()
        {
            int compPoints = 0;
            
            Random randomNumber= new Random();
            int randomNum = randomNumber.Next(6);
            randomNum = randomNum + 1;
           
            while (compPoints > 20)
            { 
                while(randomNum != 1)
                {
                    
                    compPoints += randomNum;
                
                 if(randomNum == 1)
                {
                    
                    return compPoints = 0;
                }
                randomNum = randomNumber.Next(6);
                
                randomNum = randomNum + 1;
                
                }
            }
            
            return compPoints;
        }

        static void GilCount(int userGil, ref int userBet)
        {
            userGil += userBet;
         
            Console.WriteLine("User Gil: " +userGil);
         
            if(userGil >= 300)
            {
                Console.WriteLine("You reached 300 Gil, You Win!");
                
                userBet = userGil;

                return;
            }
            else if(userGil == 0)
            {
                Console.WriteLine("You have no more Gil, You lost");

                userBet = userGil;
                
                return;
            }
            else if(userGil < 0)
            {
                Console.WriteLine("Uh Oh, you're in trouble now! You lost");
                
                userBet = userGil;

                return;
            }

            

        }

        static void GetRollHold()
        {
            Console.WriteLine("Enter roll or hold");
        }

        static int PlayBlackjack(int userGil, ref int userBet)
        {
            int userTotal = 0;
            int compTotal = 0;
            int gilBet = 0;

            GiltoBet(gilBet);
            gilBet = int.Parse(Console.ReadLine());

            Random randomNumber= new Random();
            int randomNum = randomNumber.Next(10);
            int firstRoll = randomNum;
            randomNum = randomNumber.Next(10);
            int secondRoll = randomNum;

            if(firstRoll == 0 && secondRoll == 0)
            {
                userTotal = 20;
            }
            else if(firstRoll == 0)
            {
                userTotal = 10 + secondRoll;
            }
            else if(secondRoll == 10)
            {
                userTotal = 10 + firstRoll;
            }
            else
            {
                userTotal = firstRoll + secondRoll;
            }

            Console.WriteLine("User Total is "+ userTotal);

            userTotal += RollAgain(userTotal);

            Console.WriteLine("User Total is "+ userTotal);

            if(userTotal == 21)
            {
                Console.WriteLine("Blackjack! You won!");
                
                userBet += gilBet;
                
                GilCount(userGil, ref userBet);
                
                return userGil;
            }
            else if(userTotal > 21)
            {
                Console.WriteLine("You Busted! You lose");

                userBet -= gilBet;

                GilCount(userGil, ref userBet); 
                
                return userGil;
            }

            compTotal = CompTurn();

            Console.WriteLine("Computer Total is "+ compTotal);

            if(userTotal > 21)
            {
                Console.WriteLine("You Bust! Computer win");
                
                userBet -= gilBet;  

                GilCount(userGil, ref userBet);             
            }
            else if(compTotal > 21)
            {
                Console.WriteLine("Computer Bust! You Win!");

                userBet += gilBet;
                
                GilCount(userGil, ref userBet);
            }
            else if (userTotal > compTotal)
            {
                Console.WriteLine("You won!");

                userBet += gilBet;
                
                GilCount(userGil, ref userBet);
            }
            else if( userTotal == compTotal)
            {
                Console.WriteLine("Tie!");

                GilCount(userGil, ref userBet);
            }
            else
            {
                Console.WriteLine("You lost");

                userBet -= gilBet;

                GilCount(userGil, ref userBet);
            }
            return userGil;
        }

        static int RollAgain(int userTotal)
        {
            int rollTotal = 0;

            Console.WriteLine("Would you like to make another roll?");

            string userChoice = Console.ReadLine();

            while(userChoice != "no")
            {
                Random randomNumber= new Random();

                int randomNum = randomNumber.Next(10);
                
                Console.WriteLine("You rolled a "+ randomNum);

                if (randomNum == 0)
                {
                    rollTotal += 10;
                }
                else
                {
                    rollTotal += randomNum;
                }

                int temp = userTotal + rollTotal;

                if(temp >= 21)
                {
                    return rollTotal;
                }

                Console.WriteLine("User total is: "+ (userTotal+rollTotal));

                Console.WriteLine("Would you like to make another roll?");
                
                userChoice = Console.ReadLine();
            }
            return rollTotal;
        }

        static int CompTurn()
        {
            int rollTotal = 0;
            
            while(rollTotal < 17)
            {
                Random randomNumber= new Random();
            
                int randomNum = randomNumber.Next(10);
                
                if (randomNum == 0)
                {
                    rollTotal += 10;
                }
                else
                {
                    rollTotal += randomNum;
                }
            }
            return rollTotal;
        }
    }
}
