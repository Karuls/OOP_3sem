class Figure{
    public int width;
    public int height;
    public Figure() { 
        width = 10;
        height = 10;
    }
    public Figure(int w, int h){
        width = w;
        height = h;
    }
    public void Sqare(int x, int y)
    {
        Console.WriteLine( x * y);
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

class Rectangle : Figure {
    public int x;
    public int y;
    public int z;
    public Rectangle() { 
    x = 5;
        y = 5;
        z = 5;
    }
    public Rectangle(int x1, int y1, int z1) {
    x = x1;
        y = y1;
            z = z1;
    }

    public void Sqare()
    {
        Console.WriteLine ((base.width + x) * (base.height + y));
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
    int x;
    int y;
    public abstract void Name_enter(string name);
    public abstract void Abama();


    public void Write()
    {
        Console.WriteLine("Decor!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}";
    }
}

class Decor_color : Decor
{

    int x = 1;
    int y = 1;
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
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}";
    }

}


class Decor_Elem : Decor,Abstr
{

    int x = 1;
    int y = 1;
    public override void Abama()
    {
        Console.WriteLine("Вызван метод наследуемый от abstact (Decor_Elem)");
    }

    void Abstr.Abama()
    {
        Console.WriteLine($"Вызван метод наследуемый от interface");
    }
    public override void Name_enter(string name = "Decor_Elem") {
        Console.WriteLine($"Имеется элемент {name}");
    }

    public void Write()
    {
        Console.WriteLine("Decor_Elem!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}";
    }
}

class Button: Decor_Elem {
    int x = 1;
    int y = 1;
    public void Write()
    {
        Console.WriteLine("Button!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}";
    }
}
 class Menu: Decor_Elem, Face { 
    int x;
    int y;  
    void Face.Write()
    {
        Console.WriteLine("Меню!");
    }

    public int Size(int a, int b)
    {
        return a + b;
    }
    public Menu(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}";
    }
}


sealed class Window: Decor_Elem {
    int x = 1;
    int y = 1;
     
    
    public void Write()
    {
        Console.WriteLine("Window!");
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}; Value = {this.y}, {this.y}";
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
                                       

        Figure figur1 = new Rectangle();
        Rectangle rec1 = figur1 as Rectangle;
        
        Decor decor1 = new Decor_Elem();
        Decor_Elem decor_elem1 = decor1 as Decor_Elem;

        Decor_Elem decor_elem2 = new Button();
        Button button1 = decor_elem1 as Button;

        Decor_Elem decor_elem3 = new Menu(3,5);
        Menu menu1 = decor_elem3 as Menu;
        


        Decor_Elem decor_elem4 = new Window();
        Window window1 = decor_elem4 as Window;
        decor_elem4.Write();
        window1.Write();

        Decor_Elem decor_elem5 = new Decor_Elem();
        decor_elem5.Abama();
        decor_elem5.Name_enter();

        Decor_color decor_color1 = new Decor_color();
        decor_color1.Abama();
        decor_color1.Name_enter();

        Figure f1 = new Figure(); Console.WriteLine(f1.ToString());
        Rectangle r1 = new Rectangle(); Console.WriteLine(r1.ToString());
        Decor de1 = new Decor_Elem(); Console.WriteLine(de1.ToString());
        Abstr abstr1 = new Window();
        Abstr abstr2 = new Button();
        Decor de2 = new Decor_color();
        Decor_Elem d1 = new Decor_Elem(); Console.WriteLine(d1.ToString());
        Button b1 = new Button(); Console.WriteLine(b1 .ToString());
        Window w1 = new Window(); Console.WriteLine(w1.ToString());
        Menu m1 = new Menu(3,3); Console.WriteLine(m1.ToString());


        Decor_Elem decor_elem = new Decor_Elem();
        (decor_elem as Abstr).Abama();

        Abstr abstr = decor_elem;
        Console.WriteLine(abstr is Decor_Elem);
        Console.WriteLine(abstr is Window);





        Printer printer = new Printer();
        object[] mass = { 
        abstr1, de1, abstr2, de2, printer, f1, r1, m1
        };
        for (int i = 0; i < mass.Length; i++)
        {
            printer.IAmPrinting(ref mass[i]);
        }


    }
}


class Printer:W
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