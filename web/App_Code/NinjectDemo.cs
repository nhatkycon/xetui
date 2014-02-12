using System;
using Ninject;//InjectProperty
using Ninject.Modules;//NinjectModule
namespace ConstructorInjectionDemoNS
{
    interface IWeapon
    {
        void Hit(string target);
    }
    class Sword : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Killed {0} using Sword", target);
        }
    }
    class Gun : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Killed {0} using Gun", target);
        }
    }
    class Soldier
    {
        private IWeapon _weapon;
        [Inject]
        public Soldier(IWeapon weapon)
        {
            _weapon = weapon;
        }
        public void Attack(string target)
        {
            _weapon.Hit(target);
        }
    }
    class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            Bind<Soldier>().ToSelf();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new WarriorModule());
            Soldier warrior = kernel.Get<Soldier>();
            warrior.Attack("the foemen");
            Console.ReadKey();
        }
    }
}