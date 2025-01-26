using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;

partial class Figure
{
    
    public int width;
    public int height;
    public Figure()
    {
        width = 10;
        height = 10;
    }
    public Figure(int w, int h)
    {
        width = w;
        height = h;
    }
    public void Sqare(int x, int y)
    {
        Console.WriteLine(x * y);
    }
    public void Write()
    {
        Console.WriteLine("Фигура!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.width}, {this.height}";
    }
}
//--->
struct Figure_struct
{
    public string color;
    public Figure_struct()
    {
        color = "white";
    }

    public void Write()
    {
        Console.WriteLine($"Цвет фигуры:{color}");
    }

    static Figure_struct() {
        Console.WriteLine("Статический конструктор запущен"); 
    }

};
//--->
enum Fugire_number {
    first = 1,
    second,
    nine = 9,
    ten
}


class Rectangle : Figure
{
    public int x;
    public int y;
    public int z;
    public Rectangle()
    {
        x = 5;
        y = 5;
        z = 5;
    }
    public Rectangle(int x1, int y1, int z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }

    public void Sqare()
    {
        Console.WriteLine((base.width + x) * (base.height + y));
    }

    public void Write()
    {
        Console.WriteLine("прямоугольник!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}, {this.z}";
    }
}

abstract class Decor
{
    private int width;
    private int height;
    private string name;

    public int Width
    {
        get { return width; }        
        set { width = value; }       
    }

    public int Height
    {
        get { return height; }     
        set { height = value; }      
    }

    public string Name
    {
        get { return name; }         
        set { name = value; }        
    }

    public Decor(int Width1, int Heigt1, string name)
    {
        Width = Width1;
        Height = Heigt1;
        Name = name;
    }

    public abstract void Name_enter(string name);
    public abstract void Abama();


    public void Write()
    {
        Console.WriteLine("Decor!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {width}, {height}, {Name}";
    }
}

class Decor_color : Decor
{

    public Decor_color(int Width, int Heigt, string name) : base(Width,Heigt, name) { }
    public override void Name_enter(string name = "Decor_color")
    {
        Console.WriteLine($"Имеется элемент в Decor_color {name}");
    }
    public override void Abama()
    {
        Console.WriteLine("Вызван метод наследуемый от abstact (Decor_сolor)");
    }
    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {base.Width}, {base.Height}, {base.Name}";
    }


}


 class Decor_Elem : Decor, Abstr
{
    public Decor_Elem(int Width, int Heigt, string name) : base(Width, Heigt, name) { }
    
    public override void Abama()
    {
        Console.WriteLine("Вызван метод наследуемый от abstact (Decor_Elem)");
    }

    void Abstr.Abama()
    {
        Console.WriteLine($"Вызван метод наследуемый от interface");
    }
    public override void Name_enter(string name = "Decor_Elem")
    {
        Console.WriteLine($"Имеется элемент {name}");
    }

    public void Write()
    {
        Console.WriteLine("Decor_Elem!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {base.Width}, {base.Height}, {base.Name}";
    }
}

class Button : Decor_Elem
{
    public Button(int Width, int Heigt, string name) : base(Width, Heigt, name) { }  
    public void Write()
    {
        Console.WriteLine("Button!");
    }
    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {base.Width}, {base.Height}, {base.Name}";
    }

}
class Menu : Decor_Elem, Face
{
    public Menu(int Width, int Heigt, string name) : base(Width, Heigt, name) { }
    void Face.Write()
    {
        Console.WriteLine("Меню!");
    }

    public int Size(int a, int b)
    {
        return a + b;
    }


    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {base.Width}, {base.Height}, {base.Name}";
    }
}


sealed class Window : Decor_Elem
{

    public Window(int Width, int Heigt, string name) : base(Width, Heigt, name) { }

