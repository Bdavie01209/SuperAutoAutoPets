using GameSimulation.PetsFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    public abstract class Pets
    {
        public static Pets PetsGen(int petNumber, int ExtraHp, int ExtraAttack)
        {
            return petNumber switch
            {
                //tier 6
                57 => new Tiger(ExtraHp, ExtraAttack),
                56 => new Snake(ExtraHp, ExtraAttack),
                55 => new Mammoth(ExtraHp, ExtraAttack),
                54 => new Leopard(ExtraHp, ExtraAttack),
                53 => new Gorilla(ExtraHp, ExtraAttack),
                52 => new Fly(ExtraHp, ExtraAttack),
                51 => new Dragon(ExtraHp, ExtraAttack),
                50 => new Cat(ExtraHp, ExtraAttack),
                49 => new Boar(ExtraHp, ExtraAttack),

                //tier 5
                48 => new Turkey(ExtraHp, ExtraAttack),
                47 => new Shark(ExtraHp, ExtraAttack),
                46 => new Seal(ExtraHp, ExtraAttack),
                45 => new Scorpion(ExtraHp, ExtraAttack),
                44 => new Rhino(ExtraHp, ExtraAttack),
                43 => new Monkey(ExtraHp, ExtraAttack),
                42 => new Crocodile(ExtraHp, ExtraAttack),
                41 => new Cow(ExtraHp, ExtraAttack),

                //tier 4 
                40 => new Worm(ExtraHp, ExtraAttack),
                39 => new Whale(ExtraHp, ExtraAttack),
                38 => new Squirrel(ExtraHp, ExtraAttack),
                37 => new Skunk(ExtraHp, ExtraAttack),
                36 => new Rooster(ExtraHp, ExtraAttack),
                35 => new Penguin(ExtraHp, ExtraAttack),
                34 => new Parrot(ExtraHp, ExtraAttack),
                33 => new Hippo(ExtraHp, ExtraAttack),
                32 => new Dolphin(ExtraHp, ExtraAttack),
                31 => new Deer(ExtraHp, ExtraAttack),
                30 => new Bison(ExtraHp, ExtraAttack),
                
                //tier 3    
                29 => new Turtle(ExtraHp, ExtraAttack),
                28 => new Snail(ExtraHp, ExtraAttack),
                27 => new Sheep(ExtraHp, ExtraAttack),
                26 => new Bunny(ExtraHp, ExtraAttack),
                25 => new Ox(ExtraHp, ExtraAttack),
                24 => new Kangaroo(ExtraHp, ExtraAttack),
                23 => new Giraffe(ExtraHp, ExtraAttack),
                22 => new Dog(ExtraHp, ExtraAttack),
                21 => new Camel(ExtraHp, ExtraAttack),
                20 => new Blowfish(ExtraHp, ExtraAttack),
                19 => new Badger(ExtraHp, ExtraAttack),

                //tier 2
                18 => new Swan(ExtraHp, ExtraAttack),
                17 => new Spider(ExtraHp, ExtraAttack),
                16 => new Shrimp(ExtraHp, ExtraAttack),
                15 => new Rat(ExtraHp, ExtraAttack),
                14 => new Peacock(ExtraHp, ExtraAttack),
                13 => new Hedgehog(ExtraHp, ExtraAttack),
                12 => new Flamingo(ExtraHp, ExtraAttack),
                11 => new Elephant(ExtraHp, ExtraAttack),
                10 => new Dodo(ExtraHp, ExtraAttack),
                9 => new Crab(ExtraHp,ExtraAttack),

                //tier 1
                8 => new Pig(ExtraHp, ExtraAttack),
                7 => new Otter(ExtraHp, ExtraAttack),
                6 => new Mosquito(ExtraHp, ExtraAttack),
                5 => new Horse(ExtraHp, ExtraAttack),
                4 => new Fish(ExtraHp, ExtraAttack),
                3 => new Duck(ExtraHp, ExtraAttack),
                2 => new Cricket(ExtraHp, ExtraAttack),
                1 => new Beaver(ExtraHp, ExtraAttack),
                _ => new Ant(ExtraHp, ExtraAttack),
            };
        }

        public int Level()
        {
            switch (Xp)
            {
                case 5:
                    return 3;
                case 4:
                case 3:
                case 2:
                    return 2;
                default:
                    return 1;
            }
        }

        public virtual void XpUp(Environment env, int pos)
        {
            Hp++;
            Attack++;
            Xp++;
        }
        public virtual void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            if (Equip == equipment.honey)
            {
                team[pos] = new ZombieCricket(0,0);
            }
            else
            {
                team[pos] = null;
            }
            if (pos > 0)
            {
                if (team[pos -1] != null)
                {
                    team[pos - 1].OnFriendAheadFaints(team, enemy, pos - 1);
                }
            }

        }

        public virtual void OnFriendAheadFaints(Pets[] team, Pets[] enemy, int loc)
        {
            // do nothing
        }

        public virtual void OnDamage(int damage, Pets[] team, Pets[] enemy, int loc)
        {
            if (Equip == equipment.Melon)
            {
                Equip = equipment.none;
                if (damage - 20 > 0){
                    this.Hp -= damage - 20;
                }
            }
            else if (Equip == equipment.Garlic)
            {
                if (damage - 2 <= 0)
                {
                    this.Hp -= 1;
                }
                else
                {
                    this.Hp -= damage - 2;
                }
            }
            else
            {
                this.Hp -= damage;
            }
            if (this.Hp <= 0)
            {
                this.Onfaint(team,enemy,loc);
            }
        }
        public virtual void OnSelfSold(Environment env, int pos)
        {
                env.Team[pos] = null;
                if (Xp == 5)
                {
                    env.gold += 3;
                }
                else if (Xp > 2)
                {
                    env.gold += 2;
                }
                else
                {
                    env.gold += 1;
                }

        }
        public virtual void OnBought(Environment env, int pos)
        {
            if (env.Team[pos] != null)
            {
                env.Team[pos].XpUp(env, pos);
            }
            else
            {
                env.Team[pos] = this;
            }
        }
        public virtual void OnTurnStart(Environment env, int pos)
        {
            for(int i = 0; i < this.Cupcake; i++)
            {
                this.Hp -= 3;
                this.Attack -= 3;
            }
        }
        public virtual void OnSelfEat(Environment env, int pos)
        {
            //base case do nothing
        }
        public virtual void OnTurnEnd(Environment env, int pos)
        {
            //base case do nothing
        }
        public virtual void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            //base case do nothing
        }

        public virtual void OnAttack(Pets[] team, Pets[]enemy)
        {
            if (Equip == equipment.Chili)
            {
                if (enemy[3] != null)
                {
                    enemy[3].OnDamage(5, enemy, team, 3);
                }
            }
        }

        public virtual equipment Equip { get; set; }
        public virtual int Xp { get; set; }

        public virtual int Cupcake { get; set; }

        private int hp = 0;
        private int at = 0;
        public virtual int Hp
        {
            get => hp;
            set
            {
                if (value >= 50)
                {
                    hp = 50;
                }
                else if (value <= 0)
                {
                    hp = 0;
                }
                else
                {
                    hp = value;
                }

            }
        }

        public virtual int Attack
        {
            get => at + ((this.Equip == equipment.MeatBone ? 1 : 0) * 5);
            set 
            {
                if(value >= 50)
                {
                    at = 50;
                }
                else if(value <= 0)
                {
                    at = 0;
                }
                else
                {
                    at = value;
                }

            }
        }
        public abstract pets Name { get; }

        public virtual int[] PetValues()
        {
            return new int[5] { (int)Name, Hp, Attack, Xp, (int)Equip };
        }

        public virtual Pets Clone()
        {
            Pets P = PetsGen((int)Name, 0, 0);
            P.Attack = this.Attack;
            P.Hp = this.Hp;
            P.Equip = this.Equip;
            P.Xp = this.Xp;
            return P;
        }
    }
}
