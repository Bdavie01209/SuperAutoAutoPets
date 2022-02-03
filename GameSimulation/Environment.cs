using GameSimulation.PetsFolder;
using GameSimulation.FoodFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        bool randTeam;
        bool prevTeamModel;
        bool render;
        public Random rn;

        private Pets[] prevTeam;

        public Environment(bool SC, bool Render, bool method)
        {
            Team = new Pets[5];
            Petshop = new Pets[5];
            prevTeam = new Pets[5];
            foodshop = new Food[2];
            Turn = 0;
            gold = 11;
            Cans = 0;
            Lives = 10;
            selfcontrol = SC;
            rn = new Random();
            render = Render;

            if (!method)
            {
                prevTeamModel = true;
                randTeam = false;
            }
            else
            {
                randTeam = true;
                prevTeamModel = false;
            }


            Turnstart();
        }

        public Pets[] copyTeam()
        {
            Pets[] returnValue = new Pets[5];
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    returnValue[i] = Team[i].clone();
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
        }

        public void Turnstart()
        {
            gold = 11;
            Turn += 1;
            Reroll();
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    Team[i].onTurnStart(this, i);
                }
            }
            prevTeam = copyTeam();
        }

        public void Reroll()
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
            
        }

        public double Turnend()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    Team[i].onTurnEnd(this);
                }
            }
            if (randTeam)
            {
                TeamFight(null, render);
            }
            return 0.0;
        }

        public double Buy(int posShop, int postoBuy)
        {
            if (gold < 3)//no gold
            {
                return -1.0;
            }
            if (posShop > 4)//food shop related purchase
            {
                if(foodshop[postoBuy - 4] == null)
                {
                    return -1.0;
                }
                if (foodshop[postoBuy - 4].Name != foodNames.SaladBowl || foodshop[postoBuy - 4].Name != foodNames.Sushi || foodshop[postoBuy - 4].Name != foodNames.Pizza)
                {
                    if (Team[postoBuy] == null)
                    {
                        return -1.0;
                    }
                    else
                    {
                        gold -= 3;
                        Team[postoBuy].onSelfEat(this, postoBuy);
                        foodshop[posShop - 4].OnConsume(Team[postoBuy],this);
                        foodshop[posShop - 4] = null;

                        return 1.0;
                    }
                }
                else
                {
                    gold -= 3;
                    foodshop[postoBuy - 4].OnConsume(null, this); //this should only be active ith aoe buffs
                    foodshop[postoBuy - 4] = null;
                    return 1.0;
                }

            } 
            if (Team[postoBuy] != null)//animl related purchase
            {
                if (Team[postoBuy].Name != Petshop[posShop].Name)
                {
                    return -1.0;
                }
                if (Team[postoBuy].Xp >= 5)
                {
                    return -1.0;
                }
                gold -= 3;
                Petshop[posShop].onBought(this, postoBuy);
                Petshop[posShop] = null;
                return 1.0;

            } 
            else
            {
                gold -= 3;
                Petshop[posShop].onBought(this, postoBuy);
                Petshop[posShop] = null;
                return 1.0;
            }
        }

        public double BuyReplace(int posShop, int posToBuy)
        {
            if (Team[posToBuy] != null)
            {
                Team[posToBuy].onSelfSold(this, posToBuy);
            }

            return Buy(posShop, posToBuy);

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

        public double TeamFight(Pets[] EnemyTeam, bool Render)
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
                    teamcopy[i].onBattleStart(teamcopy,EnemyTeam);
                }
                if (EnemyTeam[i] != null)
                {
                    EnemyTeam[i].onBattleStart(EnemyTeam, teamcopy);
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
                if (Render)
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
                return -1.0; //loss
            }
            else
            {
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
            teamPets[4].onAttack(teamPets, enemypets);
            enemypets[4].onAttack(enemypets, teamPets);
            int damageE = teamPets[4].Attack;

            teamPets[4].onDamage(enemypets[4].Attack, teamPets, enemypets, 4);
            enemypets[4].onDamage(damageE, enemypets, teamPets, 4);
        }

        public Pets RandomPet(int i)
        {
            switch (i)
            {
                case 6:
                    return new Mosquito(cans, cans);
                case 5:
                    return new horse(cans, cans);
                case 4:
                    return new Fish(cans, cans);
                case 3:
                    return new Duck(Cans, Cans);
                case 2:
                    return new Cricket(Cans, Cans);
                case 1:
                    return new Beaver(Cans, Cans);
                default:
                    return new Ant(Cans, Cans);
            }

        }

        public Food RandomFood(int i)
        {
            switch (i)
            {
                default:
                    return new Apple();
            }

        }



        /*this should turn an environment state into a 3x5x5 array with inslice 0 being teams slice 1 being shop and slice 2 being foodshop, gold and turn
         * 
         */
        public int[,,] environmenttodata()
        {
            int[,,] environmentArray = new int[3,5,5];
            for (int i = 0; i < 5; i++)
            {
                if (Team[i] != null)
                {
                    int[] petVals = Team[i].petValues();
                    for(int x = 0; x < 5; x++)
                    {
                        environmentArray[0, i, x] = petVals[x];
                    }
                }
                if (Petshop[i] != null)
                {
                    int[] petVals = Petshop[i].petValues();
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
            environmentArray[2, 4, 0] = gold;

            /* in the case of an all ant team with an all horse shop and 1 apple on turn 4 with 10 gold it should look like
             * 
             * 1,1,1,1,1    1,1,1,1,1   2,2,2,2,2
             * 6,6,6,6,6  x 1,1,1,1,1 x 2,2,2,2,2
             * 0,1,0,4,10   0,0,0,0,0   0,0,0,0,0
             * 
             * 
             */
            return environmentArray;
        }

    }
}