    public void Write()
    {
        Console.WriteLine("Window!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {base.Width}, {base.Height}, {base.Name}";
    }

}

interface Face
{
    void Write();
    int Size(int a, int b);


}

interface Abstr
{
    void Abama();
}

class Programm
{
    public static void Main(string[] args)
    {
        Menege.main_function();
        //Manage<Button> manage = new Manage<Button>();
        //manage.Attack_by_Titans();

        //Manage<string> manage = new Manage<string>();
        //manage.Add("Первый элемент");
        //manage.Add("Второй элемент");

        //manage.Print();

        //manage.Delete("Первый элемент");
        //manage.Print();

        //// 
        //Button bbb1 = new Button();
        //Button bbb = new Button();

        ////
        //Manage<int> intManage = new Manage<int>();
        //intManage.Add(100);
        //intManage.Add(200);

        //intManage.Print();
        //intManage.Delete(100);
        //intManage.Print();

        //Figure rrr1 = new Figure();
        //rrr1.Partial_class_call();

        //Interface_PC<string> example1 = new Interface_PC<string>();
        //example1.Add("wddwdwdw");
        //example1.Print();

        //Figure figur1 = new Rectangle();
        //Rectangle rec1 = figur1 as Rectangle;

        //Decor decor1 = new Decor_Elem();
        //Decor_Elem decor_elem1 = decor1 as Decor_Elem;

        //Decor_Elem decor_elem2 = new Button();
        //Button button1 = decor_elem1 as Button;

        //Decor_Elem decor_elem3 = new Menu(3, 5);
        //Menu menu1 = decor_elem3 as Menu;



        //Decor_Elem decor_elem4 = new Window();
        //Window window1 = decor_elem4 as Window;
        //decor_elem4.Write();
        //window1.Write();

        //Decor_Elem decor_elem5 = new Decor_Elem();
        //decor_elem5.Abama();
        //decor_elem5.Name_enter();

        //Decor_color decor_color1 = new Decor_color();
        //decor_color1.Abama();
        //decor_color1.Name_enter();

        //Figure f1 = new Figure(); Console.WriteLine(f1.ToString());
        //Rectangle r1 = new Rectangle(); Console.WriteLine(r1.ToString());
        //Decor de1 = new Decor_Elem(); Console.WriteLine(de1.ToString());
        //Abstr abstr1 = new Window();
        //Abstr abstr2 = new Button();
        //Decor de2 = new Decor_color();
        //Decor_Elem d1 = new Decor_Elem(); Console.WriteLine(d1.ToString());
        //Button b1 = new Button(); Console.WriteLine(b1.ToString());
        //Window w1 = new Window(); Console.WriteLine(w1.ToString());
        //Menu m1 = new Menu(3, 3); Console.WriteLine(m1.ToString());


        //Decor_Elem decor_elem = new Decor_Elem();
        //(decor_elem as Abstr).Abama();

        //Abstr abstr = decor_elem;
        //Console.WriteLine(abstr is Decor_Elem);
        //Console.WriteLine(abstr is Window);





        //Printer printer = new Printer();
        //object[] mass = {
        //abstr1, de1, abstr2, de2, printer, f1, r1, m1
        //};
        //for (int i = 0; i < mass.Length; i++)
        //{
        //    printer.IAmPrinting(ref mass[i]);
        //}


    }
}


class Printer : W
{


    public override void IAmPrinting(ref Decor x)
    {
        Console.Write($"IAmPrinting ({x.GetType().Name})");
        Console.WriteLine(x.ToString());
    }

    public override void IAmPrinting(ref Abstr x)
    {
        Console.Write($"IAmPrinting ({x.GetType().Name})");
        Console.WriteLine(x.ToString());
    }

    public override void IAmPrinting(ref object x)
    {
        Console.Write($"IAmPrinting ({x.GetType().Name}) ");
        Console.WriteLine(x.ToString());
    }
}
abstract class W
{
    public abstract void IAmPrinting(ref Decor d);
    public abstract void IAmPrinting(ref Abstr d);
    public abstract void IAmPrinting(ref object d);
}
//-------5

class Interface_PC
{
    List<Decor> button_mass = new List<Decor>(); 
    public Interface_PC()
    { 

        Decor decor = new Decor_color(5,5, "Decor_color"); button_mass.Add(decor);
        Decor decor1 = new Decor_Elem(4,4, "Decor_Elem"); button_mass.Add(decor1);
        Decor decor2 = new Button(4, 5, "wwww"); button_mass.Add(decor2);
        Decor decor3 = new Menu(2, 2, "wwww"); button_mass.Add(decor3);
        Decor decor6 = new Menu(2, 2, "wwwee"); button_mass.Add(decor6);
        Decor decor4 = new Window(10, 10, "wwww"); button_mass.Add(decor4);

    }

    public void PrintElems()
    {
        foreach (var button in button_mass)
        {
            Console.WriteLine(button.ToString()); 
        }
    }

    public void Add(Decor elem)
    {
        button_mass.Add(elem);
        Console.WriteLine($"{elem} добавлен в контейнер.");
    }

    public void Delete(Decor elem)
    {
        if (button_mass.Contains(elem))
        {
            Console.WriteLine($"Элемент {elem} удален");
           button_mass.Remove(elem);
        }
        else
        {
            Console.WriteLine($"Элемент {elem} не найден.");
        }
    }

    public void Find_Button()
    {
        foreach (var item in button_mass)
        {
            if (item is Button)
            {
                Console.WriteLine("Найден элемент типа Button");
                Console.WriteLine($"{item.Name}, {item.Width}, {item.Height}");
            }
        }
    }

    public void Menu_couneter(int x)
    {
        int counter = 0;
        foreach (var item in button_mass)
        {
            if (item is Menu) { counter++; }
             if (item is Menu && counter == x)
            {

                Console.WriteLine($"Найден элемент типа Menu c вложенностью {counter}");
                Console.WriteLine($"{item.Name}, {item.Width}, {item.Height}");
            }
        }
    }

    public void Free_spase(int needs_space)
    {
        foreach (var item in button_mass)
        {
           needs_space -= item.Height * item.Width;
        }
        if(needs_space >= 0) { Console.WriteLine($"Места хватит, оствток ({needs_space})"); }
        if(needs_space < 0) { Console.WriteLine($"Места не хватит, а именно ({needs_space})"); }
    }

}

class Menege
{
    public static void main_function()
    {
        Interface_PC interface_PC_temp = new Interface_PC();
        interface_PC_temp.Find_Button();
        interface_PC_temp.Menu_couneter(2);
        interface_PC_temp.Free_spase(432);

    }
}