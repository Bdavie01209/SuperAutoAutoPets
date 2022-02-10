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
                10 => new Dodo(ExtraHp, ExtraAttack),
                9 => new Crab(ExtraHp,ExtraAttack),

                8 => new Pig(ExtraHp, ExtraAttack),
                7 => new Otter(ExtraHp, ExtraAttack),
                6 => new Mosquito(ExtraHp, ExtraAttack),
                5 => new horse(ExtraHp, ExtraAttack),
                4 => new Fish(ExtraHp, ExtraAttack),
                3 => new Duck(ExtraHp, ExtraAttack),
                2 => new Cricket(ExtraHp, ExtraAttack),
                1 => new Beaver(ExtraHp, ExtraAttack),
                _ => new Ant(ExtraHp, ExtraAttack),
            };
        }

        protected int Level()
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
            //base case do nothing
        }
        public virtual void OnSelfEat(Environment env, int pos)
        {
            //base case do nothing
        }
        public virtual void OnTurnEnd(Environment env)
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
        public virtual int Hp { get; set; }
        public virtual int Attack { get; set; }
        public abstract PetsNames Name { get; }

        public virtual int[] PetValues()
        {
            return new int[5] { (int)Name, Hp, Attack, Xp, (int)Equip };
        }

        public virtual Pets Clone()
        {
            Pets P = PetsGen((int)this.Name - 1, 0, 0);
            P.Attack = this.Attack;
            P.Hp = this.Hp;
            P.Equip = this.Equip;
            P.Xp = this.Xp;
            return P;
        }
    }
}
