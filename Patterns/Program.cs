using System;
//I am creating the console application to understanding the software application design patterns 
// in the comments I wrote the definition of a patterns also 
// I am not going to create all patterns in separate cs files rather creating here on a same cs file so can compare 


namespace patterns // Note: actual namespace depends on the project name.
{
    internal class program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //aggrigate root cluster / group of objects that are treated as a single unit of data..only can read through root. order n line item
            //its can not added., not naked in inherited class also.repository encapsulates access to child objects
            course courseobj = new course();
            courseobj.getStudents();

            //The iterator pattern provides a way to access the elements of an aggregate object without exposing 
            //    its underlying representation.

            //like itrate all notification object type of notification class. we will not use arraylist to iterate all

            //consume singleton
            foreach (var item in singleton.Displaystudentnames())
            {
                Console.WriteLine(item.name + "  ::" + item.id);
            }

            //consume factory
            Factory factory = new Factory();
            factory.GetSahpe("circle").draw();

            //consume repository
            //The benefit of the repository pattern is that we do not create concrete class objects, rather we create objects of an interface.
            //we assign ref of concrete class, my interface has all the function sigature.
            //so in case i can assign another class object having the same interface implemented.

            IstudentRepository istudentrepo;
            istudentrepo = new Studentrepo();
            var students = from s in istudentrepo.GetAllStudents()
                           select s;   

        }
    }
}


public class student
{
    public int id { get; set; }
    public string name { get; set; }

}

class course
{
    private List<student> students;

    public IEnumerable<student> getStudents()
    {
        students = new List<student>();
        return students;
    }
}

//singleton can only make with static, but it will not threadsafe. 
//static+ threadsafe + safe iteration +
//used for data cacaheing, data sharing, also you want to sahre data like hit counter, Logger

public sealed class singleton
{
    //can Not inherited constructor prive
    private singleton() { }

    //encapsulate members
    private static List<student> objsingleton_student = null;

    // safe iteration using IEnumberable so that can not manupulate.add where someone using it.
    public static IEnumerable<student> Displaystudentnames()
    {
        //lazy loading, load when call displaystudentnames
        if (objsingleton_student == null)
        {
            objsingleton_student = new List<student>();
            refreshnames();
        }
        return objsingleton_student;
    }

    //thread safe, while using it refresh it shouldbe lock
    public static void refreshnames()
    {
        lock (objsingleton_student)
        {
            student student = new student();
            student.name = "Jai";
            student.id = 1;
            objsingleton_student.Add(student);
            student student1 = new student();
            student1.name = "sus";
            student1.id = 2;
            objsingleton_student.Add(student1);

        }
    }
}


// exaple now factory pattern
// Empty vocabulary of actual object
public interface IShape
{
    void draw();
}

public class Circle : IShape
{
    public void draw()
    {
        var c = new System.Drawing.Point(30, 30);
    }
}

public class Rectangle : IShape
{
    public void draw()
    {
        var r = new System.Drawing.Rectangle(100, 100, 300, 150);
    }
}

/// Implementation of Factory - Used to create objects.

public class Factory
{
    public IShape GetSahpe(string type)
    {
        switch (type)
        {
            case "circle":
                return new Circle();
            case "rectangle":
                return new Rectangle();
            default:
                throw new NotSupportedException();
        }
    }
}


// exaple now Repository pattern
public interface IstudentRepository : IDisposable
{
    public List<student> GetAllStudents();
    public void insertstudent(student studentobj);

}

public class Studentrepo : IstudentRepository, IDisposable
{
    public Studentrepo()
    {
        // set dbcontext
    }
    public List<student> GetAllStudents()
    {
        //some logic to get from dbcontext
        return new List<student>();
    }
    public void insertstudent(student student)
    {
        //some logic
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                Dispose();
            }
        }
        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

/// <summary>
/// creating the sample for new abstruct factory pattern
/// </summary>
public class abstractfactory{

}