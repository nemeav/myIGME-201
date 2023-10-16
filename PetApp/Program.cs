using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Neme Velazquez
 * Purpose: Create essentially a pet owner simulator with a choice of cat(s)/dog(s)
 * Restrictions:
 */
namespace PetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            string sAge = null;

            Pets pets = new Pets();

            Random rand = new Random();

        start:
            for (int i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        // add a dog
                        dog = new Dog(null, null, 0);
                        Console.WriteLine("You bought a dog!");
                        //ask for name and read
                        Console.Write("Name the dog => ");
                        dog.Name = Console.ReadLine();
                    //ask for age and read
                    age:
                        try
                        {
                            Console.Write($"How old is {dog.Name}? ");
                            sAge = Console.ReadLine();
                            dog.age = Convert.ToInt32(sAge);
                        }
                        catch
                        {
                            Console.Write("Please enter a valid age: ");
                            goto age;
                        }
                        //ask for license id and read
                        Console.Write($"What's {dog.Name}'s license ID? ");
                        dog.license = Console.ReadLine();
                        dog = new Dog(dog.license, dog.Name, dog.age);
                        pets.Add(dog);
                        //confirm info by printing
                        Console.WriteLine($"Dog's Name => " + dog.Name);
                        Console.WriteLine($"Age => " + dog.age);
                        Console.WriteLine($"License => " + dog.license);
                    }
                    else
                    {
                        // else add a cat
                        cat = new Cat();
                        pets.Add(cat);
                        Console.WriteLine("You bought a cat!");
                        //ask for name and read
                        Console.Write("Name the cat => ");
                        cat.Name = Console.ReadLine();
                    //ask for age and read
                    age:
                        try
                        {
                            Console.Write($"How old is {cat.Name}? ");
                            sAge = Console.ReadLine();
                            cat.age = Convert.ToInt32(sAge);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a valid age: ");
                            goto age;
                        }
                        //confirm info by printing
                        Console.WriteLine($"Cat's Name => " + cat.Name);
                        Console.WriteLine($"Age => " + cat.age);
                    }
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do
                    if (pets.petList.Count == 0)
                    {
                        goto start;
                    }
                    else
                    {
                        thisPet = pets.petList[rand.Next(0, pets.petList.Count)];
                        if (thisPet is Cat)
                        {
                            iCat = (ICat) thisPet;
                            switch (rand.Next(0,5)) {
                                case 0:
                                    iCat.Eat();
                                    break;
                                case 1:
                                    iCat.Play();
                                    break;
                                case 2:
                                    iCat.Scratch();
                                    break;
                                case 3:
                                    iCat.Purr();
                                    break;
                                case 4:
                                    thisPet.GotoVet();
                                    break;
                            }
                        }
                        else
                        {
                            iDog = (IDog)thisPet;
                            switch (rand.Next(0,5))
                            {
                                case 0:
                                    iDog.Eat();
                                    break;
                                case 1:
                                    iDog.Play();
                                    break;
                                case 2:
                                    iDog.Bark();
                                    break;
                                case 3:
                                    iDog.GotoVet();
                                    break;
                            }
                        }
                    }
                }

            }

        }
    }

    /* Purpose: class to manage group of pets
     * Restrictions:
     * Returns:
     */
    public class Pets
    {
        //field to store list
        public List<Pet> petList = new List<Pet>();

        //properties
        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int Count
        {
            get
            {
                return petList.Count;
            }
        }

        //methods
        public Pet Add(Pet pet)
        {
            petList.Add(pet);
            return pet;
        }
        public Pet Remove(Pet pet)
        {
            petList.Remove(pet);
            return pet;
        }
        public int RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
            return petEl;
        }
    }

    /* Purpose: base for all Pet objects to be used in sim (identifying info+methods)
     * Restrictions:
     * Returns:
     */
    public abstract class Pet
    {
        //field - identifying info for object
        private string name;
        public int age;

        //property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //method
        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();

        //constructors
        public Pet() { }
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    /* Purpose: store basic cat methods
     * Restrictions:
     * Returns: N/A?
     */
    public interface ICat
    {
        //methods
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }

    /* Purpose: Create cat object with override methods
     * Restrictions:
     * Returns: 
     */
    public class Cat : Pet, ICat
    {
        //methods
        public override void Eat()
        {
            Console.WriteLine(this.Name + ": This tuna is acceptable...");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + ": I SHALL CAPTURE THE MOUSE!");
        }
        public void Purr()
        {
            Console.WriteLine(this.Name + ": Purrr... this is nice...");
        }
        public void Scratch()
        {
            Console.WriteLine(this.Name + ": YOU DARE???");
        }
        public override void GotoVet()
        {
            Console.WriteLine(this.Name + ": THE HEALERS??? JAIL! JAIL FOR YOU FOR THOUSAND YEARS! TREASONNN");
        }

        //constructors
        public Cat() { }
    }

    /* Purpose: store basic dog methods
     * Restrictions:
     * Returns:
     */
    public interface IDog
    {
        //methods
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    /* Purpose: create/store info for dog object
     * Restrictions:
     * Returns: 
     */
    public class Dog : Pet, IDog
    {
        //field - identifying stuff unique to dogs
        public string license;

        //methods
        public override void Eat()
        {
            Console.WriteLine(this.Name + ": *cronch cronch*");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + ": BALL! BALL! BALL!");
        }
        public void Bark()
        {
            Console.WriteLine(this.Name + ": BORK BORKBORK BORK");
        }

        public void NeedWalk()
        {
            Console.WriteLine(this.Name + ": Outside? Outside outside???");
        }
        public override void GotoVet()
        {
            Console.WriteLine(this.Name + ": Ruh-oh! *zoom*");
        }

        //constructor
        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
            this.Name = szName;
            this.age = nAge;
        }
    }
}