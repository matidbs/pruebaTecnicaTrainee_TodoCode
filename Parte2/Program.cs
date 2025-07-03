using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;


public class Ticket{
    private int numero { get; set;}
    private int fila { get; set; }
    private int asiento { get; set; }
    private DateOnly fecha { get; set; }
    private DateOnly fechaValidez { get; set; }
    private float precio { get; set; }

    private Cliente cliente { get; set; }

    public Ticket(int numero, int fila, int asiento, DateOnly fecha, DateOnly fechaValidez, float precio)
    {
        this.numero = numero;
        this.fila = fila;
        this.asiento = asiento;
        this.fecha = fecha;
        this.fechaValidez = fechaValidez;
        this.precio = precio; 
    }

    public string getString()
    {
        return $"{numero},{fila},{asiento},{fecha},{fechaValidez},{precio}";
    }

    public int getFila()
    {
        return fila; 
    }

    public float getPrecio()
    {
        return precio;
    }
}


public class Cliente
{
    private
        int id;
    string dni;
    string nombre;
    string apellido;
    public
       Cliente(int id, string dni, string nombre, string apellido)
    {
        this.id = id;
        this.dni = dni;
        this.nombre = nombre;
        this.apellido = apellido;
    }
}

class Program
{
    static void Main()
    {
        List<Ticket> tickets = new List<Ticket>();
        Ticket t1 = new Ticket(1, 2, 3,  new DateOnly(2025,02,22), new DateOnly(2025,02,25), 12);
        Ticket t2 = new Ticket(2, 3, 5,  new DateOnly(2025,02,23), new DateOnly(2025,02,25), 13);
        tickets.Add(t1);
        tickets.Add(t2);

        float precioTotal = 0;

        Console.WriteLine("Tickets añadidos: ");
        foreach(Ticket e in tickets)
        {
            Console.WriteLine(e.getString());
            precioTotal += e.getPrecio();
        }

        Console.WriteLine($"Precio total de los tickets: {precioTotal}");

        Console.WriteLine("Ingrese un numero de fila: ");
        int opc = int.Parse(Console.ReadLine());

        Console.WriteLine("Tickets de esa fila: ");
        foreach(Ticket e in tickets)
        {
            if(opc == e.getFila())
            {
                Console.WriteLine(e.getString());
            }
        }
        
    }
}