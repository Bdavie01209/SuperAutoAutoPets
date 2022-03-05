using GameSimulation.PetsFolder;
using GameSimulation.FoodFolder;
using GameSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace GameSimulation
{
    public class Environment
    {
        public Pets[] Team;
        public Pets[] Petshop;
        public Food[] foodshop;
        public int Turn;
        public int gold;
        public int wins;
        public int Cans { get => cans * 2; set => cans = value; }
        private int cans;
        public int Lives;
        bool selfcontrol;
        public bool render;
        public bool TurnStartFlag;
        private Random rn;

        private TakeActionDelegate SendToGui;
        private ReceiveWinLossDelegate WinLose;
        private RerollDelegate GuiReroll;




        public Environment(bool SC, bool Render)
        {
            Team = new Pets[5];
            Petshop = new Pets[5];
            foodshop = new Food[2];
            Turn = 0;
            gold = 11;
            Cans = 0;
            Lives = 10;
            selfcontrol = SC;
            rn = new Random();
            render = Render;
            TurnStartFlag = false;
        }

        public Pets[] copyTeam()
        {
            Pets[] returnValue = new Pets[5];
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    returnValue[i] = Team[i].Clone();
                }
            }
            return returnValue;
        }


        public void Reset()
        {
            Team = new Pets[5];
            Petshop = new Pets[5];
            Turn = 0;
            gold = 10;
            Cans = 0;
            Lives = 10;
            wins = 0;
            Turnstart();
        }

        public void Turnstart()
        {
            gold = 11;
            Turn += 1;
            Reroll(true);
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    Team[i].OnTurnStart(this, i);
                }
            }
        }

        /// <summary>
        /// rerolls the shop
        /// </summary>
        /// <param name="TS">this is for !selfcontrol states in which it sends a message to the gui stands for the first roll of the round</param>
        public void Reroll(bool TS)
        {
            gold--;
            if (selfcontrol)
            {
                if (Turn >= 11)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Petshop[i] = RandomPet(rn.Next(0, 58));
                        if (i == 0 || i == 1)
                        {
                            foodshop[i] = RandomFood(rn.Next(0, 15));
                        }
                    }
                }
                else if (Turn >= 9)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Petshop[i] = RandomPet(rn.Next(0, 49));
                        if (i == 0 || i == 1)
                        {
                            foodshop[i] = RandomFood(rn.Next(0, 12));
                        }
                    }
                }
                else if (Turn >= 7)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Petshop[i] = RandomPet(rn.Next(0, 41));
                        if (i == 0 || i == 1)
                        {
                            foodshop[i] = RandomFood(rn.Next(0, 9));
                        }
                    }
                }
                else if (Turn >= 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Petshop[i] = RandomPet(rn.Next(0, 30));
                        if (i == 0 || i == 1)
                        {
                            foodshop[i] = RandomFood(rn.Next(0, 7));
                        }
                    }
                }
                else if (Turn >= 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Petshop[i] = RandomPet(rn.Next(0, 19));
                        if (i == 0 || i == 1)
                        {
                            foodshop[i] = RandomFood(rn.Next(0, 5));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Petshop[i] = RandomPet(rn.Next(0, 9));
                        if (i == 1)
                        {
                            foodshop[i] = RandomFood(rn.Next(0, 2));
                        }
                    }
                }
            }
            else
            {
               PetStringsToShop(GuiReroll(TS));
            }
        }

        public double Turnend()
        {
            TurnStartFlag = true;
            double WinLossDraw;
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    Team[i].OnTurnEnd(this);
                }
            }
            if (selfcontrol)
            {
                WinLossDraw = TeamFight(null);
            }
            else
            {
                WinLossDraw = WinLose();
            }
            Turnstart();
            return WinLossDraw;
        }
        /// <summary>
        /// buys the item in posShop on the spot posToBuy
        /// </summary>
        /// <param name="posShop"></param>
        /// <param name="postoBuy"></param>
        /// <returns>1 if successfull -1 if failed from invalid purchase -2 if out of money</returns>
        public int Buy(int posShop, int postoBuy)
        {
            if (gold < 3)//no gold
            {
                return -2;
            }
            if (posShop > 4)//food shop related purchase
            {
                if(foodshop[posShop - 5] == null) //shop item doesn't exist
                {
                    return -1;
                }
                if (foodshop[posShop - 5].Name != foodNames.SaladBowl || foodshop[posShop - 5].Name != foodNames.Sushi || foodshop[posShop - 5].Name != foodNames.Pizza || foodshop[posShop -5].Name != foodNames.CannedFood) //all aoe foods don't need target
                {
                    if (Team[postoBuy] == null)
                    {
                        return -1; //no one in that spot pass
                    }
                    else
                    {
                        gold -= 3;
                        Team[postoBuy].OnSelfEat(this, postoBuy);
                        foodshop[posShop - 5].OnConsume(Team[postoBuy],this);
                        foodshop[posShop - 5] = null;
                        foodShopRealignRight(posShop - 5);
                        return 1;
                    }
                }
                else//this is the aoe section and as such doesn't require a null check on pets
                {
                    gold -= 3;
                    foodshop[posShop - 5].OnConsume(null, this); //this should only be active with aoe buffs
                    foodshop[posShop - 5] = null;
                    foodShopRealignRight(posShop - 5);
                    return 1;
                }

            }
            else
            {
                if (Petshop[posShop] == null)
                {
                    return -1; //no pet in pet shop means return -1
                }
            }
            if (Team[postoBuy] != null)//animal related purchase
            {
                if (Team[postoBuy].Name != Petshop[posShop].Name) //if names aren't equal ie trying to buy ant on horse
                {
                    Team[postoBuy].OnSelfSold(this, postoBuy); //sell the current animal horse
                    gold -= 3; //remove 3 gold
                    Petshop[posShop].OnBought(this, postoBuy); //buy the shop animal ant
                    Petshop[posShop] = null; //set the petshop to null
                    petShopRealignLeft(posShop);
                    return 2; //return successfull override
                }
                if (Team[postoBuy].Xp >= 5) //if the animal is not null and not the same it must be getting xp therefore check the xp of the animal
                {
                    return -1; //if it is already level 5 return -1;
                }
                gold -= 3; 
                Petshop[posShop].OnBought(this, postoBuy); //buy the animal
                Petshop[posShop] = null;
                petShopRealignLeft(posShop);
                return 1;

            } 
            else //the team spot is null already
            {
                gold -= 3;
                Petshop[posShop].OnBought(this, postoBuy); //buy the animal
                Petshop[posShop] = null; //set the shop to null
                petShopRealignLeft(posShop);
                return 1;
            }
        }


        public void renderTeam(Pets[] Te)
        {
            string teamstring = "";
            string teamathp = "";
            for (int i = 0; i < 5; i++)
            {
                if (Te[i] == null)
                {
                    teamstring += "no ";
                    teamathp += "0/0 ";
                }
                else
                {
                    teamstring += Te[i].Name.ToString() + " ";
                    teamathp += Te[i].Attack + "/" + Te[i].Hp + " ";
                }
            }

            Console.WriteLine(teamstring);
            Console.WriteLine("---------------");
            Console.WriteLine(teamathp);
        }
        public void BringToFront(Pets[] Te) // [null,1,null,1,null]
        {
            bool sorted = false;
            while (!sorted)
            {
                for (int i = 4; i >= 0; i--) //[null,1,null,1,null] i = 4
                {
                    if (Te[i] == null) //true
                    {
                        for (int x = i; x > 0; x--) //fist [null,1,null,1,null] x = 4
                        {
                            Te[x] = Te[x - 1]; //fist [null,1,null,1,1]
                            Te[x - 1] = null; //fist [null,1,null,null,1]
                        }
                    }
                }
                sorted = true;
                bool nonnullFound = false;
                for (int i = 0; i < 5; i++) //[null,null,1,null,1]
                {
                    if (Te[i] == null)
                    {
                        if (nonnullFound)
                        {
                            sorted = false;
                            i += 5;
                        }
                    }
                    else
                    {
                        nonnullFound = true;
                    }
                }
            }

        }

        public void petShopRealignLeft(int spotBought)
        {
            Petshop[spotBought] = null;
            for (int i = spotBought; i < 4; i++)
            {
                Petshop[i] = Petshop[i + 1];
                Petshop[i + 1] = null;
            }
        }

        public void foodShopRealignRight(int spotBought)
        {
            if (spotBought == 1)
            {
                foodshop[1] = foodshop[0];
                foodshop[0] = null;
            }
        }


        public double TeamFight(Pets[] EnemyTeam)
        {
            if (EnemyTeam == null)
            {
                EnemyTeam = CreateRandomTeam();
            }
            Pets[] teamcopy = copyTeam();

            bool teamexist = true;
            bool enemyexist = true;
            BringToFront(teamcopy);
            BringToFront(EnemyTeam);
            for (int i = 0; i < 5; i++)
            {
                if (teamcopy[i] != null)
                {
                    teamcopy[i].OnBattleStart(teamcopy,EnemyTeam,i);
                }
                if (EnemyTeam[i] != null)
                {
                    EnemyTeam[i].OnBattleStart(EnemyTeam, teamcopy,i);
                }
            }
            while (teamexist && enemyexist)
            {
                BringToFront(teamcopy);
                BringToFront(EnemyTeam);
                if (teamcopy[4] == null)
                {
                    teamexist = false;
                }
                if (EnemyTeam[4] == null)
                {
                    enemyexist = false;
                }
                if (!teamexist || !enemyexist)
                {
                    break;
                }
                attack(teamcopy, EnemyTeam);
                if (render)
                {
                    renderTeam(teamcopy);
                    renderTeam(EnemyTeam);
                }


            }
            if (!teamexist && !enemyexist)
            {
                return 0.0; //draw
            }
            if (!teamexist)
            {
                if (Turn >= 5)
                {
                    Lives -= 3;
                }
                else if (Turn >= 3)
                {
                    Lives -= 2;
                }
                else
                {
                    Lives -= 1;
                }
                return -1.0; //loss
            }
            else
            {
                wins += 1;
                return 1.0; // win
            }
        }

        private Pets[] CreateRandomTeam()
        {
            Pets[] returnValue = new Pets[5];
            if (Turn >= 11)
            {
                for (int i = 0; i < 5; i++)
                {
                    returnValue[i] = RandomPet(rn.Next(0, 58));
                    returnValue[i].Attack += Turn / 2;
                    returnValue[i].Hp += Turn / 2;
                }
            }
            else if (Turn >= 9)
            {
                for (int i = 0; i < 5; i++)
                {
                    returnValue[i] = RandomPet(rn.Next(0, 49));
                    returnValue[i].Attack += Turn / 2;
                    returnValue[i].Hp += Turn / 2;
                }
            }
            else if (Turn >= 7)
            {
                for (int i = 0; i < 5; i++)
                {
                    returnValue[i] = RandomPet(rn.Next(0, 41));
                    returnValue[i].Attack += Turn / 2;
                    returnValue[i].Hp += Turn / 2;
                }
            }
            else if (Turn >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    returnValue[i] = RandomPet(rn.Next(0, 30));
                    returnValue[i].Attack += Turn / 2;
                    returnValue[i].Hp += Turn / 2;
                }
            }
            else if (Turn >= 3)
            {
                for (int i = 0; i < 5; i++)
                {
                    returnValue[i] = RandomPet(rn.Next(0, 19));
                    returnValue[i].Attack += Turn / 2;
                    returnValue[i].Hp += Turn / 2;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    returnValue[i] = RandomPet(rn.Next(0, 9));
                }
            }
            return returnValue;
        }

        private void attack(Pets[] teamPets, Pets[] enemypets)
        {
            teamPets[4].OnAttack(teamPets, enemypets);
            if(enemypets[4] != null)
                enemypets[4].OnAttack(enemypets, teamPets);
            
            if (teamPets[4] != null && enemypets[4] != null)
            {
                int damageE = teamPets[4].Attack;
                teamPets[4].OnDamage(enemypets[4].Attack, teamPets, enemypets, 4);
                if(enemypets[4] != null)
                    enemypets[4].OnDamage(damageE, enemypets, teamPets, 4);

            }

        }

        public Pets RandomPet(int i)
        {
            return Pets.PetsGen(i, Cans, Cans);
        }

        public Food RandomFood(int i)
        {
            return Food.FoodGen(i);

        }



        /*this should turn an environment state into a 3x5x5 array with inslice 0 being teams slice 1 being shop and slice 2 being foodshop, gold and turn
         * 
         */
        public int[,,] Environmenttodata()
        {
            int[,,] environmentArray = new int[3,5,5];
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    int[] petVals = Team[i].PetValues();
                    for(int x = 0; x < 5; x++)
                    {
                        environmentArray[0, i, x] = petVals[x];
                    }
                }
                if (Petshop[i] != null)
                {
                    int[] petVals = Petshop[i].PetValues();
                    for (int x = 0; x < 5; x++)
                    {
                        environmentArray[1, i, x] = petVals[x];
                    }
                }
            }
            for (int i = 0; i < 2; i++)
            {
                if (foodshop[i] != null)
                {
                    environmentArray[2, i, 0] = (int)foodshop[i].Name;
                }
            }
            environmentArray[2, 3, 0] = Turn;
            environmentArray[2,2,0] = Lives;
            environmentArray[2, 4, 0] = gold;
            environmentArray[2, 2, 1] = wins;
            if (TurnStartFlag)
            {
                environmentArray[2, 2, 2] = 1;
            }



            /* in the case of an all ant team with honeys and 4 xp (so +4/+4) 
             * and an all horse shop and 1 apple on turn 4 with 10 gold
             * with 3 wins and 2 lives with the turn having just started
             *  
             * 1,1,1,1,1    5,5,5,5,5   6,6,6,6,6  1,1,1,1,1  4,4,4,4,4
             * 6,6,6,6,6  x 1,1,1,1,1 x 2,2,2,2,2 x0,0,0,0,0 x0,0,0,0,0
             * 0,1,2,4,10   0,0,3,0,0   0,0,0,0,0  0,0,0,0,0  0,0,0,0,0
             * 
             * 
             */
            return environmentArray;
        }

        public void AddDelegates(TakeActionDelegate tad, ReceiveWinLossDelegate rwld, RerollDelegate rrd)
        {
            this.SendToGui = tad;
            this.WinLose = rwld;
            this.GuiReroll = rrd;
        }
        private void Pass()
        {
            if (gold <= 3)
            {
                this.Turnend();
            }
            else
            {
                this.Reroll(false);
            }
        }
        /// <summary>
        /// Takes a given petString from the gui and returns a string of pets also handles food
        /// </summary>
        /// <param name="PetString">string from guireroll formated as pet0 pet1 pet2 pet3 pet4 food0 food1</param>
        /// <returns>a pet[5] to slot into the shoppets</returns>
        private void PetStringsToShop(string PetString)
        {
            Console.WriteLine(PetString);
            Pets[] shopPets = new Pets[5];
            Food[] shopFoods = new Food[2];
            string[] words = PetString.Split(' ');
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(words[i]);
                if (words[i].ToLower() == "none")
                {
                    shopPets[i] = null;
                }
                else
                {
                    PetsNames P;
                    if(Enum.TryParse(words[i],true, out P))
                    {
                        shopPets[i] = Pets.PetsGen((int)P - 1, cans, cans);
                    }
                }
            }
            for (int i = 5; i < 7; i++)
            {
                if (words[i].ToLower() == "none")
                {
                    shopFoods[i - 5] = null;
                }
                else
                {
                    foodNames F;
                    if (Enum.TryParse(words[i], out F))
                    {
                        shopFoods[i - 5] = Food.FoodGen((int)F - 1);
                    }
                }
            }

            this.foodshop = shopFoods;
            this.Petshop = shopPets;

        }

        public int[,,] processMessage(string Message)
        {
            TurnStartFlag = false;
            if(Message == "PAS")
            {
                this.Pass();
            }
            else if (Message == "RESTART") 
            {
                this.Reset();
            }
            //It should be in form "int int"
            else
            {
                string[] m = Message.Split(" ");
                switch(Buy(int.Parse(m[0]), int.Parse(m[1])))
                {
                    case 2:
                        if (!selfcontrol)
                        {
                            SendToGui("OVR " + Message);
                        }
                        break;
                    case 1:
                        if (!selfcontrol)
                        {
                            SendToGui("BUY " + Message);
                        }
                        break;
                    case -1: //something stopped this from being valid but still have enough gold to reroll and try some more 
                        this.Pass();
                        break;
                    case -2:
                        this.Turnend();
                        break;
                }
                
                    
                

            }


            return Environmenttodata();
        }


    }
}
