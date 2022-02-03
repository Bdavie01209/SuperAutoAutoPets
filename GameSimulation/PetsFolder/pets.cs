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
        public virtual void XpUp(Environment env, int pos)
        {
            Hp++;
            Attack++;
            Xp++;
        }
        public virtual void onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            if (equip == equipment.honey)
            {
                team[pos] = new ZombieCricket(0,0);
            }
            else
            {
                team[pos] = null;
            }

        }
        public virtual void onDamage(int damage, Pets[] team, Pets[] enemy, int loc)
        {
            if (equip == equipment.Melon)
            {
                equip = equipment.none;
                if (damage - 20 > 0){
                    this.Hp -= damage - 20;
                }
            }
            else if (equip == equipment.Garlic)
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
                this.onfaint(team,enemy,loc);
            }
        }
        public virtual void onSelfSold(Environment env, int pos)
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
        public virtual void onBought(Environment env, int pos)
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
        public virtual void onTurnStart(Environment env, int pos)
        {
            //base case do nothing
        }
        public virtual void onSelfEat(Environment env, int pos)
        {
            //base case do nothing
        }
        public virtual void onTurnEnd(Environment env)
        {
            //base case do nothing
        }
        public virtual void onBattleStart(Pets[] team, Pets[] enemy)
        {
            //base case do nothing
        }

        public virtual void onAttack(Pets[] team, Pets[]enemy)
        {
            if (equip == equipment.Chili)
            {
                if (enemy[3] != null)
                {
                    enemy[3].onDamage(5, enemy, team, 3);
                }
            }
        }

        public virtual equipment equip { get; set; }
        public virtual int Xp { get; set; }
        public virtual int Hp { get; set; }
        public virtual int Attack { get; set; }
        public virtual PetsNames Name { get; }

        public virtual int[] petValues()
        {
            return new int[5] { (int)Name, Hp, Attack, Xp, (int)equip };
        }

        public abstract Pets clone();
    }
}
